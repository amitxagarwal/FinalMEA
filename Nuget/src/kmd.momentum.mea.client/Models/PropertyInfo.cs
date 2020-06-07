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

    public partial class PropertyInfo
    {
        /// <summary>
        /// Initializes a new instance of the PropertyInfo class.
        /// </summary>
        public PropertyInfo()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the PropertyInfo class.
        /// </summary>
        /// <param name="memberType">Possible values include: 'Constructor',
        /// 'Event', 'Field', 'Method', 'Property', 'TypeInfo', 'Custom',
        /// 'NestedType', 'All'</param>
        /// <param name="propertyType"></param>
        /// <param name="attributes">Possible values include: 'None',
        /// 'SpecialName', 'RTSpecialName', 'HasDefault', 'Reserved2',
        /// 'Reserved3', 'Reserved4', 'ReservedMask'</param>
        /// <param name="isSpecialName"></param>
        /// <param name="canRead"></param>
        /// <param name="canWrite"></param>
        /// <param name="getMethod"></param>
        /// <param name="setMethod"></param>
        /// <param name="name"></param>
        /// <param name="declaringType"></param>
        /// <param name="reflectedType"></param>
        /// <param name="module"></param>
        /// <param name="customAttributes"></param>
        /// <param name="isCollectible"></param>
        /// <param name="metadataToken"></param>
        public PropertyInfo(string memberType = default(string), Type propertyType = default(Type), string attributes = default(string), bool? isSpecialName = default(bool?), bool? canRead = default(bool?), bool? canWrite = default(bool?), MethodInfo getMethod = default(MethodInfo), MethodInfo setMethod = default(MethodInfo), string name = default(string), Type declaringType = default(Type), Type reflectedType = default(Type), Module module = default(Module), IList<CustomAttributeData> customAttributes = default(IList<CustomAttributeData>), bool? isCollectible = default(bool?), int? metadataToken = default(int?))
        {
            MemberType = memberType;
            PropertyType = propertyType;
            Attributes = attributes;
            IsSpecialName = isSpecialName;
            CanRead = canRead;
            CanWrite = canWrite;
            GetMethod = getMethod;
            SetMethod = setMethod;
            Name = name;
            DeclaringType = declaringType;
            ReflectedType = reflectedType;
            Module = module;
            CustomAttributes = customAttributes;
            IsCollectible = isCollectible;
            MetadataToken = metadataToken;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets possible values include: 'Constructor', 'Event',
        /// 'Field', 'Method', 'Property', 'TypeInfo', 'Custom', 'NestedType',
        /// 'All'
        /// </summary>
        [JsonProperty(PropertyName = "memberType")]
        public string MemberType { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "propertyType")]
        public Type PropertyType { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'None', 'SpecialName',
        /// 'RTSpecialName', 'HasDefault', 'Reserved2', 'Reserved3',
        /// 'Reserved4', 'ReservedMask'
        /// </summary>
        [JsonProperty(PropertyName = "attributes")]
        public string Attributes { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isSpecialName")]
        public bool? IsSpecialName { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "canRead")]
        public bool? CanRead { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "canWrite")]
        public bool? CanWrite { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "getMethod")]
        public MethodInfo GetMethod { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "setMethod")]
        public MethodInfo SetMethod { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "declaringType")]
        public Type DeclaringType { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "reflectedType")]
        public Type ReflectedType { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "module")]
        public Module Module { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "customAttributes")]
        public IList<CustomAttributeData> CustomAttributes { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isCollectible")]
        public bool? IsCollectible { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "metadataToken")]
        public int? MetadataToken { get; private set; }

    }
}
