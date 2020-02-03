using Shop4U.Enrollment.Models;
using Shop4U.Enrollment.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U.Enrollment.Repositories
{
    public class DistributorRepository : IDistributorRepository
    {
        private readonly EnrollmentDbContext context;
        public async Task<Distributor> Add(Distributor distributor)
        {
            if (distributor.Id == null) distributor.Id = Guid.NewGuid();
            await context.Distributors.AddAsync(distributor);
            await context.SaveChangesAsync();
            return distributor;
        }

        public async Task<Distributor> Delete(Guid Id)
        {
            Distributor distributor = await context.Distributors.FindAsync(Id);
            if (distributor != null)
            {
                context.Distributors.Remove(distributor);
                await context.SaveChangesAsync();
            }
            return distributor;
        }

        public async Task<Distributor> Get(Guid Id)
        {
            return await context.Distributors.FindAsync(Id);
        }

        public IEnumerable<Distributor> Get()
        {
            IEnumerable<Distributor> _Distributors = context.Distributors;
            return _Distributors;
        }

        public async Task<Distributor> Update(Distributor distributor)
        {
            var _distributor = context.Distributors.Attach(distributor);
            _distributor.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
            return distributor;
        }
    }
}
