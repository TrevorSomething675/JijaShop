using JijaShop.Api.Repositories.Abstractions;
using JijaShop.Api.Repositories;
using JijaShop.Services.Settings;
using JijaShop.Api.Services.Abstractions;
using JijaShop.Api.Services;

namespace JijaShop.Api
{
    public static class Bootstrapper
    {
        public static IServiceCollection RegisterAppServices(this IServiceCollection services)
        {
            services.AddMainSettings().
                AddIdentitySettings().
                AddSwaggerSettings().
                AddScoped<IUserService, UserService>().
                AddScoped<IProductService, ProductService>().
                AddScoped<IIdentityService, IdentityService>();

            return services;
        }

        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }

        public static void MapAppAreaControllerRoute(this WebApplication app)
        {
            app.MapAreaControllerRoute(
                name: "User_area",
                areaName: "UserArea",
                pattern: "{area:exists}/{controller=Home}/{action=Index}");

            app.MapAreaControllerRoute(
                name: "Moderator_area",
                areaName: "Moderator",
                pattern: "Moderator/{controller=Home}/{action=Index}");

            app.MapAreaControllerRoute(
                name: "Admin_area",
                areaName: "Admin",
                pattern: "Admin/{controller=Home}/{action=Index}");
        }
    }
}
