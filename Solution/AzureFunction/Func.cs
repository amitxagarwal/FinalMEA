using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Azure.WebJobs;
using System.Net.Http;
using Microsoft.Build.Utilities;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace AzureFunction
{
    public class Func
    {
        private readonly ExecutionContext _context;
        public Func(ExecutionContext context)
        {
            _context = context;
        }
        public JToken GetJsonFromFolder()
        {

            //from folder
            var path = System.IO.Path.Combine(_context.FunctionDirectory, "jsconfig1.json");
            var p = Path.GetFullPath(Path.Combine(_context.FunctionDirectory, "..\\jsconfig1.json"));
            string st = File.ReadAllText(@p);
            return st;
        }
        public async Task<JToken> GetJsonFromUrl()
        {

            //from url
            var client = new HttpClient();
            var response = await client.GetAsync("https://kmd-momentum-mea-internal-webapp.azurewebsites.net/swagger/v1/swagger.json");
            var json = await response.Content.ReadAsStringAsync();
            return json;
        }

    }
}
