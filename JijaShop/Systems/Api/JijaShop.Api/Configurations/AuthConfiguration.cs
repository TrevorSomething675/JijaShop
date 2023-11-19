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
        public static IServiceCollection AddAppAuth(this IServiceCollection services, AuthSettings authSettings)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = authSettings.Issuer,
                    ValidAudience = authSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authSettings.Key))
                };
            });

            services.AddAuthorization(
                options =>
                options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser().Build());

            services.AddIdentity<User, IdentityRole<int>>()
                .AddEntityFrameworkStores<MainContext>()
                .AddUserManager<UserManager<User>>()
                .AddSignInManager<SignInManager<User>>();


            return services;
        }

        public static void UseAppAuth(this WebApplication app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}