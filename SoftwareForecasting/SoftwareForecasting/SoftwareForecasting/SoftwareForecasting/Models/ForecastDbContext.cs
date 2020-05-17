using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SoftwareForecasting.Models;

namespace SoftwareForecasting.Models
{
    public class ForecastDbContext : DbContext
    {
        public ForecastDbContext(DbContextOptions<ForecastDbContext> options) : base(options)
        {

        }

        public DbSet<FacilityDeck> FacilityDecks { get; set; }
        public DbSet<InputDeck> InputDecks { get; set; }
        public DbSet<InputDeckDateStamp> InputDeckDateStamp { get; set; }
        public DbSet<ForecastResult> ForecastResults { get; set; }
    }
}
