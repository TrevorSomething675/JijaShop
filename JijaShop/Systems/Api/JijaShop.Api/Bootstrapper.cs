using JijaShop.Api.Repositories.Abstractions;
using JijaShop.Api.Services.Abstractions;
using JijaShop.Api.Repositories;
using JijaShop.Api.Services;
using JijaShop.Extentions;

namespace JijaShop.Api
{
    public static class Bootstrapper
    {
        public static IServiceCollection RegisterAppServices(this IServiceCollection services)
        {
            services.AddMainSettings().
                AddIdentitySettings().
                AddSwaggerSettings().
                AddScoped<IHashService, HashService>().
                AddScoped<IUserService, UserService>().
                AddScoped<ITokenService, TokenService>().
                AddScoped<IProductService, ProductService>().
                AddScoped<IIdentityService, IdentityService>().
                AddScoped<IProductCartService, ProductCartService>().
                AddScoped<IProductFavoritesService, ProductFavoritesService>();

            return services;
        }

        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductFavoritesRepository, ProductFavoritesRepository>();
            services.AddScoped<IProductCartRepository, ProductCartRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IRolesRepository, RolesRepository>();
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
