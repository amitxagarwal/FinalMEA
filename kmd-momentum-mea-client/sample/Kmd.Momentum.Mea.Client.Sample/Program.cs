﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using Kmd.Logic.Identity.Authorization;
using Kmd.Momentum.Mea.Client.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Rest;
using Serilog;

namespace Kmd.Momentum.Mea.Client.Sample
{
    public static class Program
    {
        [SuppressMessage("ReSharper", "CA1031", Justification = "We are logging the exception.")]
        public static int Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .MinimumLevel.Verbose()
                .WriteTo.Console()
                .CreateLogger();
            try
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(AppContext.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: false)
                    .AddEnvironmentVariables()
                    .AddCommandLine(args)
                    .Build()
                    .Get<CommandLineConfig>();

                switch (config.Action)
                {
                    case CommandLineAction.None:
                        Log.Information("You must provide arguments");
                        break;
                    case CommandLineAction.GetAllCaseworkers:
                        GetAllCaseworkers(config);
                        break;
                    case CommandLineAction.GetCaseworkerById:
                        GetCaseworkerById(config);
                        break;
                    case CommandLineAction.GetTasksbyCaseworker:
                        GetTasksbyCaseworker(config);
                        break;
                    case CommandLineAction.GetAllActiveCitizens:
                        GetAllActiveCitizens(config);
                        break;
                    case CommandLineAction.GetCitizenByCpr:
                        GetCitizenByCpr(config);
                        break;
                    case CommandLineAction.GetCitizenById:
                        GetCitizenById(config);
                        break;
                    case CommandLineAction.UpdateTaskStatus:
                        UpdateTaskStatus(config);
                        break;
                    case CommandLineAction.CreateJournalNote:
                        CreateJournalNote(config);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException($"Unknown action {config.Action}");
                }

                return 0;
            }
            catch (System.Exception fatalException)
            {
                Log.Fatal(fatalException, "Fatal exception");
                return 1;
            }
            finally
            {
                Log.Information("Shutting down");
                Log.CloseAndFlush();
            }
        }

        private static IInternalClient GetApi(CommandLineConfig config)
        {
            if (config.MomentumApiBaseUri == null)
            {
                throw new System.Exception("You must specify a MomentumApiBaseUri");
            }

            var validateConfigurations = new ValidateConfigurations(config);
            if (!validateConfigurations.ValidateTokenProviderOptions())
            {
                throw new System.Exception("You must specify proper information to `appsettings.json`");
            }

            var tokenProviderOptions = new LogicTokenProviderOptions
            {
                AuthorizationScope = config.TokenProvider.AuthorizationScope,
                ClientId = config.TokenProvider.ClientId,
                ClientSecret = config.TokenProvider.ClientSecret,
                AuthorizationTokenIssuer = config.TokenProvider.AuthorizationTokenIssuer,
            };

            var httpClient = new HttpClient();
            var tokenProviderFactory = new LogicTokenProviderFactory(tokenProviderOptions);
            var tokenProvider = tokenProviderFactory.GetProvider(httpClient);

            var client = new InternalClient(new TokenCredentials(tokenProvider))
            {
                BaseUri = config.MomentumApiBaseUri,
            };

            Log.Information("Created API with Base URI {BaseUri}", client.BaseUri);
            return client;
        }

        public static void ValidateParameter(Parameter parameterName, string parameterValue)
        {
            if (string.IsNullOrEmpty(parameterValue))
            {
                Log.Information("CaseworkerId is not mentioned", parameterValue);
                throw new System.Exception($"You must specify a {parameterName}");
            }
        }

        private static void GetAllCaseworkers(CommandLineConfig config)
        {
            var client = GetApi(config);
            var response = client.GetAllCaseworkers(config.PageNo);
            Log.Information("Got All Caseworkers", response);
        }

        private static void GetCaseworkerById(CommandLineConfig config)
        {
            ValidateParameter(Parameter.CaseworkerId, config.CaseworkerId);

            var client = GetApi(config);
            var response = client.GetCaseworkerById(config.CaseworkerId);
            Log.Information("Got Caseworkers Details By Id", response);
        }

        private static void GetTasksbyCaseworker(CommandLineConfig config)
        {
            ValidateParameter(Parameter.CaseworkerId, config.CaseworkerId);

            var client = GetApi(config);
            var response = client.GetTasksbyCaseworker(config.CaseworkerId, config.PageNo);
            Log.Information("Got All Task For The Caseworkers", response);
        }

        private static void GetCitizenByCpr(CommandLineConfig config)
        {
            ValidateParameter(Parameter.CprNumber, config.CprNumber);

            var client = GetApi(config);
            var response = client.GetCitizenByCpr(config.CprNumber);
            Log.Information("Got Citizen in Momentum by CPR", response);
        }

        private static void GetAllActiveCitizens(CommandLineConfig config)
        {
            var client = GetApi(config);
            var response = client.GetAllActiveCitizens(config.PageNo);
            Log.Information("Got all active citizens", response);
        }

        private static void GetCitizenById(CommandLineConfig config)
        {
            ValidateParameter(Parameter.CitizenId, config.CitizenId);

            var client = GetApi(config);
            var response = client.GetCitizenById(config.CitizenId);
            Log.Information("Got Citizen in Momentum by IDs", response);
        }

        private static void UpdateTaskStatus(CommandLineConfig config)
        {
            TaskUpdateStatus taskUpdateStatus = new TaskUpdateStatus()
            {
                TaskAction = config.TaskAction,
                TaskContext = config.TaskContext,
            };

            if (taskUpdateStatus == null)
            {
                Log.Information("Task Action and Task Context is not mentioned", taskUpdateStatus);
                throw new System.Exception("You must specify a Task Action and Task Context");
            }

            ValidateParameter(Parameter.TaskId, config.TaskId);

            var client = GetApi(config);
            var response = client.UpdateTaskStatus(taskUpdateStatus, config.TaskId);
            Log.Information("Updated task status ", response);
        }

        private static void CreateJournalNote(CommandLineConfig config)
        {
            JournalNoteDocumentRequestModel journalNoteDocumentRequestModel = new JournalNoteDocumentRequestModel()
            {
                Content = config.Content,
                ContentType = config.ContentType,
                Name = config.Name,
            };

            IList<JournalNoteDocumentRequestModel> GetReadOnlyValues()
            {
                List<JournalNoteDocumentRequestModel> journalNoteDocumentRequestModelList = new List<JournalNoteDocumentRequestModel>()
                {
                    journalNoteDocumentRequestModel,
                };
                return journalNoteDocumentRequestModelList.AsReadOnly();
            }

            JournalNoteRequestModel journalNoteRequestModel = new JournalNoteRequestModel()
            {
                Body = config.Body,
                Cpr = config.Cpr,
                Documents = GetReadOnlyValues(),
                Title = config.Title,
                Type = config.Type,
            };
            if (journalNoteRequestModel == null)
            {
                Log.Information("One or more JournalNoteDocumentRequestModel property is not mentioned", journalNoteRequestModel);
                throw new System.Exception("You must specify a properties of JournalNoteDocumentRequestModel ");
            }

            ValidateParameter(Parameter.MomentumCitizenId, config.MomentumCitizenId);

            var client = GetApi(config);
            var response = client.CreateJournalNote(journalNoteRequestModel, config.MomentumCitizenId);
            Log.Information("Created a Journal Note with attachment", response);
        }
    }
}
