using Kmd.Momentum.Mea.Common.Modules;
using Kmd.Momentum.Mea.MeaHttpClientHelper;
using Kmd.Momentum.Mea.TaskApi;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kmd.Momentum.Mea.Modules
{
    public class ServiceConfiguration : IServiceConfiguration
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<ITaskHttpClientHelper, TaskHttpClientHelper>();
        }
    }
}
