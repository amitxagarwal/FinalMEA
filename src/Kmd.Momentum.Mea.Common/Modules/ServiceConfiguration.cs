﻿using CorrelationId;
using Kmd.Momentum.Mea.Common.Authorization;
using Kmd.Momentum.Mea.Common.Authorization.Caseworker;
using Kmd.Momentum.Mea.Common.Authorization.Citizen;
using Kmd.Momentum.Mea.Common.Authorization.Journal;
using Kmd.Momentum.Mea.Common.Authorization.Tasks;
using Kmd.Momentum.Mea.Common.Framework;
using Kmd.Momentum.Mea.Common.Framework.PollyOptions;
using Kmd.Momentum.Mea.Common.KeyVault;
using Kmd.Momentum.Mea.Common.MeaHttpClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kmd.Momentum.Mea.Common.Modules
{
    public class ServiceConfiguration : IServiceConfiguration
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IAuthorizationHandler, MeaCitizenClaimHandler>();
            services.AddSingleton<IAuthorizationHandler, MeaCaseworkerClaimHandler>();
            services.AddSingleton<IAuthorizationHandler, MeaJournalClaimHandler>();
            services.AddSingleton<IAuthorizationHandler, MeaTaskClaimHandler>();
            services
                .AddPolicies(configuration)
                .AddHttpClient<IMeaClient, MeaClient, MeaClientOptions>(
                    configuration,
                    nameof(ApplicationOptions.MeaClient));

            services.AddCorrelationId();
            services.AddSingleton<IMeaCustomClaimsCheck, MeaCustomClaimsCheck>();
            services.AddTransient<IMeaKeyVaultClientFactory, MeaKeyVaultClientFactory>();
            services.AddTransient<IMeaSecretStore, MeaSecretStore>();
        }
    }
}
