using Shop4U.Enrollment.Models;
using Shop4U.Enrollment.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U.Enrollment.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly EnrollmentDbContext context;
        public async Task<Customer> Add(Customer customer)
        {
            if (customer.Id == null) customer.Id = Guid.NewGuid();
            await context.Customers.AddAsync(customer);
            await context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> Delete(Guid Id)
        {
            Customer customer = await context.Customers.FindAsync(Id);
            if (customer != null)
            {
                context.Customers.Remove(customer);
                await context.SaveChangesAsync();
            }
            return customer;
        }

        public async Task<Customer> Get(Guid Id)
        {
            return await context.Customers.FindAsync(Id);
        }

        public IEnumerable<Customer> Get()
        {
            IEnumerable<Customer> _Customers = context.Customers;
            return _Customers;
        }

        public async Task<Customer> Update(Customer customer)
        {
            var _customer = context.Customers.Attach(customer);
            _customer.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
            return customer;
        }
    }
}
