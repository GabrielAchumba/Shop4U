using Microsoft.EntityFrameworkCore;
using Shop4U.Supermarkets.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U.Supermarkets.Models
{
    public class SupermarketDbContext: DbContext
    {
        public SupermarketDbContext(DbContextOptions<SupermarketDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Supermarket>().HasData(SeedSupermarket.GetSupermarkets());
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<ItemCartegory> ItemCartegories { get; set; }
        public DbSet<ItemGroup> ItemGroups { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<Supermarket> Supermarkets { get; set; }

        public DbSet<ItemPrice> ItemPrices { get; set; }
    }
}
