using JijaShop.Extensions.SettingsModel;
using Microsoft.EntityFrameworkCore;
using JijaShop.Api.Data;

namespace JijaShop.Api.Configurations
{
    public static class DataBaseConfiguration
    {
        public static IServiceCollection AddAppDbContext(this IServiceCollection services, DataBaseSettings settings = null)
        {
            services.AddDbContext<MainContext>(options =>
            {
                options.UseNpgsql(settings.ConnectionString);
            });

            return services;
        }
    }
}
