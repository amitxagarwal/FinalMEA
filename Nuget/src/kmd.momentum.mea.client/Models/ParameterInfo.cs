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

    public partial class ParameterInfo
    {
        /// <summary>
        /// Initializes a new instance of the ParameterInfo class.
        /// </summary>
        public ParameterInfo()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ParameterInfo class.
        /// </summary>
        /// <param name="attributes">Possible values include: 'None', 'In',
        /// 'Out', 'Lcid', 'Retval', 'Optional', 'HasDefault',
        /// 'HasFieldMarshal', 'Reserved3', 'Reserved4', 'ReservedMask'</param>
        public ParameterInfo(string attributes = default(string), MemberInfo member = default(MemberInfo), string name = default(string), Type parameterType = default(Type), int? position = default(int?), bool? isIn = default(bool?), bool? isLcid = default(bool?), bool? isOptional = default(bool?), bool? isOut = default(bool?), bool? isRetval = default(bool?), object defaultValue = default(object), object rawDefaultValue = default(object), bool? hasDefaultValue = default(bool?), IList<CustomAttributeData> customAttributes = default(IList<CustomAttributeData>), int? metadataToken = default(int?))
        {
            Attributes = attributes;
            Member = member;
            Name = name;
            ParameterType = parameterType;
            Position = position;
            IsIn = isIn;
            IsLcid = isLcid;
            IsOptional = isOptional;
            IsOut = isOut;
            IsRetval = isRetval;
            DefaultValue = defaultValue;
            RawDefaultValue = rawDefaultValue;
            HasDefaultValue = hasDefaultValue;
            CustomAttributes = customAttributes;
            MetadataToken = metadataToken;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets possible values include: 'None', 'In', 'Out', 'Lcid',
        /// 'Retval', 'Optional', 'HasDefault', 'HasFieldMarshal', 'Reserved3',
        /// 'Reserved4', 'ReservedMask'
        /// </summary>
        [JsonProperty(PropertyName = "attributes")]
        public string Attributes { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "member")]
        public MemberInfo Member { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "parameterType")]
        public Type ParameterType { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "position")]
        public int? Position { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isIn")]
        public bool? IsIn { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isLcid")]
        public bool? IsLcid { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isOptional")]
        public bool? IsOptional { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isOut")]
        public bool? IsOut { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isRetval")]
        public bool? IsRetval { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "defaultValue")]
        public object DefaultValue { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "rawDefaultValue")]
        public object RawDefaultValue { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "hasDefaultValue")]
        public bool? HasDefaultValue { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "customAttributes")]
        public IList<CustomAttributeData> CustomAttributes { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "metadataToken")]
        public int? MetadataToken { get; private set; }

    }
}
