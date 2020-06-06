using Newtonsoft.Json.Linq;
using System;

namespace Kmd.Momentum.Mea
{
    public interface IFilterData
    {
        JToken ScrambleData(JToken result, Type type);
    }
}
