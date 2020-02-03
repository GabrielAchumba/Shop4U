using Shop4U.Enrollment.Models;
using Shop4U.Enrollment.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U.Enrollment.Repositories
{
    public class BusinessPersonelRepository : IBusinessPersonelRepository
    {
        private readonly EnrollmentDbContext context;
        public async Task<BusinessPersonel> Add(BusinessPersonel businessPersonel)
        {
            if (businessPersonel.Id == null) businessPersonel.Id = Guid.NewGuid();
            await context.BusinessPersonels.AddAsync(businessPersonel);
            await context.SaveChangesAsync();
            return businessPersonel;
        }

        public async Task<BusinessPersonel> Delete(Guid Id)
        {
            BusinessPersonel businessPersonel = await context.BusinessPersonels.FindAsync(Id);
            if (businessPersonel != null)
            {
                context.BusinessPersonels.Remove(businessPersonel);
                await context.SaveChangesAsync();
            }
            return businessPersonel;
        }

        public async Task<BusinessPersonel> Get(Guid Id)
        {
            return await context.BusinessPersonels.FindAsync(Id);
        }

        public IEnumerable<BusinessPersonel> Get()
        {
            IEnumerable<BusinessPersonel> _BusinessPersonels = context.BusinessPersonels;
            return _BusinessPersonels;
        }

        public async Task<BusinessPersonel> Update(BusinessPersonel businessPersonel)
        {
            var _businessPersonel = context.BusinessPersonels.Attach(businessPersonel);
            _businessPersonel.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
            return businessPersonel;
        }
    }
}
