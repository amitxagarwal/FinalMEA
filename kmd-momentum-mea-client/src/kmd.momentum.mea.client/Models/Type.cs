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

    public partial class Type
    {
        /// <summary>
        /// Initializes a new instance of the Type class.
        /// </summary>
        public Type()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Type class.
        /// </summary>
        /// <param name="isInterface"></param>
        /// <param name="memberType">Possible values include: 'Constructor',
        /// 'Event', 'Field', 'Method', 'Property', 'TypeInfo', 'Custom',
        /// 'NestedType', 'All'</param>
        /// <param name="namespaceProperty"></param>
        /// <param name="assemblyQualifiedName"></param>
        /// <param name="fullName"></param>
        /// <param name="assembly"></param>
        /// <param name="module"></param>
        /// <param name="isNested"></param>
        /// <param name="declaringType"></param>
        /// <param name="declaringMethod"></param>
        /// <param name="reflectedType"></param>
        /// <param name="underlyingSystemType"></param>
        /// <param name="isTypeDefinition"></param>
        /// <param name="isArray"></param>
        /// <param name="isByRef"></param>
        /// <param name="isPointer"></param>
        /// <param name="isConstructedGenericType"></param>
        /// <param name="isGenericParameter"></param>
        /// <param name="isGenericTypeParameter"></param>
        /// <param name="isGenericMethodParameter"></param>
        /// <param name="isGenericType"></param>
        /// <param name="isGenericTypeDefinition"></param>
        /// <param name="isSZArray"></param>
        /// <param name="isVariableBoundArray"></param>
        /// <param name="isByRefLike"></param>
        /// <param name="hasElementType"></param>
        /// <param name="genericTypeArguments"></param>
        /// <param name="genericParameterPosition"></param>
        /// <param name="genericParameterAttributes">Possible values include:
        /// 'None', 'Covariant', 'Contravariant', 'VarianceMask',
        /// 'ReferenceTypeConstraint', 'NotNullableValueTypeConstraint',
        /// 'DefaultConstructorConstraint', 'SpecialConstraintMask'</param>
        /// <param name="attributes">Possible values include: 'NotPublic',
        /// 'NotPublic', 'NotPublic', 'NotPublic', 'Public', 'NestedPublic',
        /// 'NestedPrivate', 'NestedFamily', 'NestedAssembly',
        /// 'NestedFamANDAssem', 'VisibilityMask', 'VisibilityMask',
        /// 'SequentialLayout', 'ExplicitLayout', 'LayoutMask',
        /// 'ClassSemanticsMask', 'ClassSemanticsMask', 'Abstract', 'Sealed',
        /// 'SpecialName', 'RTSpecialName', 'Import', 'Serializable',
        /// 'WindowsRuntime', 'UnicodeClass', 'AutoClass', 'StringFormatMask',
        /// 'StringFormatMask', 'HasSecurity', 'ReservedMask',
        /// 'BeforeFieldInit', 'CustomFormatMask'</param>
        /// <param name="isAbstract"></param>
        /// <param name="isImport"></param>
        /// <param name="isSealed"></param>
        /// <param name="isSpecialName"></param>
        /// <param name="isClass"></param>
        /// <param name="isNestedAssembly"></param>
        /// <param name="isNestedFamANDAssem"></param>
        /// <param name="isNestedFamily"></param>
        /// <param name="isNestedFamORAssem"></param>
        /// <param name="isNestedPrivate"></param>
        /// <param name="isNestedPublic"></param>
        /// <param name="isNotPublic"></param>
        /// <param name="isPublic"></param>
        /// <param name="isAutoLayout"></param>
        /// <param name="isExplicitLayout"></param>
        /// <param name="isLayoutSequential"></param>
        /// <param name="isAnsiClass"></param>
        /// <param name="isAutoClass"></param>
        /// <param name="isUnicodeClass"></param>
        /// <param name="isCOMObject"></param>
        /// <param name="isContextful"></param>
        /// <param name="isEnum"></param>
        /// <param name="isMarshalByRef"></param>
        /// <param name="isPrimitive"></param>
        /// <param name="isValueType"></param>
        /// <param name="isSignatureType"></param>
        /// <param name="isSecurityCritical"></param>
        /// <param name="isSecuritySafeCritical"></param>
        /// <param name="isSecurityTransparent"></param>
        /// <param name="structLayoutAttribute"></param>
        /// <param name="typeInitializer"></param>
        /// <param name="typeHandle"></param>
        /// <param name="guid"></param>
        /// <param name="baseType"></param>
        /// <param name="isSerializable"></param>
        /// <param name="containsGenericParameters"></param>
        /// <param name="isVisible"></param>
        /// <param name="name"></param>
        /// <param name="customAttributes"></param>
        /// <param name="isCollectible"></param>
        /// <param name="metadataToken"></param>
        public Type(bool? isInterface = default(bool?), string memberType = default(string), string namespaceProperty = default(string), string assemblyQualifiedName = default(string), string fullName = default(string), Assembly assembly = default(Assembly), Module module = default(Module), bool? isNested = default(bool?), Type declaringType = default(Type), MethodBase declaringMethod = default(MethodBase), Type reflectedType = default(Type), Type underlyingSystemType = default(Type), bool? isTypeDefinition = default(bool?), bool? isArray = default(bool?), bool? isByRef = default(bool?), bool? isPointer = default(bool?), bool? isConstructedGenericType = default(bool?), bool? isGenericParameter = default(bool?), bool? isGenericTypeParameter = default(bool?), bool? isGenericMethodParameter = default(bool?), bool? isGenericType = default(bool?), bool? isGenericTypeDefinition = default(bool?), bool? isSZArray = default(bool?), bool? isVariableBoundArray = default(bool?), bool? isByRefLike = default(bool?), bool? hasElementType = default(bool?), IList<Type> genericTypeArguments = default(IList<Type>), int? genericParameterPosition = default(int?), string genericParameterAttributes = default(string), string attributes = default(string), bool? isAbstract = default(bool?), bool? isImport = default(bool?), bool? isSealed = default(bool?), bool? isSpecialName = default(bool?), bool? isClass = default(bool?), bool? isNestedAssembly = default(bool?), bool? isNestedFamANDAssem = default(bool?), bool? isNestedFamily = default(bool?), bool? isNestedFamORAssem = default(bool?), bool? isNestedPrivate = default(bool?), bool? isNestedPublic = default(bool?), bool? isNotPublic = default(bool?), bool? isPublic = default(bool?), bool? isAutoLayout = default(bool?), bool? isExplicitLayout = default(bool?), bool? isLayoutSequential = default(bool?), bool? isAnsiClass = default(bool?), bool? isAutoClass = default(bool?), bool? isUnicodeClass = default(bool?), bool? isCOMObject = default(bool?), bool? isContextful = default(bool?), bool? isEnum = default(bool?), bool? isMarshalByRef = default(bool?), bool? isPrimitive = default(bool?), bool? isValueType = default(bool?), bool? isSignatureType = default(bool?), bool? isSecurityCritical = default(bool?), bool? isSecuritySafeCritical = default(bool?), bool? isSecurityTransparent = default(bool?), StructLayoutAttribute structLayoutAttribute = default(StructLayoutAttribute), ConstructorInfo typeInitializer = default(ConstructorInfo), RuntimeTypeHandle typeHandle = default(RuntimeTypeHandle), System.Guid? guid = default(System.Guid?), Type baseType = default(Type), bool? isSerializable = default(bool?), bool? containsGenericParameters = default(bool?), bool? isVisible = default(bool?), string name = default(string), IList<CustomAttributeData> customAttributes = default(IList<CustomAttributeData>), bool? isCollectible = default(bool?), int? metadataToken = default(int?))
        {
            IsInterface = isInterface;
            MemberType = memberType;
            NamespaceProperty = namespaceProperty;
            AssemblyQualifiedName = assemblyQualifiedName;
            FullName = fullName;
            Assembly = assembly;
            Module = module;
            IsNested = isNested;
            DeclaringType = declaringType;
            DeclaringMethod = declaringMethod;
            ReflectedType = reflectedType;
            UnderlyingSystemType = underlyingSystemType;
            IsTypeDefinition = isTypeDefinition;
            IsArray = isArray;
            IsByRef = isByRef;
            IsPointer = isPointer;
            IsConstructedGenericType = isConstructedGenericType;
            IsGenericParameter = isGenericParameter;
            IsGenericTypeParameter = isGenericTypeParameter;
            IsGenericMethodParameter = isGenericMethodParameter;
            IsGenericType = isGenericType;
            IsGenericTypeDefinition = isGenericTypeDefinition;
            IsSZArray = isSZArray;
            IsVariableBoundArray = isVariableBoundArray;
            IsByRefLike = isByRefLike;
            HasElementType = hasElementType;
            GenericTypeArguments = genericTypeArguments;
            GenericParameterPosition = genericParameterPosition;
            GenericParameterAttributes = genericParameterAttributes;
            Attributes = attributes;
            IsAbstract = isAbstract;
            IsImport = isImport;
            IsSealed = isSealed;
            IsSpecialName = isSpecialName;
            IsClass = isClass;
            IsNestedAssembly = isNestedAssembly;
            IsNestedFamANDAssem = isNestedFamANDAssem;
            IsNestedFamily = isNestedFamily;
            IsNestedFamORAssem = isNestedFamORAssem;
            IsNestedPrivate = isNestedPrivate;
            IsNestedPublic = isNestedPublic;
            IsNotPublic = isNotPublic;
            IsPublic = isPublic;
            IsAutoLayout = isAutoLayout;
            IsExplicitLayout = isExplicitLayout;
            IsLayoutSequential = isLayoutSequential;
            IsAnsiClass = isAnsiClass;
            IsAutoClass = isAutoClass;
            IsUnicodeClass = isUnicodeClass;
            IsCOMObject = isCOMObject;
            IsContextful = isContextful;
            IsEnum = isEnum;
            IsMarshalByRef = isMarshalByRef;
            IsPrimitive = isPrimitive;
            IsValueType = isValueType;
            IsSignatureType = isSignatureType;
            IsSecurityCritical = isSecurityCritical;
            IsSecuritySafeCritical = isSecuritySafeCritical;
            IsSecurityTransparent = isSecurityTransparent;
            StructLayoutAttribute = structLayoutAttribute;
            TypeInitializer = typeInitializer;
            TypeHandle = typeHandle;
            Guid = guid;
            BaseType = baseType;
            IsSerializable = isSerializable;
            ContainsGenericParameters = containsGenericParameters;
            IsVisible = isVisible;
            Name = name;
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
        /// </summary>
        [JsonProperty(PropertyName = "isInterface")]
        public bool? IsInterface { get; private set; }

        /// <summary>
        /// Gets or sets possible values include: 'Constructor', 'Event',
        /// 'Field', 'Method', 'Property', 'TypeInfo', 'Custom', 'NestedType',
        /// 'All'
        /// </summary>
        [JsonProperty(PropertyName = "memberType")]
        public string MemberType { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "namespace")]
        public string NamespaceProperty { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "assemblyQualifiedName")]
        public string AssemblyQualifiedName { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "fullName")]
        public string FullName { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "assembly")]
        public Assembly Assembly { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "module")]
        public Module Module { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isNested")]
        public bool? IsNested { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "declaringType")]
        public Type DeclaringType { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "declaringMethod")]
        public MethodBase DeclaringMethod { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "reflectedType")]
        public Type ReflectedType { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "underlyingSystemType")]
        public Type UnderlyingSystemType { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isTypeDefinition")]
        public bool? IsTypeDefinition { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isArray")]
        public bool? IsArray { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isByRef")]
        public bool? IsByRef { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isPointer")]
        public bool? IsPointer { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isConstructedGenericType")]
        public bool? IsConstructedGenericType { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isGenericParameter")]
        public bool? IsGenericParameter { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isGenericTypeParameter")]
        public bool? IsGenericTypeParameter { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isGenericMethodParameter")]
        public bool? IsGenericMethodParameter { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isGenericType")]
        public bool? IsGenericType { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isGenericTypeDefinition")]
        public bool? IsGenericTypeDefinition { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isSZArray")]
        public bool? IsSZArray { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isVariableBoundArray")]
        public bool? IsVariableBoundArray { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isByRefLike")]
        public bool? IsByRefLike { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "hasElementType")]
        public bool? HasElementType { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "genericTypeArguments")]
        public IList<Type> GenericTypeArguments { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "genericParameterPosition")]
        public int? GenericParameterPosition { get; private set; }

        /// <summary>
        /// Gets or sets possible values include: 'None', 'Covariant',
        /// 'Contravariant', 'VarianceMask', 'ReferenceTypeConstraint',
        /// 'NotNullableValueTypeConstraint', 'DefaultConstructorConstraint',
        /// 'SpecialConstraintMask'
        /// </summary>
        [JsonProperty(PropertyName = "genericParameterAttributes")]
        public string GenericParameterAttributes { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'NotPublic', 'NotPublic',
        /// 'NotPublic', 'NotPublic', 'Public', 'NestedPublic',
        /// 'NestedPrivate', 'NestedFamily', 'NestedAssembly',
        /// 'NestedFamANDAssem', 'VisibilityMask', 'VisibilityMask',
        /// 'SequentialLayout', 'ExplicitLayout', 'LayoutMask',
        /// 'ClassSemanticsMask', 'ClassSemanticsMask', 'Abstract', 'Sealed',
        /// 'SpecialName', 'RTSpecialName', 'Import', 'Serializable',
        /// 'WindowsRuntime', 'UnicodeClass', 'AutoClass', 'StringFormatMask',
        /// 'StringFormatMask', 'HasSecurity', 'ReservedMask',
        /// 'BeforeFieldInit', 'CustomFormatMask'
        /// </summary>
        [JsonProperty(PropertyName = "attributes")]
        public string Attributes { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isAbstract")]
        public bool? IsAbstract { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isImport")]
        public bool? IsImport { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isSealed")]
        public bool? IsSealed { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isSpecialName")]
        public bool? IsSpecialName { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isClass")]
        public bool? IsClass { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isNestedAssembly")]
        public bool? IsNestedAssembly { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isNestedFamANDAssem")]
        public bool? IsNestedFamANDAssem { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isNestedFamily")]
        public bool? IsNestedFamily { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isNestedFamORAssem")]
        public bool? IsNestedFamORAssem { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isNestedPrivate")]
        public bool? IsNestedPrivate { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isNestedPublic")]
        public bool? IsNestedPublic { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isNotPublic")]
        public bool? IsNotPublic { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isPublic")]
        public bool? IsPublic { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isAutoLayout")]
        public bool? IsAutoLayout { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isExplicitLayout")]
        public bool? IsExplicitLayout { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isLayoutSequential")]
        public bool? IsLayoutSequential { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isAnsiClass")]
        public bool? IsAnsiClass { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isAutoClass")]
        public bool? IsAutoClass { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isUnicodeClass")]
        public bool? IsUnicodeClass { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isCOMObject")]
        public bool? IsCOMObject { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isContextful")]
        public bool? IsContextful { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isEnum")]
        public bool? IsEnum { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isMarshalByRef")]
        public bool? IsMarshalByRef { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isPrimitive")]
        public bool? IsPrimitive { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isValueType")]
        public bool? IsValueType { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isSignatureType")]
        public bool? IsSignatureType { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isSecurityCritical")]
        public bool? IsSecurityCritical { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isSecuritySafeCritical")]
        public bool? IsSecuritySafeCritical { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isSecurityTransparent")]
        public bool? IsSecurityTransparent { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "structLayoutAttribute")]
        public StructLayoutAttribute StructLayoutAttribute { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "typeInitializer")]
        public ConstructorInfo TypeInitializer { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "typeHandle")]
        public RuntimeTypeHandle TypeHandle { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "guid")]
        public System.Guid? Guid { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "baseType")]
        public Type BaseType { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isSerializable")]
        public bool? IsSerializable { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "containsGenericParameters")]
        public bool? ContainsGenericParameters { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isVisible")]
        public bool? IsVisible { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; private set; }

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
