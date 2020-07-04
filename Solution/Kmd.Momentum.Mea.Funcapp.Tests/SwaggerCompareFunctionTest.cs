using Kmd.Momentum.Mea.Common.CompareSwagger;
using Kmd.Momentum.Mea.Funapp;
using Microsoft.Azure.WebJobs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Kmd.Momentum.Mea.Funcapp.Tests
{
    public class SwaggerCompareFunctionTest
    {
        [Fact]
        public async Task SwaggerCompareTestForUnmodified()
        {
            var logger = new ListLogger();
            var executionContext = new ExecutionContext
            {
                FunctionDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName,
            };

            await Scheduler.Run(null, logger, executionContext);

            Assert.Contains("SwaggerComparer function executed at:", logger.Logs[0]);
            Assert.Contains("Both Json files are same", logger.Logs[1]);
        }


        [Fact]
        public async Task SwaggerCompareTestFormodified()
        {
            var logger = new ListLogger();
            var executionContext = new ExecutionContext
            {
                FunctionDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName,
            };

            var config = new Config()
            {
                BasePath = "../SwaggerJson/v2.json",
                RemotePath = "https://kmd-rct-momentum-159-api.azurewebsites.net/api/swagger/docs/v1",
                ApiList = new string[]
                {
                    "/punits/{id}/caseworkers",
                    "/employees/{id}",
                    "/tasks/filtered",
                    "/search",
                    "/citizens/{cpr}",
                    "/citizens/{citizenId}",
                    "/journals/note",
                    "/tasks/{id}/{taskAction}"
                }
            };

            await CompareSwagger.CompareJson(executionContext, logger, config).ConfigureAwait(false);

            Assert.Contains("Api '/punits/{id}/caseworkers' not found in Base Swagger Json file", logger.Logs[0]);
        }
    }
}
