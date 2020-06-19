using System;

namespace Kmd.Momentum.Mea.Common.Attributes
{

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class ScrambleDataAttribute : Attribute
    {
        public ScrambleDataAttribute()
        {
        }
    }
}
