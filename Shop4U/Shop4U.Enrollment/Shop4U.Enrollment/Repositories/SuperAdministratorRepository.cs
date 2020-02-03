using Shop4U.Enrollment.Models;
using Shop4U.Enrollment.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U.Enrollment.Repositories
{
    public class SuperAdministratorRepository : ISuperAdministratorRepository
    {
        private readonly EnrollmentDbContext context;
        public async Task<SuperAdministrator> Add(SuperAdministrator superAdministrator)
        {
            if (superAdministrator.Id == null) superAdministrator.Id = Guid.NewGuid();
            await context.SuperAdministrators.AddAsync(superAdministrator);
            await context.SaveChangesAsync();
            return superAdministrator;
        }

        public async Task<SuperAdministrator> Delete(Guid Id)
        {
            SuperAdministrator superAdministrator = await context.SuperAdministrators.FindAsync(Id);
            if (superAdministrator != null)
            {
                context.SuperAdministrators.Remove(superAdministrator);
                await context.SaveChangesAsync();
            }
            return superAdministrator;
        }

        public async Task<SuperAdministrator> Get(Guid Id)
        {
            return await context.SuperAdministrators.FindAsync(Id);
        }

        public IEnumerable<SuperAdministrator> Get()
        {
            IEnumerable<SuperAdministrator> _SuperAdministrators = context.SuperAdministrators;
            return _SuperAdministrators;
        }

        public async Task<SuperAdministrator> Update(SuperAdministrator superAdministrator)
        {
            var _superAdministrator = context.SuperAdministrators.Attach(superAdministrator);
            _superAdministrator.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
            return superAdministrator;
        }
    }
}
