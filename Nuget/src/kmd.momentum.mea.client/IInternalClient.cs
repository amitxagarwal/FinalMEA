// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Kmd.Momentum.Mea.Client
{
    using Microsoft.Rest;
    using Models;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// </summary>
    public partial interface IInternalClient : System.IDisposable
    {
        /// <summary>
        /// The base URI of the service.
        /// </summary>
        System.Uri BaseUri { get; set; }

        /// <summary>
        /// Gets or sets json serialization settings.
        /// </summary>
        JsonSerializerSettings SerializationSettings { get; }

        /// <summary>
        /// Gets or sets json deserialization settings.
        /// </summary>
        JsonSerializerSettings DeserializationSettings { get; }

        /// <summary>
        /// Subscription credentials which uniquely identify client
        /// subscription.
        /// </summary>
        ServiceClientCredentials Credentials { get; }


        /// <summary>
        /// Get all the  caseworkers
        /// </summary>
        /// <param name='pageNumber'>
        /// The PageNumber to access the records from Core system. Minimum
        /// Value is 0
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<object>> GetAllCaseworkersWithHttpMessagesAsync(int? pageNumber = 0, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Get caseworkers in Momentum with ID
        /// </summary>
        /// <param name='caseworkerId'>
        /// The caseworker id to access the records from Core system.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<object>> GetCaseworkerByIdWithHttpMessagesAsync(string caseworkerId, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Get all tasks for the caseworkers
        /// </summary>
        /// <param name='caseworkerId'>
        /// The caseworker id to access the records from Core system.
        /// </param>
        /// <param name='pageNumber'>
        /// The PageNumber to access the records from Core system. Minimum
        /// Value is 0
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<object>> GetTasksbyCaseworkerWithHttpMessagesAsync(string caseworkerId, int? pageNumber = 0, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Get all active citizens
        /// </summary>
        /// <param name='pageNumber'>
        /// The PageNumber to access the records from Core system. Minimum
        /// Value is 1
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<object>> GetAllActiveCitizensWithHttpMessagesAsync(int? pageNumber = 1, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Get Citizen in Momentum by CPR
        /// </summary>
        /// <param name='cprNumber'>
        /// The CPR number to search the record in the Core system
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<object>> GetCitizenByCprWithHttpMessagesAsync(string cprNumber, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Get Citizen in Momentum by ID
        /// </summary>
        /// <param name='citizenId'>
        /// The Citizen ID or Momentum Id to search the record in the Core
        /// system
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<object>> GetCitizenByIdWithHttpMessagesAsync(string citizenId, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Create a Journal Note with attachment
        /// </summary>
        /// <param name='body'>
        /// The requestmodel to save as a journal note record, in the Core
        /// system
        /// </param>
        /// <param name='momentumCitizenId'>
        /// The MomentumCitizenID or CitizenId to Create the journal note
        /// record in the Core system
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<ProblemDetails>> CreateJournalNoteWithHttpMessagesAsync(JournalNoteRequestModel body, string momentumCitizenId, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Get Health
        /// </summary>
        /// <remarks>
        /// Provides an indication about the health of the API
        /// </remarks>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<HealthReport>> HealthReadyWithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Get Health
        /// </summary>
        /// <remarks>
        /// Provides an indication about the health of the API
        /// </remarks>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<HealthReport>> HealthLiveWithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Update Status
        /// </summary>
        /// <param name='body'>
        /// The request model to update task in the Core system
        /// </param>
        /// <param name='taskId'>
        /// The TaskId to update the task in the Core system
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<object>> UpdateTaskStatusWithHttpMessagesAsync(TaskUpdateStatus body, string taskId, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

    }
}
