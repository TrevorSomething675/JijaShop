using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Controllers;
using JijaShop.Repositories.Abstractions;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Filters;
using JijaShop.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using JijaShop.Repositories;
using System.Reflection;
using JijaShop.Services;
using System.Text;
using JijaShop;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration().ReadFrom
    .Configuration(builder.Configuration).CreateLogger();

builder.Services.AddAutoMapper(typeof(AppMappingProfile));
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
using(var scope = app.Services.CreateScope())
{
    using(var context = scope.ServiceProvider.GetRequiredService<MainContext>())
    {
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
    pattern: "Admin/{controller=Home}/{action=Users}");

app.UseSwagger();
app.UseSwaggerUI();

app.Run();