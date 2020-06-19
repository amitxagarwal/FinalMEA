using Kmd.Momentum.Mea.Common.Modules;
using Kmd.Momentum.Mea.MeaHttpClientHelper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kmd.Momentum.Mea.Caseworker.Modules
{
    public class ServiceConfiguration : IServiceConfiguration
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICaseworkerService, CaseworkerService>();
            services.AddScoped<ICaseworkerHttpClientHelper, CaseworkerHttpClientHelper>();
        }
    }
}
