﻿using Microsoft.EntityFrameworkCore;
using JijaShop.Models;

namespace JijaShop
{
    public class MainContext : DbContext
    {
        public DbSet<User> Users { get; set; } 
        public MainContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
