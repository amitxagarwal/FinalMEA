using System;
using Microsoft.Azure.WebJobs;
using Kmd.Momentum.Mea.Common.CompareSwagger;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Kmd.Momentum.Mea.Funapp
{
    public static class Scheduler
    {
        [FunctionName("SwaggerComparer")]
        public static async Task Run([TimerTrigger("0 */1 * * * *", RunOnStartup = true)] TimerInfo myTimer, ILogger log, ExecutionContext context)
        {
            log.LogInformation($"SwaggerComparer function executed at: {DateTime.Now}");
            try
            {
                await CompareSwagger.CompareJson(context,log, null).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                log.LogError("Error :" + e.Message);
            }
        }
    }
}
