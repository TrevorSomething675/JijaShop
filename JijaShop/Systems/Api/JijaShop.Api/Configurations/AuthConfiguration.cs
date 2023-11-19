using Microsoft.AspNetCore.Authentication.JwtBearer;
using JijaShop.Api.Data.Models.AuthEntities;
using Microsoft.AspNetCore.Authorization;
using JijaShop.Extensions.SettingsModel;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using JijaShop.Api.Data;
using System.Text;

namespace JijaShop.Api.Configurations
{
    public static class AuthConfiguration
    {
        public static IServiceCollection AddAppAuth(this IServiceCollection services, AuthSettings identitySettings)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(jwt =>
                {
                    jwt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = identitySettings.Issuer,
                        ValidAudience = identitySettings.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(identitySettings.SecretKeyForToken))
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
                .AddSignInManager<SignInManager<User>>()
                .AddDefaultTokenProviders();

            return services;
        }

        public static void UseAppAuth(this WebApplication app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}