using JijaShop.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using JijaShop;


var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build();

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

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapAreaControllerRoute(
    name: "Admin_area",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}");

app.MapAreaControllerRoute(
    name: "Moderator_area",
    areaName: "Moderator",
    pattern: "Moderator/{controller=Home}/{action=Index}");

app.MapAreaControllerRoute(
    name: "User_area",
    areaName: "User",
    pattern: "User/{controller=Home}/{action=Index}");

app.MapFallbackToController("Error", "Home");

app.Run();