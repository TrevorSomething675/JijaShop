using Microsoft.EntityFrameworkCore;
using JijaShop.Api.Data;

namespace JijaShop.Context.Factories
{
    public class DbContextFactory
    {
        private readonly DbContextOptions<MainContext> options;

        public DbContextFactory(DbContextOptions<MainContext> options)
        {
            this.options = options;
        }

        public MainContext Create()
        {
            return new MainContext(options);
        }
    }
}
