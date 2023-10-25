using Microsoft.AspNetCore.Authentication.JwtBearer;
using JijaShop.Api.Data.Models.AuthEntities;
using Microsoft.AspNetCore.Authorization;
using JijaShop.Extentions.SettingsModel;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using JijaShop.Api.Data;
using System.Text;

namespace JijaShop.Api.Configurations
{
    public static class AuthConfiguration
    {
        public static IServiceCollection AddAppAuth(this IServiceCollection services, IdentitySettings identitySettings)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddCookie()
                .AddJwtBearer(jwt =>
                {
                    jwt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = identitySettings.Issuer,
                        ValidAudience = identitySettings.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(identitySettings.SecretKeyForToken))
                    };
                    jwt.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            context.Token = context.Request.Cookies["Token"];
                            return Task.CompletedTask;
                        }
                    };
                });

            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build();
            });

            services.AddIdentity<User, IdentityRole<int>>()
                .AddEntityFrameworkStores<MainContext>()
                .AddUserManager<UserManager<User>>()
                .AddSignInManager<SignInManager<User>>();

            return services;
        }

        public static void UseAppAuth(this WebApplication app)
        {
            app.UseAuthorization();
            app.UseAuthentication();
        }
    }
}