using Kmd.Momentum.Mea.Funapp.Model;
using Microsoft.Azure.WebJobs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Kmd.Momentum.Mea.Funapp
{
    class CompareSwagger
    {
        private readonly Config _config;

        private readonly ExecutionContext _context;

        public CompareSwagger(ExecutionContext context)
        {
            _context = context;
            _config = GetConfig();
        }

        public async Task CompareJson()
        {
            var baseJson = await ReadUrl(_config.RemotePath);
            var remoteJson = ReadFile(_config.BasePath);
            if (string.IsNullOrEmpty(baseJson))
            {
                //baseJson is Empty
                return;
            }
            if (string.IsNullOrEmpty(remoteJson))
            {
                //remoteJson is Empty
                return;
            }
            if (baseJson == remoteJson)
            {
                //Mea Application is using latest Mca Application
                return;
            }

            var baseJsonObj = JsonConvert.DeserializeObject<JToken>(baseJson);
            var remoteJsonObj = JsonConvert.DeserializeObject<JToken>(remoteJson);

            var baseJObject = baseJsonObj.ToObject<JObject>();
            var remoteJOject = remoteJsonObj.ToObject<JObject>();

            foreach(var _path in _config.ApiList)
            {
               if(baseJObject["paths"][_path] == null)
                {
                    //error
                }
                if (remoteJOject["paths"][_path] == null)
                {
                    //error
                }
                if(!JToken.DeepEquals(baseJObject["paths"][_path], remoteJOject["paths"][_path] == null))
                {
                    foreach (KeyValuePair<string, JToken> sourceProperty in baseJObject)
                    {
                        JProperty targetProp = remoteJOject.Property(sourceProperty.Key);
                        if (!JToken.DeepEquals(sourceProperty.Value, targetProp.Value))
                        {
                            Console.WriteLine(string.Format("{0} property value is changed", sourceProperty.Key));
                        }
                        else
                        {
                            Console.WriteLine(string.Format("{0} property value didn't change", sourceProperty.Key));
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Objects are same");
                }

            }
        }

        private string ReadFile(string path)
        {
            var _path = Path.Combine(_context.FunctionDirectory, path);
            var _fullPath = Path.GetFullPath(_path);
            var data = File.ReadAllText(_fullPath);
            return data;
        }

        private Config GetConfig()
        {
            var data = ReadFile("../config.json");
            return JsonConvert.DeserializeObject<Config>(data);
        }

        private async Task<string> ReadUrl(string uri)
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
