using Shop4U.Supermarkets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U.Supermarkets.Helpers
{
    public class SeedSupermarket
    {
        
        public static List<Supermarket> GetSupermarkets()
        {
            List<Supermarket> superAdmins = new List<Supermarket>()
            {
                new Supermarket()
                {
                    Id=Guid.NewGuid(),
                    Name="Shoprite",
                    Description=""
                },
                new Supermarket()
                {
                    Id=Guid.NewGuid(),
                    Name="Justrite",
                    Description=""
                },
                new Supermarket()
                {
                    Id=Guid.NewGuid(),
                    Name="Welcome U",
                    Description=""
                },
                new Supermarket()
                {
                    Id=Guid.NewGuid(),
                    Name="Livinchin",
                    Description=""
                },
                new Supermarket()
                {
                    Id=Guid.NewGuid(),
                    Name="Spar Mall",
                    Description=""
                },
                new Supermarket()
                {
                    Id=Guid.NewGuid(),
                    Name="Next Cash And Carry",
                    Description=""
                },
                new Supermarket()
                {
                    Id=Guid.NewGuid(),
                    Name="Everyday",
                    Description=""
                },
                new Supermarket()
                {
                    Id=Guid.NewGuid(),
                    Name="Market Square",
                    Description=""
                },
                new Supermarket()
                {
                    Id=Guid.NewGuid(),
                    Name="PEP Store",
                    Description=""
                }
            };

            return superAdmins;
        }
    }
}
