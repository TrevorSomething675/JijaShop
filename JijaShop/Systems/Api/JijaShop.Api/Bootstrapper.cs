using JijaShop.Services.Settings;

namespace JijaShop.Api
{
    public static class Bootstrapper
    {
        public static IServiceCollection RegisterAppServices(this IServiceCollection services)
        {
            services.AddMainSettings().
                AddIdentitySettings().
                AddSwaggerSettings();

            return services;
        }
    }
}
