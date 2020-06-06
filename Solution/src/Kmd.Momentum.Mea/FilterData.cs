using Kmd.Momentum.Mea.Attributes;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace Kmd.Momentum.Mea
{
    public class FilterData : IFilterData
    {
        public JToken ScrambleData(JToken result, Type type)
        {
            var propertyList = type.GetProperties()
                        .Where(
                            p =>
                                p.GetCustomAttributes(typeof(ScrambleDataAttribute), true).Any()
                            )
                        .ToList();

            foreach (var item in result)
            {
                foreach (var property in propertyList)
                {
                    foreach (var customAttribute in property.CustomAttributes.ToList())
                    {
                        if (property.Name.ToLower() == ((JProperty)item).Name.ToLower())
                        {
                            var data = ((JProperty)item).Value.ToString();
                            if (!string.IsNullOrEmpty(data) && data.Length > 3)
                            {
                                data = data.Substring(0, data.Length - 3);
                                data = data + "FFF";
                                if(property.Name.ToLower() == "caseworkerid")
                                {
                                    Guid Id = new Guid(data);
                                    ((JProperty)item).Value = Id;
                                }
                                else
                                {
                                    ((JProperty)item).Value = data;
                                }

                                break;
                            }
                        }

                    }

                }
            }

            return result;
        }
    }
}
