﻿using Kmd.Momentum.Mea.Common.Authorization;
using Kmd.Momentum.Mea.Common.Exceptions;
using Kmd.Momentum.Mea.Common.KeyVault;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Kmd.Momentum.Mea.Common.MeaHttpClient
{
    public class MeaClient : IMeaClient
    {
        private static HttpClient _httpClient;
        private readonly IConfiguration _config;
        private readonly IMeaSecretStore _meaSecretStore;
        private readonly string _correlationId;
        private readonly string _tenant;
        private readonly MeaAuthorization _mcaConfig;

        public MeaClient(IConfiguration config, HttpClient httpClient, IHttpContextAccessor httpContextAccessor, IMeaSecretStore meaSecretStore)
        {
            _config = config;
            _httpClient = httpClient;
            _meaSecretStore = meaSecretStore;
            _correlationId = httpContextAccessor.HttpContext.TraceIdentifier;
            _tenant = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "tenant").Value;
            _mcaConfig = config.GetSection("MeaAuthorization").Get<IReadOnlyList<MeaAuthorization>>().FirstOrDefault(x => x.KommuneId == _tenant);
        }

        public async Task<ResultOrHttpError<string, Error>> GetAsync(string path)
        {
            var authResponse = await ReturnAuthorizationTokenAsync().ConfigureAwait(false);

            if (authResponse.IsError)
            {
                var error = new Error(_correlationId, new string[] { authResponse.Error }, "Momentum Core Api");
                return new ResultOrHttpError<string, Error>(error, authResponse.StatusCode.Value);
            }

            var accessToken = JObject.Parse(await authResponse.Result.Content.ReadAsStringAsync().ConfigureAwait(false))["access_token"];
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse("bearer " + accessToken);

            var url = new Uri($"{_mcaConfig.KommuneUrl}{path}");

            var response = await _httpClient.GetAsync(url).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                var errorFromResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                if (string.IsNullOrEmpty(errorFromResponse))
                {
                    var error = new Error(_correlationId, new string[] { "An error occured while fetching the record(s) from Core Api" }, "MEA");
                    Log.ForContext("CorrelationId", _correlationId).Error("Error Occured while getting the data from Momentum Core System");

                    return new ResultOrHttpError<string, Error>(error, response.StatusCode);
                }

                try
                {
                    var error = JsonConvert.DeserializeObject<Error>(errorFromResponse);
                    if (error.Errors == null)
                    {
                        var errorIs = new Error(_correlationId, new string[] { errorFromResponse }, "MEA");
                        Log.ForContext("CorrelationId", _correlationId).Error("Error Occured while getting the data from Momentum Core System");

                        return new ResultOrHttpError<string, Error>(errorIs, response.StatusCode);
                    }
                    Log.ForContext("CorrelationId", _correlationId).Error($"Error Occured while getting the data from Momentum Core System : {errorFromResponse}");
                    return new ResultOrHttpError<string, Error>(error, response.StatusCode);
                }
                catch
                {
                    var error = new Error(_correlationId, new string[] { "An error occured while fetching the record(s) from Core Api", errorFromResponse }, "MEA");
                    Log.ForContext("CorrelationId", _correlationId).Error($"Error Occured while getting the data from Momentum Core System : {errorFromResponse}");

                    return new ResultOrHttpError<string, Error>(error, response.StatusCode);
                }
            }

            return new ResultOrHttpError<string, Error>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        public async Task<ResultOrHttpError<string, Error>> PostAsync(string path, StringContent stringContent)
        {
            var authResponse = await ReturnAuthorizationTokenAsync().ConfigureAwait(false);

            if (authResponse.IsError)
            {
                Log.ForContext("CorrelationId", _correlationId).Error($"Error Occured while creating records in Momentum Core System : {authResponse.Error}");
                var error = new Error(_correlationId, new string[] { authResponse.Error }, "Momentum Core Api");

                return new ResultOrHttpError<string, Error>(error, authResponse.StatusCode.Value);
            }

            var accessToken = JObject.Parse(await authResponse.Result.Content.ReadAsStringAsync().ConfigureAwait(false))["access_token"];
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse("bearer " + accessToken);

            var url = new Uri($"{_mcaConfig.KommuneUrl}{path}");

            var response = await _httpClient.PostAsync(url, stringContent).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                if ((int)response.StatusCode >= (int)HttpStatusCode.BadRequest && (int)response.StatusCode < (int)HttpStatusCode.InternalServerError)
                {
                    var errorFromResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var error = new Error(_correlationId, new string[] { "An error occured while creating records in Momentum Core System" }, "MEA");
                    Log.ForContext("CorrelationId", _correlationId).Error($"Error Occured while creating records in Momentum Core System : {errorFromResponse}");

                    return new ResultOrHttpError<string, Error>(error, response.StatusCode);
                }

                var errorResponse = JsonConvert.DeserializeObject<Error>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));

                Log.ForContext("CorrelationId", _correlationId).Error($"Error Occured while creating records in Momentum Core System {errorResponse}");

                return new ResultOrHttpError<string, Error>(errorResponse, response.StatusCode);
            }

            return new ResultOrHttpError<string, Error>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        public async Task<ResultOrHttpError<string, Error>> PutAsync(string path)
        {
            var authResponse = await ReturnAuthorizationTokenAsync().ConfigureAwait(false);

            if (authResponse.IsError)
            {
                var error = new Error(_correlationId, new string[] { authResponse.Error }, "Momentum Core Api");

                return new ResultOrHttpError<string, Error>(error, authResponse.StatusCode.Value);
            }

            var accessToken = JObject.Parse(await authResponse.Result.Content.ReadAsStringAsync().ConfigureAwait(false))["access_token"];
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse("bearer " + accessToken);

            var url = new Uri($"{_mcaConfig.KommuneUrl}{path}");

            var response = await _httpClient.PutAsync(url, null).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                var errorFromResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                if (string.IsNullOrEmpty(errorFromResponse))
                {
                    var error = new Error(_correlationId, new string[] { "An error occured while updating records in Momentum Core System" }, "MEA");
                    Log.ForContext("CorrelationId", _correlationId).Error("An error occured while updating records in Momentum Core System");

                    return new ResultOrHttpError<string, Error>(error, response.StatusCode);
                }

                try
                {
                    var error = JsonConvert.DeserializeObject<Error>(errorFromResponse);
                    if (error.Errors == null)
                    {
                        var errorIs = new Error(_correlationId, new string[] { errorFromResponse }, "MEA");
                        Log.ForContext("CorrelationId", _correlationId).Error("An error occured while updating records in Momentum Core System");

                        return new ResultOrHttpError<string, Error>(errorIs, response.StatusCode);
                    }
                    Log.ForContext("CorrelationId", _correlationId).Error($"An error occured while updating records in Momentum Core System : {errorFromResponse}");
                    return new ResultOrHttpError<string, Error>(error, response.StatusCode);
                }
                catch
                {
                    var error = new Error(_correlationId, new string[] { "An error occured while updating records in Momentum Core System", errorFromResponse }, "MEA");
                    Log.ForContext("CorrelationId", _correlationId).Error($"An error occured while updating records in Momentum Core System : {errorFromResponse}");

                    return new ResultOrHttpError<string, Error>(error, response.StatusCode);
                }
            }

            return new ResultOrHttpError<string, Error>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        private async Task<ResultOrHttpError<HttpResponseMessage, string>> ReturnAuthorizationTokenAsync()
        {
            var meaSecret = await GetMeaSecret().ConfigureAwait(false);

            if (meaSecret == null)
            {
                Log.ForContext("CorrelationId", _correlationId)
                    .Error("Could not fetch the mca client secret value from the key vault");

                return new ResultOrHttpError<HttpResponseMessage, string>("Could not find the client secret value for authorizing to momentum core system");
            }

            var token = await GetTokenAsync(meaSecret).ConfigureAwait(false);

            if (token.IsError)
            {
                Log.ForContext("CorrelationId", _correlationId).Error($"Error Occured while getting access token from Momentum Core System : {token.Error}");
                var error = new Error(_correlationId, new string[] { token.Error }, "Momentum Core Api");

                return new ResultOrHttpError<HttpResponseMessage, string>(error.ToString(), token.StatusCode.Value);
            }

            return new ResultOrHttpError<HttpResponseMessage, string>(token.Result);
        }

        private async Task<string> GetMeaSecret()
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

            return environment == "Build"
                ? Environment.GetEnvironmentVariable("KMD_MOMENTUM_MEA_McaClientSecret")
                : (await _meaSecretStore.GetSecretValueBySecretKeyAsync(_mcaConfig.KommuneAccessIdentifier).ConfigureAwait(false)).SecretValue;
        }

        private async Task<ResultOrHttpError<HttpResponseMessage, string>> GetTokenAsync(string clientSecret)
        {
            try
            {
                var content = new FormUrlEncodedContent(new[]
               {
                        new KeyValuePair<string, string>("grant_type","client_credentials"),
                        new KeyValuePair<string, string>("client_id", _mcaConfig.KommuneClientId),
                        new KeyValuePair<string, string>("client_secret", clientSecret),
                        new KeyValuePair<string, string>("resource", _mcaConfig.KommuneResource)
               });

                var response = await _httpClient.PostAsync(new Uri($"{_config["Scope"]}"), content).ConfigureAwait(false);

                if (!response.IsSuccessStatusCode)
                {
                    var errorResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    Log.ForContext("CorrelationId", _correlationId)
                        .Error($"Couldn't get the authorization from Momentum Core System with error as {errorResponse}", errorResponse);

                    return new ResultOrHttpError<HttpResponseMessage, string>("Current request is not authorized to access Momentum Core System", System.Net.HttpStatusCode.Unauthorized);
                }

                Log.ForContext("CorrelationId", _correlationId)
                    .Information("Current request is authorized to access Momentum Core System");

                return new ResultOrHttpError<HttpResponseMessage, string>(response);
            }
            catch (Exception ex)
            {
                Log.ForContext("CorrelationId", _correlationId)
                    .Error($"Couldn't fetch the configuration data to access Momentum Core System with error {ex.InnerException}");

                return new ResultOrHttpError<HttpResponseMessage, string>("Couldn't fetch the configuration data to access Momentum Core System", System.Net.HttpStatusCode.Unauthorized);
            }
        }
    }
}