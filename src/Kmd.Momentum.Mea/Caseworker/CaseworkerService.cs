﻿using Kmd.Momentum.Mea.Caseworker.Model;
using Kmd.Momentum.Mea.Common.Exceptions;
using Kmd.Momentum.Mea.MeaHttpClientHelper;
using Kmd.Momentum.Mea.TaskApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Kmd.Momentum.Mea.Caseworker
{
    public class CaseworkerService : ICaseworkerService
    {
        private readonly ICaseworkerHttpClientHelper _caseworkerHttpClient;
        private readonly string _correlationId;
        private readonly string _clientId;

        public CaseworkerService(ICaseworkerHttpClientHelper caseworkerHttpClient, IHttpContextAccessor httpContextAccessor)
        {
            _caseworkerHttpClient = caseworkerHttpClient ?? throw new ArgumentNullException(nameof(caseworkerHttpClient));
            _correlationId = httpContextAccessor.HttpContext.TraceIdentifier;
            _clientId = httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "azp").Value;
        }

        public async Task<ResultOrHttpError<CaseworkerList, Error>> GetAllCaseworkersAsync(int pageNumber)
        {
            var response = await _caseworkerHttpClient.GetAllCaseworkerDataFromMomentumCoreAsync
                ("/punits/0d1345f4-51e0-407e-9dc0-15a9d08326d7/caseworkers", pageNumber).ConfigureAwait(false);

            if (response.IsError)
            {
                var error = response.Error.Errors.Aggregate((a, b) => a + "," + b);

                Log.ForContext("CorrelationId", _correlationId)
                   .ForContext("ClientId", _clientId)
                   .Error("An Error Occured while retrieving data of all the caseworkers" + error);

                return new ResultOrHttpError<CaseworkerList, Error>(response.Error, response.StatusCode.Value);
            }

            Log.ForContext("CorrelationId", _correlationId)
               .ForContext("ClientId", _clientId)
               .Information("All the caseworkers data retrieved successfully");

            return new ResultOrHttpError<CaseworkerList, Error>(response.Result);
        }

        public async Task<ResultOrHttpError<CaseworkerDataResponseModel, Error>> GetCaseworkerByIdAsync(string id)
        {
            var response = await _caseworkerHttpClient.GetCaseworkerDataByCaseworkerIdFromMomentumCoreAsync($"employees/{id}").ConfigureAwait(false);

            if (response.IsError)
            {
                var error = response.Error.Errors.Aggregate((a, b) => a + "," + b);
                Log.ForContext("CorrelationId", _correlationId)
                   .ForContext("Client", _clientId)
                   .ForContext("CaseworkerId", id)
                   .Error("An error occured while retrieving caseworker data by CaseworkerId" + error);
                return new ResultOrHttpError<CaseworkerDataResponseModel, Error>(response.Error, response.StatusCode.Value);
            }

            var content = response.Result;
            var caseworkerDataObj = JsonConvert.DeserializeObject<CaseworkerData>(content);

            var dataToReturn = new CaseworkerDataResponseModel(caseworkerDataObj.Id, caseworkerDataObj.DisplayName, caseworkerDataObj.GivenName,
                caseworkerDataObj.MiddleName, caseworkerDataObj.Initials, caseworkerDataObj.Email?.Address, caseworkerDataObj.Phone?.Number, caseworkerDataObj.CaseworkerIdentifier,
                caseworkerDataObj.Description, caseworkerDataObj.IsActive, caseworkerDataObj.IsBookable);

            Log.ForContext("CorrelationId", _correlationId)
                .ForContext("Client", _clientId)
                .ForContext("CaseworkerId", caseworkerDataObj.Id)
                .Information("The caseworker details by CaseworkerId has been returned successfully");

            return new ResultOrHttpError<CaseworkerDataResponseModel, Error>(dataToReturn);
        }

        public async Task<ResultOrHttpError<TaskList, Error>> GetAllTasksForCaseworkerIdAsync(string caseworkerId, int pageNumber)
        {
            var response = await _caseworkerHttpClient.GetAllTasksByCaseworkerIdFromMomentumCoreAsync
               ("/tasks/filtered", pageNumber, caseworkerId).ConfigureAwait(false);

            if (response.IsError)
            {
                var error = response.Error.Errors.Aggregate((a, b) => a + "," + b);

                Log.ForContext("CorrelationId", _correlationId)
                   .ForContext("ClientId", _clientId)
                   .Error("An Error Occured while retrieving data of all the caseworkers" + error);

                return new ResultOrHttpError<TaskList, Error>(response.Error, response.StatusCode.Value);
            }

            Log.ForContext("CorrelationId", _correlationId)
               .ForContext("ClientId", _clientId)
               .Information("All the caseworkers data retrieved successfully");

            return new ResultOrHttpError<TaskList, Error>(response.Result);

        }
    }
}


