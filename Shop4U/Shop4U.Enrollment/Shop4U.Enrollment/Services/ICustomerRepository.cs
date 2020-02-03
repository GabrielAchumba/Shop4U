using Shop4U.Enrollment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U.Enrollment.Services
{
    public interface ICustomerRepository
    {
        Task<Customer> Get(Guid Id);
        IEnumerable<Customer> Get();
        Task<Customer> Add(Customer customer);
        Task<Customer> Update(Customer customer);
        Task<Customer> Delete(Guid Id);
    }
}
