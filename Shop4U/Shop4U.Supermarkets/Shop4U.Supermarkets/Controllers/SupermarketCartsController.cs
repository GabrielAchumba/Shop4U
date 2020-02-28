using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop4U.Supermarkets.Models;

namespace Shop4U.Supermarkets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupermarketCartsController : ControllerBase
    {
        private readonly SupermarketDbContext _context;

        public SupermarketCartsController(SupermarketDbContext context)
        {
            _context = context;
        }

        // GET: api/SupermarketCarts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupermarketCart>>> GetSupermarketCarts()
        {
            return await _context.SupermarketCarts.ToListAsync();
        }

        // GET: api/SupermarketCarts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SupermarketCart>> GetSupermarketCart(Guid id)
        {
            var supermarketCart = await _context.SupermarketCarts.FindAsync(id);

            if (supermarketCart == null)
            {
                return NotFound();
            }

            return supermarketCart;
        }

        // PUT: api/SupermarketCarts/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupermarketCart(Guid id, SupermarketCart supermarketCart)
        {
            if (id != supermarketCart.Id)
            {
                return BadRequest();
            }

            _context.Entry(supermarketCart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupermarketCartExists(id))
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

        // POST: api/SupermarketCarts
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<SupermarketCart>> PostSupermarketCart(SupermarketCart supermarketCart)
        {
            _context.SupermarketCarts.Add(supermarketCart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSupermarketCart", new { id = supermarketCart.Id }, supermarketCart);
        }

        // DELETE: api/SupermarketCarts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SupermarketCart>> DeleteSupermarketCart(Guid id)
        {
            var supermarketCart = await _context.SupermarketCarts.FindAsync(id);
            if (supermarketCart == null)
            {
                return NotFound();
            }

            _context.SupermarketCarts.Remove(supermarketCart);
            await _context.SaveChangesAsync();

            return supermarketCart;
        }

        private bool SupermarketCartExists(Guid id)
        {
            return _context.SupermarketCarts.Any(e => e.Id == id);
        }
    }
}
