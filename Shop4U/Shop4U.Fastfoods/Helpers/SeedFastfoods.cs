using Shop4U.Fastfoods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U.Fastfoods.Helpers
{
    public class SeedFastfoods
    {

        public static List<Fastfood> GetFastfoods()
        {
            
           

            List<Fastfood> fastfoods = new List<Fastfood>()
            {
                new Fastfood()
                {
                    Id=Guid.NewGuid(),
                    Name="Chicken Republic",
                    Description=""
                },
                new Fastfood()
                {
                    Id=Guid.NewGuid(),
                    Name="Kilimanjaro",
                    Description=""
                },
                new Fastfood()
                {
                    Id=Guid.NewGuid(),
                    Name="Pizzamore",
                    Description=""
                },
                new Fastfood()
                {
                    Id=Guid.NewGuid(),
                    Name="Genesis",
                    Description=""
                },
                new Fastfood()
                {
                    Id=Guid.NewGuid(),
                    Name="Bole King",
                    Description=""
                },
                new Fastfood()
                {
                    Id=Guid.NewGuid(),
                    Name="The Promise",
                    Description=""
                },
                new Fastfood()
                {
                    Id=Guid.NewGuid(),
                    Name="BestBite",
                    Description=""
                },
                new Fastfood()
                {
                    Id=Guid.NewGuid(),
                    Name="Native Tray",
                    Description=""
                },
                new Fastfood()
                {
                    Id=Guid.NewGuid(),
                    Name="Sweet Tooth",
                    Description=""
                },
                new Fastfood()
                {
                    Id=Guid.NewGuid(),
                    Name="ColdStone",
                    Description=""
                },
                new Fastfood()
                {
                    Id=Guid.NewGuid(),
                    Name="Jevinik",
                    Description=""
                }
            };

            return fastfoods;
        }
    }
}
