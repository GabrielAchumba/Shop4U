using Microsoft.EntityFrameworkCore;
using Shop4U.Enrollment.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U.Enrollment.Models
{
    public class EnrollmentDbContext: DbContext
    {
        public EnrollmentDbContext(DbContextOptions<EnrollmentDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SuperAdministrator>().HasData(SeedSuperAdmin.GetSuperAdministrators());
        }

        public DbSet<SuperAdministrator> SuperAdministrators { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<BusinessPersonel> BusinessPersonels { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Distributor> Distributors { get; set; }
        public DbSet<Good> Goods { get; set; }
        public DbSet<ItemTicket> ItemTickets { get; set; }
        public DbSet<GoodDetail> GoodDetails { get; set; }
        public DbSet<Auth> Auths { get; set; }
    }
}
