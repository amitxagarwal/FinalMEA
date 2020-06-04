using System;
using System.Collections.Generic;
using System.Text;

namespace Kmd.Momentum.Mea.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class ScrambleDataAttribute: Attribute
    {
        public Type AsProperty { get; set; }

        public ScrambleDataAttribute()
        {
        }

        public ScrambleDataAttribute(Type asProperty)
        {
            AsProperty = asProperty;
        }
    }
}
