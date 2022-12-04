using Webshop.DAL.Configurations;
using Webshop.DAL.Configurations.Implementations;
using Webshop.DAL.Configurations.Interfaces;

namespace Webshop.API.Extensions
{
    public static class ConfigurationExtension
    {
        public static void AddConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<WebshopConfiguration>(configuration.GetSection("WebshopApplication"));
            services.AddTransient<IWebshopConfigurationService, WebshopConfigurationService>();
        }
    }
}
