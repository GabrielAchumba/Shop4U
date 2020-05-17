using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop4U.Fastfoods.Models;

namespace Shop4U.Fastfoods.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FastfoodCartsController : ControllerBase
    {
        private readonly FastfoodDbContext _context;

        public FastfoodCartsController(FastfoodDbContext context)
        {
            _context = context;
        }

        // GET: api/FastfoodCarts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FastfoodCart>>> GetFastfoodCarts()
        {
            return await _context.FastfoodCarts.ToListAsync();
        }

        // GET: api/FastfoodCarts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FastfoodCart>> GetFastfoodCart(Guid id)
        {
            var fastfoodCart = await _context.FastfoodCarts.FindAsync(id);

            if (fastfoodCart == null)
            {
                return NotFound();
            }

            return fastfoodCart;
        }

        // PUT: api/FastfoodCarts/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFastfoodCart(Guid id, FastfoodCart fastfoodCart)
        {
            if (id != fastfoodCart.Id)
            {
                return BadRequest();
            }

            _context.Entry(fastfoodCart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FastfoodCartExists(id))
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

        // POST: api/FastfoodCarts
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<FastfoodCart>> PostFastfoodCart(FastfoodCart fastfoodCart)
        {
            _context.FastfoodCarts.Add(fastfoodCart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFastfoodCart", new { id = fastfoodCart.Id }, fastfoodCart);
        }

        // DELETE: api/FastfoodCarts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FastfoodCart>> DeleteFastfoodCart(Guid id)
        {
            var fastfoodCart = await _context.FastfoodCarts.FindAsync(id);
            if (fastfoodCart == null)
            {
                return NotFound();
            }

            _context.FastfoodCarts.Remove(fastfoodCart);
            await _context.SaveChangesAsync();

            return fastfoodCart;
        }

        private bool FastfoodCartExists(Guid id)
        {
            return _context.FastfoodCarts.Any(e => e.Id == id);
        }
    }
}
