using Shop4U.Enrollment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U.Enrollment.Services
{
    public interface IDistributorRepository
    {
        Task<Distributor> Get(Guid Id);
        IEnumerable<Distributor> Get();
        Task<Distributor> Add(Distributor distributor);
        Task<Distributor> Update(Distributor distributor);
        Task<Distributor> Delete(Guid Id);
    }
}
