using Microsoft.EntityFrameworkCore;
using JijaShop.Context.Entities;

namespace JijaShop.Api.Data
{
    public class MainContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Product> Products { get; set; }
        public MainContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            lock (new object())
            {
                try
                {
                    return base.SaveChangesAsync(cancellationToken).GetAwaiter().GetResult();
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}
