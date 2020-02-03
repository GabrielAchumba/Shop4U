using Shop4U.Enrollment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U.Enrollment.Helpers
{
    public class SeedSuperAdmin
    {
        public static List<SuperAdministrator> GetSuperAdministrators()
        {
            List<SuperAdministrator> superAdmins = new List<SuperAdministrator>()
            {
                new SuperAdministrator()
                {
                    Id=Guid.NewGuid(),
                    FirstName="SuperAdmin1",
                    LastName="SuperAdmin1",
                    UserName="superAdmin1",
                    Password="superadmin1"
                }
            };

            return superAdmins;
        }
    }
}
