using Shop4U.Enrollment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U.Enrollment.Services
{
    public interface IBusinessPersonelRepository
    {
        Task<BusinessPersonel> Get(Guid Id);
        IEnumerable<BusinessPersonel> Get();
        Task<BusinessPersonel> Add(BusinessPersonel businessPersonel);
        Task<BusinessPersonel> Update(BusinessPersonel businessPersonel);
        Task<BusinessPersonel> Delete(Guid Id);
    }
}
