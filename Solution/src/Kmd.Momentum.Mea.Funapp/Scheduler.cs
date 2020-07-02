using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
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
            var _compareSwager = new CompareSwagger(context);
            _compareSwager.CompareJson().ConfigureAwait(false);

        }
    }
}
