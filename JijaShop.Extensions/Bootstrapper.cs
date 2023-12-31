﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using JijaShop.Extensions.SettingsModel;

namespace JijaShop.Extentions
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddMainSettings(this IServiceCollection services, IConfiguration configuration = null)
        {
            var settings = Settings.Load<MainSettings>("Main", configuration);
            services.AddSingleton(settings);

            return services;
        }

        public static IServiceCollection AddIdentitySettings(this IServiceCollection services, IConfiguration configuration = null)
        {
            var settings = Settings.Load<AuthSettings>("Identity", configuration);
            services.AddSingleton(settings);

            return services;
        }

        public static IServiceCollection AddSwaggerSettings(this IServiceCollection services, IConfiguration configuration = null)
        {
            var settings = Settings.Load<SwaggerSettings>("Swagger", configuration);
            services.AddSingleton(settings);

            return services;
        }
    }
}
