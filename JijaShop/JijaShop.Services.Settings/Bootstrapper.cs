using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace JijaShop.Services.Settings
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddMainSettings(this IServiceCollection services, IConfiguration configuration = null)
        {
            var settings = JijaShop.Settings.Settings.Load<MainSettings>("Main", configuration);
            services.AddSingleton(settings);

            return services;
        }

        public static IServiceCollection AddIdentitySettings(this IServiceCollection services, IConfiguration configuration = null)
        {
            var settings = JijaShop.Settings.Settings.Load<IdentitySettings>("Identity", configuration);
            services.AddSingleton(settings);

            return services;
        }

        public static IServiceCollection AddSwaggerSettings(this IServiceCollection services, IConfiguration configuration = null)
        {
            var settings = JijaShop.Settings.Settings.Load<SwaggerSettings>("Swagger", configuration);
            services.AddSingleton(settings);

            return services;
        }
    }
}
