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
    public class FastfoodItemsController : ControllerBase
    {
        private readonly FastfoodDbContext _context;

        public FastfoodItemsController(FastfoodDbContext context)
        {
            _context = context;
        }

        // GET: api/FastfoodItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FastfoodItem>>> GetFastfoodItems()
        {
            return await _context.FastfoodItems.ToListAsync();
        }

        // GET: api/FastfoodItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FastfoodItem>> GetFastfoodItem(Guid id)
        {
            var fastfoodItem = await _context.FastfoodItems.FindAsync(id);

            if (fastfoodItem == null)
            {
                return NotFound();
            }

            return fastfoodItem;
        }

        // PUT: api/FastfoodItems/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFastfoodItem(Guid id, FastfoodItem fastfoodItem)
        {
            if (id != fastfoodItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(fastfoodItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FastfoodItemExists(id))
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

        // POST: api/FastfoodItems
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<FastfoodItem>> PostFastfoodItem(FastfoodItem fastfoodItem)
        {
            _context.FastfoodItems.Add(fastfoodItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFastfoodItem", new { id = fastfoodItem.Id }, fastfoodItem);
        }

        // DELETE: api/FastfoodItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FastfoodItem>> DeleteFastfoodItem(Guid id)
        {
            var fastfoodItem = await _context.FastfoodItems.FindAsync(id);
            if (fastfoodItem == null)
            {
                return NotFound();
            }

            _context.FastfoodItems.Remove(fastfoodItem);
            await _context.SaveChangesAsync();

            return fastfoodItem;
        }

        private bool FastfoodItemExists(Guid id)
        {
            return _context.FastfoodItems.Any(e => e.Id == id);
        }
    }
}
