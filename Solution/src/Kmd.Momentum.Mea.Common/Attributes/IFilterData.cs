using Newtonsoft.Json.Linq;
using System;

namespace Kmd.Momentum.Mea.Common
{
    public interface IFilterData
    {
        JToken ScrambleData(JToken result, string type);
    }
}
