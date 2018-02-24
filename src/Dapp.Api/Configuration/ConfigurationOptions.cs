using Dapp.Api.Configuration.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dapp.Api.Configuration
{
    public static class ConfigurationOptions
    {
        /// <summary>
        /// Configures the service.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        public static void ConfigureService(IServiceCollection services, IConfigurationRoot configuration)
        {
            services.Configure<ConnectionSettings>(configuration.GetSection("ConnectionStrings"));
        }
    }
}
