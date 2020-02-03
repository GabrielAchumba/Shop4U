using Shop4U.Enrollment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U.Enrollment.Services
{
    public interface ISuperAdministratorRepository
    {
        Task<SuperAdministrator> Get(Guid Id);
        IEnumerable<SuperAdministrator> Get();
        Task<SuperAdministrator> Add(SuperAdministrator superAdministrator);
        Task<SuperAdministrator> Update(SuperAdministrator superAdministrator);
        Task<SuperAdministrator> Delete(Guid Id);
    }
}
