using Shop4U.Enrollment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U.Enrollment.Services
{
    public interface IAdministratorRepository
    {
        Task<Administrator> Get(Guid Id);
        IEnumerable<Administrator> Get();
        Task<Administrator> Add(Administrator administrator);
        Task<Administrator> Update(Administrator administrator);
        Task<Administrator> Delete(Guid Id);
    }
}
