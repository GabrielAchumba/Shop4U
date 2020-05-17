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
    public class FastfoodItemPricesController : ControllerBase
    {
        private readonly FastfoodDbContext _context;

        public FastfoodItemPricesController(FastfoodDbContext context)
        {
            _context = context;
        }

        // GET: api/FastfoodItemPrices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FastfoodItemPrice>>> GetFastfoodItemPrices()
        {
            return await _context.FastfoodItemPrices.ToListAsync();
        }

        // GET: api/FastfoodItemPrices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FastfoodItemPrice>> GetFastfoodItemPrice(Guid id)
        {
            var fastfoodItemPrice = await _context.FastfoodItemPrices.FindAsync(id);

            if (fastfoodItemPrice == null)
            {
                return NotFound();
            }

            return fastfoodItemPrice;
        }

        // PUT: api/FastfoodItemPrices/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFastfoodItemPrice(Guid id, FastfoodItemPrice fastfoodItemPrice)
        {
            if (id != fastfoodItemPrice.Id)
            {
                return BadRequest();
            }

            _context.Entry(fastfoodItemPrice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FastfoodItemPriceExists(id))
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

        // POST: api/FastfoodItemPrices
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<FastfoodItemPrice>> PostFastfoodItemPrice(FastfoodItemPrice fastfoodItemPrice)
        {
            _context.FastfoodItemPrices.Add(fastfoodItemPrice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFastfoodItemPrice", new { id = fastfoodItemPrice.Id }, fastfoodItemPrice);
        }

        // DELETE: api/FastfoodItemPrices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FastfoodItemPrice>> DeleteFastfoodItemPrice(Guid id)
        {
            var fastfoodItemPrice = await _context.FastfoodItemPrices.FindAsync(id);
            if (fastfoodItemPrice == null)
            {
                return NotFound();
            }

            _context.FastfoodItemPrices.Remove(fastfoodItemPrice);
            await _context.SaveChangesAsync();

            return fastfoodItemPrice;
        }

        private bool FastfoodItemPriceExists(Guid id)
        {
            return _context.FastfoodItemPrices.Any(e => e.Id == id);
        }
    }
}
