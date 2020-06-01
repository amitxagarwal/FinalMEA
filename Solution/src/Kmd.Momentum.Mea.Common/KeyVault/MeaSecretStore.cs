﻿using Microsoft.Azure.KeyVault;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Kmd.Momentum.Mea.Common.KeyVault
{
    public class MeaSecretStore : IMeaSecretStore
    {
        private readonly IConfiguration _configuration;
        private readonly IMeaKeyVaultClientFactory _meaKeyVaultClientFactory;
        private IKeyVaultClient _keyVaultClient;

        public MeaSecretStore(IMeaKeyVaultClientFactory meaKeyVaultClientFactory, IConfiguration configuration)
        {
            _meaKeyVaultClientFactory = meaKeyVaultClientFactory ?? throw new ArgumentNullException(nameof(meaKeyVaultClientFactory));
            _configuration = configuration;
        }


        private IKeyVaultClient KeyVaultClient
        {
            get
            {
                return _keyVaultClient ?? (_keyVaultClient = _meaKeyVaultClientFactory.CreateKeyVaultClient(_configuration.GetSection("MeaKeyVaultSecretStore:AzureServicesAuthConnectionString").Value));
            }
        }

        public async Task<SecretModel> GetSecretValueBySecretKeyAsync(string secretKey)
        {
            var result = await KeyVaultClient.GetSecretAsync(_configuration.GetSection("MeaKeyVaultSecretStore:KeyVaultUrl").Value, secretKey).ConfigureAwait(false);
            return new SecretModel(result.SecretIdentifier.Name, result.Value, result.SecretIdentifier.Identifier);
        }
    }
}