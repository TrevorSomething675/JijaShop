using JijaShop.Services.Settings.SettingsModel;
using Microsoft.EntityFrameworkCore;
using JijaShop.Api.Configurations;
using JijaShop.Api.Data;
using JijaShop.Settings;
using JijaShop.Api;
using JijaShop.Api.Data.Models.Entities;

var builder = WebApplication.CreateBuilder(args);

var swaggerSettings = Settings.Load<SwaggerSettings>("Swagger");
var dataBaseSettings = Settings.Load<DataBaseSettings>("DataBase");
var identitySettings = Settings.Load<IdentitySettings>("Identity");

builder.AddAppLogger();
var services = builder.Services;

services.AddAutoMapper(typeof(AutoMapperConfiguration));
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

app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseAppAuth();
app.UseRouting();

app.MapAppAreaControllerRoute();

app.UseAppSwagger(swaggerSettings);

app.Run();