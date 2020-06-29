using Microsoft.Azure.WebJobs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Kmd.Momentum.Mea.Funapp
{
    public class SwaggerCompare
    {
        private readonly ExecutionContext _context;
        public SwaggerCompare(ExecutionContext context)
        {
            _context = context;
        }
        public JObject GetJsonFromFolder()
        {
            JObject apiData;
            //from folder
            var path = System.IO.Path.Combine(_context.FunctionDirectory, "jsconfig1.json");
            var p = Path.GetFullPath(Path.Combine(_context.FunctionDirectory, "..\\jsconfig1.json"));
            string st = File.ReadAllText(@p);
            apiData = JsonConvert.DeserializeObject<JObject>(st);
            return apiData;
        }
        public async Task<JObject> GetJsonFromUrl()
        {
            JObject apiData;
            //from url
            var client = new HttpClient();
            var response =  await client.GetAsync("https://kmd-momentum-mea-internal-webapp.azurewebsites.net/swagger/v1/swagger.json");
            var json =  await response.Content.ReadAsStringAsync();
            apiData = JsonConvert.DeserializeObject<JObject>(json);
            return apiData;
        }
    }
}
    

