using JijaShop.Api.Configurations.AutoMapper;
using JijaShop.Extensions.SettingsModel;
using Microsoft.EntityFrameworkCore;
using JijaShop.Api.Configurations;
using JijaShop.Extentions;
using JijaShop.Api.Data;
using JijaShop.Api;
using JijaShop.Api.Data.Models.Entities;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

var swaggerSettings = Settings.Load<SwaggerSettings>("Swagger");
var dataBaseSettings = Settings.Load<DataBaseSettings>("DataBase");
var identitySettings = Settings.Load<AuthSettings>("AuthSettings");

builder.AddAppLogger();
var services = builder.Services;

services.AddHttpContextAccessor();
services.AddAppAutoMapperConfiguration();

services.AddRazorPages();
services.AddControllersWithViews();

services.AddAppDbContext(dataBaseSettings);
services.AddAppSwagger(swaggerSettings);
services.AddAppAuth(identitySettings);

services.RegisterAppServices();
services.RegisterRepositories();

var app = builder.Build();

#region testData
using (var scope = app.Services.CreateScope())
{
    using (var context = scope.ServiceProvider.GetRequiredService<MainContext>())
    {
        //List<Product> prd = new List<Product>();
        //for (int i = 0; i < 20; i++)
        //{
        //    var product1 = new Product()
        //    {
        //        Name = $"testProduct{i}",
        //        Quantity = i,
        //        ProductImage = new ProductImage
        //        {
        //            ImageContent = new byte[] {1,2,3 },
        //            ImageName = "TestNameImage"
        //        },
        //        ProductDetails = new ProductDetails
        //        {
        //            Price = 20,
        //            Description = $"TestDescriptions{i}",
        //        },
        //        ProductOffers = new ProductOffers
        //        {
        //            IsHitOffer = true,
        //            IsNewOffer = true,
        //        }
        //    };
        //    context.Products.Add(product1);
        //    context.SaveChanges();
        //}
        try
        {
            context.Database.Migrate();
        }
        catch
        {
            context.Database.EnsureCreated();
        }
    }
}
#endregion

app.Use(async (context, next) =>
{
    if (context.User.Identity.IsAuthenticated)
    {
        var accessTokenExpiration = context.User.FindFirstValue("exp");

        if (DateTimeOffset.FromUnixTimeSeconds(long.Parse(accessTokenExpiration)) <= DateTimeOffset.UtcNow)
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Token has expired.");
            return;
        }
    }

    await next();
});

app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseRouting();
app.UseAppAuth();

app.MapAppAreaControllerRoute();

app.UseAppSwagger(swaggerSettings);

app.Run();