using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Kmd.Momentum.Mea.Common.CompareSwagger;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;

namespace Kmd.Momentum.Mea.Funapp
{
    public static class Scheduler
    {
        [FunctionName("SwaggerComparer")]
        public static string Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log, ExecutionContext context)
        {
            log.LogInformation($"SwaggerComparer function executed at: {DateTime.Now}");
            try
            {
                var _compareSwager = new CompareSwagger(context);
                _compareSwager.CompareJson().ConfigureAwait(false);
            }
            catch (Exception e)
            {
                log.LogError("Error :" + e.Message);
            }
            return "hi";
        }
    }
}
