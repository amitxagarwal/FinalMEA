// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Kmd.Momentum.Mea.Client.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class Reference
    {
        /// <summary>
        /// Initializes a new instance of the Reference class.
        /// </summary>
        public Reference()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Reference class.
        /// </summary>
        public Reference(string id = default(string), string type = default(string))
        {
            Id = id;
            Type = type;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

    }
}
