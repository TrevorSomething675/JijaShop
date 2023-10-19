using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using JijaShop.Context.Settings;
using JijaShop.Api.Data;

namespace JijaShop.Context.Factories
{
    public class DesignTypeDbContextFactory : IDesignTimeDbContextFactory<MainContext>
    {
        private const string migrationProjctPrefix = "JijaShop.Context.Migrations";

        public MainContext CreateDbContext(string[] args)
        {
            var provider = (args?[0] ?? $"{DataBaseType.MSSQL}").ToLower();

            var configuration = new ConfigurationBuilder()
                 .AddJsonFile("appsettings.context.json")
                 .Build();


            DbContextOptions<MainContext> options;
            if (provider.Equals($"{DataBaseType.MSSQL}".ToLower()))
            {
                options = new DbContextOptionsBuilder<MainContext>()
                        .UseSqlServer(
                            configuration.GetConnectionString(provider),
                            opts => opts
                                .MigrationsAssembly($"{migrationProjctPrefix}{DbType.MSSQL}")
                        )
                        .Options;
            }
            else
            if (provider.Equals($"{DataBaseType.PostgreSQL}".ToLower()))
            {
                options = new DbContextOptionsBuilder<MainContext>()
                        .UseNpgsql(
                            configuration.GetConnectionString(provider),
                            opts => opts
                                .MigrationsAssembly($"{migrationProjctPrefix}{DbType.PostgreSQL}")
                        )
                        .Options;
            }
            else
            {
                throw new Exception($"Unsupported provider: {provider}");
            }

            var dbf = new DbContextFactory(options);
            return dbf.Create();
        }
    }
}
