﻿using Microsoft.Azure.WebJobs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Serilog;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Kmd.Momentum.Mea.Common.CompareSwagger
{
    public static class CompareSwagger
    {
        public static async Task CompareJson(ExecutionContext context, ILogger logger, Config config)
        {
            var _config = config ?? GetConfig(context);
            var baseJson = await ReadUrl(_config.RemotePath);
            var remoteJson = ReadFile(context, _config.BasePath);
            if (string.IsNullOrEmpty(baseJson))
            {
                logger.Error("Base Json file is null");
            }

            if (string.IsNullOrEmpty(remoteJson))
            {
                logger.Error("Remote Json file is null");
            }

            if (baseJson == remoteJson)
            {
                logger.Information("Both Json files are same");
                return;
            }

            var baseJsonObj = JsonConvert.DeserializeObject<JToken>(baseJson);
            var remoteJsonObj = JsonConvert.DeserializeObject<JToken>(remoteJson);

            if (baseJsonObj == null)
            {
                logger.Error("Base Json object is null");
            }

            if (remoteJsonObj == null)
            {
                logger.Error("Remote Json object is null");
            }

            var baseJObject = baseJsonObj.ToObject<JObject>();
            var remoteJOject = remoteJsonObj.ToObject<JObject>();

            foreach (var _path in _config.ApiList)
            {
                if (baseJObject["paths"][_path] == null)
                {
                    logger.Error("Base Json path is null");
                }

                if (remoteJOject["paths"][_path] == null)
                {
                    logger.Error("Remote Json path is null");
                }

                if (!JToken.DeepEquals(baseJObject["paths"][_path], remoteJOject["paths"][_path]))
                {
                    logger.Error($"{_path} not matched");
                }

                else
                {
                    logger.Information("Objects are same");
                }
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

