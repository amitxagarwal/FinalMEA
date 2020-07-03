using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Kmd.Momentum.Mea.Common.CompareSwagger;

namespace Kmd.Momentum.Mea.Funapp
{
    public static class Scheduler
    {
        [FunctionName("SwaggerComparer")]
        public static void Run([TimerTrigger("0 */1 * * * *")] TimerInfo myTimer, ILogger log, ExecutionContext context)
        {
            log.LogInformation($"SwaggerComparer function executed at: {DateTime.Now}");
            try
            {
                
                CompareSwagger.CompareJson(context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                log.LogError("Error :" + e.Message);
            }
        }
    }
}
