// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Kmd.Momentum.Mea.Client.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public partial class HealthReportEntry
    {
        /// <summary>
        /// Initializes a new instance of the HealthReportEntry class.
        /// </summary>
        public HealthReportEntry()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the HealthReportEntry class.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="description"></param>
        /// <param name="duration"></param>
        /// <param name="exception"></param>
        /// <param name="status">Possible values include: 'Unhealthy',
        /// 'Degraded', 'Healthy'</param>
        /// <param name="tags"></param>
        public HealthReportEntry(IDictionary<string, object> data = default(IDictionary<string, object>), string description = default(string), TimeSpan duration = default(TimeSpan), Exception exception = default(Exception), string status = default(string), IList<string> tags = default(IList<string>))
        {
            Data = data;
            Description = description;
            Duration = duration;
            Exception = exception;
            Status = status;
            Tags = tags;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "data")]
        public IDictionary<string, object> Data { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "duration")]
        public TimeSpan Duration { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "exception")]
        public Exception Exception { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'Unhealthy', 'Degraded',
        /// 'Healthy'
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "tags")]
        public IList<string> Tags { get; private set; }

    }
}