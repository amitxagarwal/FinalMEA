using FluentAssertions;
using Kmd.Momentum.Mea.Common.CompareSwagger;
using Kmd.Momentum.Mea.Funapp;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger logger = TestFactory.CreateLogger();

        [Fact]
        public async Task SwaggerCompareTestForUnmodified()
        {
            //Arrange
            var logger = (ListLogger)TestFactory.CreateLogger(LoggerTypes.List);

            var executionContext = new ExecutionContext
            {
                FunctionDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName,
            };

            //Act
            await Scheduler.Run(null, logger, executionContext);

            //Assert
            logger.Logs[0].Should().Contain("SwaggerComparer function executed at:");
            logger.Logs[1].Should().Contain("Both Json files are same");
        }


        [Fact]
        public async Task SwaggerCompareTestFormodified()
        {
            //Arrange
            var logger = (ListLogger)TestFactory.CreateLogger(LoggerTypes.List);
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

            //Act
            await CompareSwagger.CompareJson(executionContext,logger, config).ConfigureAwait(false);

            //Assert
            logger.Logs[0].Should().Contain("Api '/punits/{id}/caseworkers' not found in Base Swagger Json file");
        }
    }
}
