using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using System;
using System.Diagnostics.CodeAnalysis;

[assembly: FunctionsStartup(typeof(Kmd.Momentum.Mea.Funapp.Startup))]

namespace Kmd.Momentum.Mea.Funapp
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var levelSwitch = new LoggingLevelSwitch(initialMinimumLevel: LogEventLevel.Verbose);

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.ControlledBy(levelSwitch)
                .Enrich.FromLogContext()
                .Enrich.WithProperty(name: "EnvironmentSource", value: Environment.GetEnvironmentVariable("ENVIRONMENT_SOURCE") ?? "local")
                .Enrich.WithProperty(name: "Application", value: GetType().Assembly.GetName().Name)
                .Enrich.WithProperty(name: "ApplicationVersion", value: GetType().Assembly.GetName().Version.ToString())
                .WriteTo.Seq(
                    serverUrl: Environment.GetEnvironmentVariable("KMD_MOMENTUM_MEA_DiagnosticSeqServerUrl") ?? GetDefaultSeqServerUrl(),
                    apiKey: Environment.GetEnvironmentVariable("KMD_MOMENTUM_MEA_DiagnosticSeqApiKey"),
                    compact: true,
                    controlLevelSwitch: levelSwitch)
                .CreateLogger();

            builder.Services.AddLogging(logging => logging.AddSerilog());
        }

        [SuppressMessage("Minor Code Smell", "S1075:URIs should not be hardcoded", Justification = "Use well-known location of Seq as default URI for Seq Server")]
        private static string GetDefaultSeqServerUrl()
        {
            const string defaultSeqServerUrl = "http://localhost:5341/";
            return defaultSeqServerUrl;
        }
    }
}
