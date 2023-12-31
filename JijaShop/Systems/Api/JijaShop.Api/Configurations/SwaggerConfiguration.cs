﻿using Microsoft.AspNetCore.Mvc.Controllers;
using JijaShop.Extensions.SettingsModel;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace JijaShop.Api.Configurations
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection AddAppSwagger(this IServiceCollection services, SwaggerSettings settings)
        {
            if(!settings?.Enabled ?? false)
                return services;

            services.AddSwaggerGen(options => 
            {
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "Standart Authorization",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                options.OperationFilter<SecurityRequirementsOperationFilter>();
            });

            return services;
        }

        public static void UseAppSwagger(this WebApplication app, SwaggerSettings settings)
        {
            if (!settings?.Enabled ?? false)
                return;

            app.UseSwagger();

            app.UseSwaggerUI();
        }
    }
}
