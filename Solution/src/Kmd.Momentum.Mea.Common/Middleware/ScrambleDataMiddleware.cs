using Kmd.Momentum.Mea.Common.Modules;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Kmd.Momentum.Mea.Common.Middleware
{
    public class ScrambleDataMiddleware
    {
        readonly RequestDelegate _next;

        public ScrambleDataMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));

        }

        public Task Invoke(HttpContext httpContext, IMeaAssemblyDiscoverer meaAssemblyDiscoverer)
        {
            if (httpContext == null) throw new ArgumentNullException(nameof(httpContext));

            return InvokeInner(httpContext, meaAssemblyDiscoverer);
        }

        private async Task InvokeInner(HttpContext httpContext, IMeaAssemblyDiscoverer meaAssemblyDiscoverer)
        {
            var originBody = httpContext.Response.Body;
            try
            {
                var responseBodyStream = new MemoryStream();

                using (Serilog.Context.LogContext.PushProperty("RequestId", httpContext.TraceIdentifier))
                {

                    httpContext.Response.Body = responseBodyStream;

                    await _next(httpContext);
                }

                responseBodyStream.Seek(0, SeekOrigin.Begin);
                var responseBody = new StreamReader(responseBodyStream).ReadToEnd();
                var _obj = JsonConvert.DeserializeObject<JToken>(responseBody);

                if (httpContext.Response.StatusCode == 200)
                {
                    var _type = (httpContext.GetEndpoint().Metadata.GetMetadata<Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor>()).MethodInfo.ReturnType.ToString();
                    var _model = _type.Split('[')[2].Trim(']');

                    switch (_model)
                    {
                        case "Kmd.Momentum.Mea.Caseworker.Model.CaseworkerList":
                            scrambleCaseworkerList(meaAssemblyDiscoverer, _obj);
                            break;
                        case "Kmd.Momentum.Mea.Citizen.Model.CitizenList":
                            scrambleCitizenList(meaAssemblyDiscoverer, _obj);
                            break;
                        case "Kmd.Momentum.Mea.TaskApi.Model.TaskList":
                            scrambleCaseworkerTaskList(meaAssemblyDiscoverer, _obj);
                            break;
                        default:
                            var _attrArray = getScrambledAssembly(meaAssemblyDiscoverer, _model);
                            getScrambleData(_obj, _attrArray);
                            break;
                    }
                }


                var memoryStreamModified = new MemoryStream();
                var sw = new StreamWriter(memoryStreamModified);
                sw.Write(JsonConvert.SerializeObject(_obj));
                sw.Flush();
                memoryStreamModified.Position = 0;

                await memoryStreamModified.CopyToAsync(originBody).ConfigureAwait(false);

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {

                httpContext.Response.Body = originBody;
            }
        }

        private void scrambleCaseworkerList(IMeaAssemblyDiscoverer meaAssemblyDiscoverer, JToken _obj)
        {
            var _attrArray = getScrambledAssembly(meaAssemblyDiscoverer, "Kmd.Momentum.Mea.Caseworker.Model.CaseworkerDataResponseModel");
            if (_attrArray.Count == 0)
            {
                return;
            }
            var _dataArray = _obj["result"];
            foreach (var _data in _dataArray)
            {
                getScrambleData(_data, _attrArray);
            }
        }

        private void scrambleCitizenList(IMeaAssemblyDiscoverer meaAssemblyDiscoverer, JToken _obj)
        {
            var _attrArray = getScrambledAssembly(meaAssemblyDiscoverer, "Kmd.Momentum.Mea.Citizen.Model.CitizenDataResponseModel");
            if (_attrArray.Count == 0)
            {
                return;
            }
            var _dataArray = _obj["result"];
            foreach (var _data in _dataArray)
            {
                getScrambleData(_data, _attrArray);
            }
        }

        private void scrambleCaseworkerTaskList(IMeaAssemblyDiscoverer meaAssemblyDiscoverer, JToken _obj)
        {
            var _attrArray = getScrambledAssembly(meaAssemblyDiscoverer, "Kmd.Momentum.Mea.TaskApi.Model.TaskDataResponseModel");
            if (_attrArray.Count == 0)
            {
                return;
            }
            var _dataArray = _obj["result"];
            foreach (var _data in _dataArray)
            {
                getScrambleData(_data, _attrArray);
            }
        }
        private void getScrambleData(JToken data, IReadOnlyCollection<PropertyInfo> attrArray)
        {
            foreach (var attr in attrArray)
            {
                var key = Char.ToLowerInvariant(attr.Name[0]) + attr.Name.Substring(1);
                var val = data[key].ToString();
                if (!string.IsNullOrEmpty(val) && val.Length > 3)
                {
                    val = val.Substring(0, val.Length - 3);
                    val = val + "AAA";

                    if (attr.PropertyType == typeof(Guid))
                    {
                        Guid Id = new Guid(val);
                        data[key] = Id;
                    }
                    else
                    {
                        data[key] = val;
                    }
                }
            }
        }

        private IReadOnlyCollection<PropertyInfo> getScrambledAssembly(IMeaAssemblyDiscoverer meaAssemblyDiscoverer, string _assemblyName)
        {
            foreach (var assembly in meaAssemblyDiscoverer.DiscoverScrambleDataProperties())
            {
                if (assembly.type.FullName.ToString() == _assemblyName)
                {
                    return assembly.attr;
                }
            }
            return new List<PropertyInfo>();
        }
    }
}
