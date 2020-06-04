﻿using Kmd.Momentum.Mea.Attributes;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Kmd.Momentum.Mea
{
    public class FilterData : IFilterData
    {       
        public async Task<JToken> ScrambleData(JToken result, Type type)
        {
            var propertyList = type.GetProperties()
                        .Where(
                            p =>
                                p.GetCustomAttributes(typeof(ScrambleDataAttribute), true).Any()
                            )
                        .ToList();

            foreach(var item in result)
            {
                foreach (var property in propertyList)
                {
                    foreach (var customAttribute in property.CustomAttributes.ToList())
                    {
                        if (customAttribute.ConstructorArguments.FirstOrDefault(x=>x.Value.ToString() == ((JProperty)item).Name)!=null)
                        {
                            var data = ((JProperty)item).Value.ToString();
                            if (!string.IsNullOrEmpty(data) && data.Length >3)
                            {
                                data = data.Substring(0, data.Length - 3);
                                data = data + "xxx";
                                ((JProperty)item).Value = data;
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
