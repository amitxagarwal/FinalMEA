using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Kmd.Momentum.Mea.Common.CompareSwagger
{
    public static class CompareSwagger
    {
        private static ILogger _logger;
        private static List<string> errorList = new List<string>();

        public static async Task CompareJson(ExecutionContext context, ILogger log, Config config)
        {
            _logger = log;
            try
            {
                var _config = config ?? GetConfig(context);
                var baseJson = ReadFile(context, _config.BasePath);
                var remoteJson = await ReadUrl(_config.RemotePath);
                if (string.IsNullOrEmpty(baseJson))
                {
                    _logger.LogError("Base Swagger Json file is null");
                    errorList.Add("Base Swagger Json file is null");
                    SendNotification(context);
                    return;
                }

                if (string.IsNullOrEmpty(remoteJson))
                {
                    _logger.LogError("Remote Swagger Json file is null");
                    errorList.Add("Remote Swagger Json file is null");
                    SendNotification(context);
                    return;
                }

                if (baseJson == remoteJson)
                {
                    _logger.LogInformation("Both Json files are same");
                    return;
                }

                var baseJsonObj = JsonConvert.DeserializeObject<JObject>(baseJson);
                var remoteJsonObj = JsonConvert.DeserializeObject<JObject>(remoteJson);

                if (baseJsonObj == null)
                {
                    _logger.LogError("Base Swagger Json object is null");
                    errorList.Add("Base Swagger Json object is null");
                    SendNotification(context);
                    return;
                }

                if (remoteJsonObj == null)
                {
                    _logger.LogError("Remote Swagger Json object is null");
                    errorList.Add("Remote Swagger Json object is null");
                    SendNotification(context);
                    return;
                }

                foreach (var _path in _config.ApiList)
                {
                    if (baseJsonObj["paths"][_path] == null)
                    {
                        _logger.LogError($"Api '{_path }' not found in Base Swagger Json file");
                        errorList.Add($"Api '{_path }' not found in Base Swagger Json file");
                        continue;
                    }

                    if (remoteJsonObj["paths"][_path] == null)
                    {
                        _logger.LogError($"Api '{_path }' not found in Remote Swagger Json file");
                        errorList.Add($"Api '{_path }' not found in Remote Swagger Json file");
                        continue;
                    }

                    if (!JToken.DeepEquals(baseJsonObj["paths"][_path], remoteJsonObj["paths"][_path]))
                    {
                        _logger.LogError($"Api '{_path}' is changed in Remote Swagger Json");
                        errorList.Add($"Api '{_path}' is changed in Remote Swagger Json");
                    }
                    else
                    {
                        CompareHelper(baseJsonObj["paths"][_path], remoteJsonObj["paths"][_path], baseJsonObj, remoteJsonObj);
                    }
                }
                SendNotification(context);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error Occured while comparing the Swagger json files: {ex.InnerException}");                
            }
            finally
            {
                errorList = null;
            }
        }

        private static void SendNotification(ExecutionContext context)
        {
            if (errorList.Count > 0)
            {
                _logger.LogError("Error: instance Id is " + context.InvocationId);
            }
            else
            {
                _logger.LogInformation("No difference found in local MCA Swagger JSON and Online MCA Swagger JSON.");
            }
            foreach (var error in errorList)
            {
                _logger.LogError(error);
            }
            errorList.Clear();
        }

        private static void CompareHelper(JToken _base, JToken _remote, JObject baseJsonObject, JObject remoteJsonObject)
        {
            if (_base.Type == JTokenType.Object)
            {
                foreach (var _val in _base)
                {
                    var _propName = ((JProperty)_val).Name;
                    if (_propName.ToLower() == "$ref")
                    {
                        CompareRef(_base["$ref"], baseJsonObject, remoteJsonObject);
                    }
                    else
                    {
                        CompareHelper(_base[_propName], _remote[_propName], baseJsonObject, remoteJsonObject);
                    }
                }
            }
            else if (_base.Type == JTokenType.Array)
            {
                var _arrBase = (JArray)(_base);
                var _arrRemote = (JArray)(_remote);
                for (int i = 0; i < _arrBase.Count; i++)
                {
                    CompareHelper(_arrBase[i], _arrRemote[i], baseJsonObject, remoteJsonObject);
                }
            }
        }

        private static void CompareRef(JToken refModel, JObject baseJsonObject, JObject remoteJsonObject)
        {
            var _modelPathArr = refModel.ToString().Replace("#/", "").Split("/");
            var _baseModel = baseJsonObject;
            var _remoteModel = remoteJsonObject;
            foreach (var prop in _modelPathArr)
            {
                if (_baseModel[prop] == null)
                {
                    _logger.LogError($"Propery '{prop}' not found for model '{ refModel }' in Base Swagger Json file");
                    errorList.Add($"Propery '{prop}' not found for model '{ refModel }' in Base Swagger Json file");
                    return;
                }
                if (_remoteModel[prop] == null)
                {
                    _logger.LogError($"Propery '{prop}' not found for model '{ refModel }' in Remote Swagger Json file");
                    errorList.Add($"Propery '{prop}' not found for model '{ refModel }' in Remote Swagger Json file");
                    return;
                }
                _baseModel = _baseModel[prop].ToObject<JObject>();
                _remoteModel = _remoteModel[prop].ToObject<JObject>();
            }
            if (!JObject.DeepEquals(_baseModel, _remoteModel))
            {
                _logger.LogError($"'{_modelPathArr[_modelPathArr.Length - 1] }' model is not matched");
                errorList.Add($"'{_modelPathArr[_modelPathArr.Length - 1] }' model is not matched");
            }
            else
            {
                CompareHelper(_baseModel, _remoteModel, baseJsonObject, remoteJsonObject);
            }
        }

        private static string ReadFile(ExecutionContext context, string path)
        {
            var _path = Path.Combine(context.FunctionDirectory, path);
            var _fullPath = Path.GetFullPath(_path);
            var data = File.ReadAllText(_fullPath);
            return data;
        }

        private static Config GetConfig(ExecutionContext context)
        {
            var data = ReadFile(context, "../config.json");
            return JsonConvert.DeserializeObject<Config>(data);
        }

        private static async Task<string> ReadUrl(string uri)
        {
            var data = string.Empty;

            var client = new HttpClient();
            var response = await client.GetAsync(uri);
            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                data = await response.Content.ReadAsStringAsync();
            }

            return data;
        }
    }
}

