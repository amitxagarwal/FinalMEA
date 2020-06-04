using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Kmd.Momentum.Mea.Common.Attributes
{
    public class PropertyDiscoverer : IPropertyDiscoverer
    {
        public IReadOnlyCollection<PropertyAttributes> Properties { get; }

        public PropertyDiscoverer(IEnumerable<PropertyAttributes> properties)
        {
            Properties = properties.ToArray();
        }

        /// <summary>
        /// Discovers all types decorated with the DocumentMappable attribute
        /// </summary>
        public IReadOnlyCollection<Type> DiscoverPropertiesDecoratedWithAttributeScramble() => Properties
           .Select(x => x.GetType())
           .Where(x => x.GetCustomAttribute<ScrambleDataAttribute>() != null)
           .ToList();        
    }
}
