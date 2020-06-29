using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Kmd.Momentum.Mea.Funapp
{
    public static class Scheduler
    {
        [FunctionName("CompareApplication")]
         public static async void Run([TimerTrigger("0 */5 * * * *")]TimerInfo myTimer, ILogger log, ExecutionContext context)
        
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            SwaggerCompare obj = new SwaggerCompare(context);
          var a =  obj.GetJsonFromFolder();
          var b =  await obj.GetJsonFromUrl();

            var rep = JsonConvert.SerializeObject(a) ;
            var rep1 = JsonConvert.SerializeObject(b);
            //var xptProps = a.PropertyValues().ToList();
            //var actProps = b.PropertyValues().ToList();
            var xptProps = a.Properties().ToList();
            var actProps = b.Properties().ToList();

            var missingProps = xptProps.Where(expected => actProps.Where(actual => actual.Name == expected.Name).Count() == 0);
            var res = JToken.DeepEquals(a, b);
            // return ("responseMessage");

            if (!JToken.DeepEquals(a, b))
            {
                foreach (KeyValuePair<string, JToken> sourceProperty in a)
                {
                    JProperty targetProp = b.Property(sourceProperty.Key);
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


            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            if (comparer.Compare(rep, rep1) == 0)
            {
                Console.WriteLine($"Both strings have same value.");
            }
            else
            {
                Console.WriteLine($"error.");
            }
            
        }
    }
}
