using JijaShop.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using JijaShop.Repositories;
using JijaShop;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.File("Logs/Log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Services.AddAutoMapper(typeof(AppMappingProfile));

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MainContext>(options => options
    .UseNpgsql(configuration.GetConnectionString("MainConnectionString")));



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

app.UseAuthorization();

app.MapAreaControllerRoute(
    name:"User_area",
    areaName: "User",
    pattern: "{area:exists}/{controller=Home}/{action=Index}");

app.MapAreaControllerRoute(
    name: "Moderator_area",
    areaName: "Moderator",
    pattern: "{area:exists}/{controller=Home}/{action=Index}");

app.MapAreaControllerRoute(
    name: "Admin_area",
    areaName: "Admin",
    pattern: "{area:exists}/{controller=Home}/{action=Index}");
app.Run();