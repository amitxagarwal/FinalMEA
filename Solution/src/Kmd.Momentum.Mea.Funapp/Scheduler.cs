using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Kmd.Momentum.Mea.Common.CompareSwagger;

namespace Kmd.Momentum.Mea.Funapp
{
    public static class Scheduler
    {
        [FunctionName("CompareApplication")]
        public static void Run([TimerTrigger("0 0 0 * * *")] TimerInfo myTimer, ILogger log, ExecutionContext context)
        {
            log.LogInformation($"CompareApplication executed at: {DateTime.Now}");
            try
            {
                var _compareSwager = new CompareSwagger(context);
                _compareSwager.CompareJson().ConfigureAwait(false);
            }
            catch (Exception e)
            {
                log.LogError("Error :" + e.Message);
            }
        }
    }
}
