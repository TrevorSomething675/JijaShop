using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Controllers;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Filters;
using JijaShop.Api.Configurations;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using JijaShop.Api.Services.Abstractions;
using JijaShop.Api.Services;
using JijaShop.Api.Repositories.Abstractions;
using JijaShop.Api.Repositories;
using JijaShop.Api.Data;
using JijaShop.Api.Data.Models.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.AddAppLogger();

builder.Services.AddAutoMapper(typeof(AutoMapperConfiguration));
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IIdentityService, IdentityService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddSwaggerGen(options =>
{
    options.DocInclusionPredicate((docName, apiDesc) =>
    {
        if (!apiDesc.TryGetMethodInfo(out MethodInfo methodInfo)) return false;
        var controllerActionDescriptor = (ControllerActionDescriptor)apiDesc.ActionDescriptor;
        var controllerNamespace = controllerActionDescriptor.ControllerTypeInfo.Namespace;
        return controllerNamespace != null && controllerNamespace.Contains("JijaShop.Areas.UserArea");
    });

    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standart Authorization",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(builder.Configuration.GetSection("AppSettings:SecretKeyForToken").Value)),
    };
});
builder.Services.AddDbContext<MainContext>(options => options
    .UseNpgsql(builder.Configuration.GetConnectionString("MainConnectionString")));

var app = builder.Build();
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

app.MapBlazorHub();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

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

app.UseSwagger();
app.UseSwaggerUI();

app.Run();