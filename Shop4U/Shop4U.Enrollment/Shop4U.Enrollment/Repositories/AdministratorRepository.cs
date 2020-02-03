using Shop4U.Enrollment.Models;
using Shop4U.Enrollment.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U.Enrollment.Repositories
{
    public class AdministratorRepository : IAdministratorRepository
    {
        private readonly EnrollmentDbContext context;

        public async Task<Administrator> Add(Administrator administrator)
        {
            if (administrator.Id == null) administrator.Id = Guid.NewGuid();
            await context.Administrators.AddAsync(administrator);
            await context.SaveChangesAsync();
            return administrator;
        }

        public async Task<Administrator> Delete(Guid Id)
        {
            Administrator administrator = await context.Administrators.FindAsync(Id);
            if (administrator != null)
            {
                context.Administrators.Remove(administrator);
                await context.SaveChangesAsync();
            }
            return administrator;
        }

        public async Task<Administrator> Get(Guid Id)
        {
            return await context.Administrators.FindAsync(Id);
        }

        public IEnumerable<Administrator> Get()
        {
            IEnumerable<Administrator> _Administrators = context.Administrators;
            return _Administrators;
        }

        public async Task<Administrator> Update(Administrator administrator)
        {
            var _administrator = context.Administrators.Attach(administrator);
            _administrator.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
            return administrator;
        }
    }
}
