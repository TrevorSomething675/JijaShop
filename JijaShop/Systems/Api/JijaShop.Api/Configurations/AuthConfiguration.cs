using JijaShop.Services.Settings.SettingsModel;

namespace JijaShop.Api.Configurations
{
    public static class AuthConfiguration
    {
        public static IServiceCollection AddAppAuth(this IServiceCollection services, IdentitySettings identitySettings)
        {
            services.AddAuthentication();

            return services;
        }

        public static void UseAppAuth(this WebApplication app)
        {
            app.UseAuthorization();
            app.UseAuthentication();
        }
    }
}