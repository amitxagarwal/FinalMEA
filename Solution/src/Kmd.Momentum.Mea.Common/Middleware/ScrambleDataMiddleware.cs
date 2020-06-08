using Kmd.Momentum.Mea.Common.Modules;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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
            try
            {
                using (Serilog.Context.LogContext.PushProperty("RequestId", httpContext.TraceIdentifier))
                {
                    await _next(httpContext).ConfigureAwait(false);
                }

                var type = httpContext.Response;
                var jsonObject = JsonConvert.DeserializeObject<JObject>(JsonConvert.DeserializeObject<string>(type.ToString()));


                foreach (var assembly in meaAssemblyDiscoverer.DiscoverScrambleDataProperties())
                {
                    
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
    }
}
