using Microsoft.EntityFrameworkCore;
using JijaShop.Api.Data;
using System.Data;
using JijaShop.Context.Settings;

namespace JijaShop.Context.Factories
{
    public static class DbContextOptionsFactory
    {
        private const string migrationProjctPrefix = "JijaShop.Context.Migrations";

        public static DbContextOptions<MainContext> Create(string connStr, DataBaseType dbType)
        {
            var dbBuilder = new DbContextOptionsBuilder<MainContext>();

            Configure(connStr, dbType).Invoke(dbBuilder);

            return dbBuilder.Options;
        }

        public static Action<DbContextOptionsBuilder> Configure(string connStr, DataBaseType dbType)
        {
            return (dbBuilder) =>
            {
                switch (dbType)
                {
                    case DataBaseType.MSSQL:
                        dbBuilder.UseSqlServer(connStr,
                            opts => opts
                                    .CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds)
                                    .MigrationsHistoryTable("_EFMigrationsHistory", "public")
                                    .MigrationsAssembly($"{migrationProjctPrefix}{DataBaseType.MSSQL}")
                            );
                        break;

                    case DataBaseType.PostgreSQL:
                        dbBuilder.UseNpgsql(connStr,
                            opts => opts
                                    .CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds)
                                    .MigrationsHistoryTable("_EFMigrationsHistory", "public")
                                    .MigrationsAssembly($"{migrationProjctPrefix}{DataBaseType.PostgreSQL}")
                            );
                        break;
                }

                dbBuilder.EnableSensitiveDataLogging();
                //bldr.UseLazyLoadingProxies();
                dbBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            };
        }
    }
}
