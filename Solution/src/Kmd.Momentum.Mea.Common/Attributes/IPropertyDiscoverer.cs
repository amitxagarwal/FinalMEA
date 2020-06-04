using System;
using System.Collections.Generic;
using System.Text;

namespace Kmd.Momentum.Mea.Common.Attributes
{
    public interface IPropertyDiscoverer
    {
        public IReadOnlyCollection<Type> DiscoverPropertiesDecoratedWithAttributeScramble();
    }
}
