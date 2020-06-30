using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace Kmd.Momentum.Mea.Funapp
{
    public static class Scheduler
    {
        [FunctionName("CompareApplication")]
        public static string Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log, ExecutionContext context)
        //public static void Run([TimerTrigger("0 */1 * * * *")]TimerInfo myTimer, ILogger log, ExecutionContext context)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            var _compareSwager = new CompareSwagger(context);
            _compareSwager.CompareJson().ConfigureAwait(false);

            return ("response");
        }
    }
}
