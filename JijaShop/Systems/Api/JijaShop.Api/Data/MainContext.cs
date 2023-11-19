using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using JijaShop.Api.Data.Models.AuthEntities;
using JijaShop.Api.Data.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JijaShop.Api.Data
{
    public class MainContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CartProduct> CartProducts { get; set; }
        public DbSet<FavoriteProduct> FavoriteProducts { get; set; }

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
