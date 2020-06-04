using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kmd.Momentum.Mea
{
    public interface IFilterData
    {
        Task<JToken> ScrambleData(JToken result, Type type);
    }
}
