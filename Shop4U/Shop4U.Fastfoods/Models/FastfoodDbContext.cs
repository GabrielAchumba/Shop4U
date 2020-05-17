using Microsoft.EntityFrameworkCore;
using Shop4U.Fastfoods.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U.Fastfoods.Models
{
    public class FastfoodDbContext : DbContext
    {
        public FastfoodDbContext(DbContextOptions<FastfoodDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fastfood>().HasData(SeedFastfoods.GetFastfoods());
        }

        public DbSet<Fastfood> Fastfoods { get; set; }
        public DbSet<FastfoodItem> FastfoodItems { get; set; }
        public DbSet<FastfoodItemPrice> FastfoodItemPrices { get; set; }
        public DbSet<FastfoodCart> FastfoodCarts { get; set; }

    }
}
