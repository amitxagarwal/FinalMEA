// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Kmd.Momentum.Mea.Client.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class CustomAttributeNamedArgument
    {
        /// <summary>
        /// Initializes a new instance of the CustomAttributeNamedArgument
        /// class.
        /// </summary>
        public CustomAttributeNamedArgument()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the CustomAttributeNamedArgument
        /// class.
        /// </summary>
        public CustomAttributeNamedArgument(MemberInfo memberInfo = default(MemberInfo), CustomAttributeTypedArgument typedValue = default(CustomAttributeTypedArgument), string memberName = default(string), bool? isField = default(bool?))
        {
            MemberInfo = memberInfo;
            TypedValue = typedValue;
            MemberName = memberName;
            IsField = isField;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "memberInfo")]
        public MemberInfo MemberInfo { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "typedValue")]
        public CustomAttributeTypedArgument TypedValue { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "memberName")]
        public string MemberName { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isField")]
        public bool? IsField { get; private set; }

    }
}
