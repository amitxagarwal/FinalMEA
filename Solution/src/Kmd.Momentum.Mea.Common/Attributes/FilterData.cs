using Kmd.Momentum.Mea.Common.Attributes;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace Kmd.Momentum.Mea.Common
{
    public class FilterData : IFilterData
    {
        public static string GetEnvironmentName() =>
           Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

        public JToken ScrambleData(JToken result, string fieldName)
        {
            if (GetEnvironmentName() == "Build")
            {
                return result;
            }



            if (fieldName.ToLower() == ((JProperty)result).Name.ToLower())
            {
                var data = ((JProperty)result).Value.ToString();

                if (!string.IsNullOrEmpty(data) && data.Length > 3)
                {
                    data = data.Substring(0, data.Length - 3);
                    data = data + "FFF";
                    ((JProperty)result).Value = data;              
                }
            }

            return result;
        }
    }
}
