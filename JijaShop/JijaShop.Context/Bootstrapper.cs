using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using JijaShop.Context.Factories;
using JijaShop.Context.Settings;

namespace JijaShop.Context
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddAppDbContext(this IServiceCollection services, IConfiguration configuration = null)
        {
            var settings = JijaShop.Settings.Settings.Load<DataBaseSettings>("Database", configuration);
            services.AddSingleton(settings);

            var dbInitOptionsDelegate = DbContextOptionsFactory.Configure(
                settings.ConnectionString,
                settings.Type);

            services.AddDbContextFactory<Api.Data.MainContext>(dbInitOptionsDelegate);

            return services;
        }
    }
}
