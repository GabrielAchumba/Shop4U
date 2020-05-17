using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop4U.Enrollment.Models;

namespace Shop4U.Enrollment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly EnrollmentDbContext _context;

        public CustomersController(EnrollmentDbContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(Guid id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(Guid id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        //POST: $"api/{controllerName}/PostCustomer";
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        [Route("PostCustomer")]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            bool check = false;

            if (customer != null)
            {

                foreach (var item in _context.Customers)
                {
                    if (item.Id == customer.Id)
                    {
                        check = true; break;
                    }
                }

                if (check == true) customer.Id = Guid.NewGuid();


                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();
                customer.UserType = "User";
                return Ok(customer);
            }

            return Ok(customer);
        }


        //POST: $"api/{controllerName}/LoginCustomer/{isLogin}";
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        [Route("LoginCustomer/{IsLogin}")]
        public async Task<ActionResult<Customer>> LoginCustomer(Customer customer,bool isLogin)
        {
            if (customer != null)
            {
                    var customers = await _context.Customers.ToListAsync();
                    foreach (var _customer in customers)
                    {
                        if (customer.UserName == _customer.UserName && customer.Password == _customer.Password)
                        {
                            customer = _customer;
                            customer.UserType = "User";
                            return Ok(customer);

                        }
                    }
                
            }

            return Ok(customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> DeleteCustomer(Guid id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return customer;
        }

        private bool CustomerExists(Guid id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}
