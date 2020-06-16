using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Linq;
using System.Threading.Tasks;
using Serilog;

namespace Kmd.Momentum.Mea.Common.Middleware
{
    public class ScrambleDataMiddleware
    {
        readonly RequestDelegate _next;

        public ScrambleDataMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public Task Invoke(HttpContext httpContext)
        {
            if (httpContext == null) throw new ArgumentNullException(nameof(httpContext));

            return InvokeInner(httpContext);
        }

        private async Task InvokeInner(HttpContext httpContext)
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

                Log.ForContext("CorrelationId", httpContext.TraceIdentifier)
                    .Debug("scramble: Status Code is " + httpContext.Response.StatusCode);

                if (httpContext.Response.StatusCode == 200)
                {
                    var responseModelTypeString = (httpContext.GetEndpoint().Metadata.GetMetadata<Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor>()).MethodInfo.ReturnType.ToString();
                    var responseModelName = GetModelName(responseModelTypeString);

                    Log.ForContext("CorrelationId", httpContext.TraceIdentifier)
                        .Debug("scramble: response Model Name is " + responseModelName);

                    var responseModelType = GetModelType(responseModelName);

                    Log.ForContext("CorrelationId", httpContext.TraceIdentifier)
                        .Debug("scramble: response Model Type " + responseModelType);

                    if (responseModelType != null)
                    {
                        var resultProperty = responseModelType.GetProperties().Where(p => p.Name == "Result").FirstOrDefault();
                        if (resultProperty != null && _obj["result"] != null && _obj["result"].Count() > 0)
                        {
                            Log.ForContext("CorrelationId", httpContext.TraceIdentifier)
                                .Debug("scramble: Result property found");

                            var _modelTypeString = resultProperty.PropertyType.ToString();
                            var _modelName = GetModelName(_modelTypeString);

                            Log.ForContext("CorrelationId", httpContext.TraceIdentifier)
                                .Debug("scramble: Model Name is " + _modelName);

                            var _modelType = GetModelType(_modelName);

                            Log.ForContext("CorrelationId", httpContext.TraceIdentifier)
                                .Debug("scramble: Model Type " + _modelType);

                            var _scrambledProperties = GetScrambledProperties(_modelType);

                            Log.ForContext("CorrelationId", httpContext.TraceIdentifier)
                                .Debug("scramble: Scrambled Properties: " + _scrambledProperties.Count());

                            var _dataArray = _obj["result"];
                            foreach (var _data in _dataArray)
                            {
                                GetScrambleData(_data, _scrambledProperties);
                            }
                        }
                        else
                        {
                            Log.ForContext("CorrelationId", httpContext.TraceIdentifier)
                                .Debug("scramble: Result property not found");

                            var _scrambledProperties = GetScrambledProperties(responseModelType);

                            Log.ForContext("CorrelationId", httpContext.TraceIdentifier)
                                .Debug("scramble: Scrambled Properties: " + _scrambledProperties.Count());

                            GetScrambleData(_obj, _scrambledProperties);
                        }
                    }
                    responseBody = JsonConvert.SerializeObject(_obj);
                }

                var memoryStreamModified = new MemoryStream();
                var sw = new StreamWriter(memoryStreamModified);
                sw.Write(responseBody);
                sw.Flush();
                memoryStreamModified.Position = 0;

                await memoryStreamModified.CopyToAsync(originBody).ConfigureAwait(false);

            }
            catch (Exception ex)
            {
                Log.ForContext("CorrelationId", httpContext.TraceIdentifier)
                .Error("An error occurred while doing scramble" + ex.Message);
            }
            finally
            {
                httpContext.Response.Body = originBody;
            }
        }

        private IReadOnlyCollection<PropertyInfo> GetScrambledProperties(Type responseModelType)
        {
            return responseModelType.GetProperties().Where(p => p.CustomAttributes.ToList().Where(q => q.AttributeType.Name == "ScrambleDataAttribute").Any()).Where(p => p.PropertyType == typeof(Guid) || p.PropertyType == typeof(string)).ToList();
        }

        private Type GetModelType(string _modelName)
        {
            return Type.GetType(_modelName + ", Kmd.Momentum.Mea");
        }

        private string GetModelName(string _string)
        {
            return _string.Split('[').Last().Trim(']');
        }

        private void GetScrambleData(JToken data, IReadOnlyCollection<PropertyInfo> attrArray)
        {
            foreach (var attr in attrArray)
            {
                var key = Char.ToLowerInvariant(attr.Name[0]) + attr.Name.Substring(1);
                if (data[key] != null)
                {
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
        }
    }
}