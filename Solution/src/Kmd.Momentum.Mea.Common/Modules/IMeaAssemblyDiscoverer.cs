using Kmd.Momentum.Mea.Common.Attributes;
using Kmd.Momentum.Mea.Common.DatabaseStore;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Kmd.Momentum.Mea.Common.Modules
{
    public interface IMeaAssemblyDiscoverer : IDocumentStoreAssemblyDiscoverer
    {
        IReadOnlyCollection<(Type type, IReadOnlyCollection<PropertyInfo> attr)> DiscoverScrambleDataProperties();

        IReadOnlyCollection<PropertyInfo> DiscoverScrambleDataProperties(string assembly);

    }
}
