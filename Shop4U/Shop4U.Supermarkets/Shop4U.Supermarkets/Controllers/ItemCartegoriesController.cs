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
    public class ItemCartegoriesController : ControllerBase
    {
        private readonly SupermarketDbContext _context;

        public ItemCartegoriesController(SupermarketDbContext context)
        {
            _context = context;
        }

        // GET: api/ItemCartegories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemCartegory>>> GetItemCartegories()
        {
            return await _context.ItemCartegories.ToListAsync();
        }

        // GET: api/ItemCartegories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemCartegory>> GetItemCartegory(Guid id)
        {
            var itemCartegory = await _context.ItemCartegories.FindAsync(id);

            if (itemCartegory == null)
            {
                return NotFound();
            }

            return itemCartegory;
        }

        // PUT: api/ItemCartegories/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemCartegory(Guid id, ItemCartegory itemCartegory)
        {
            if (id != itemCartegory.Id)
            {
                return BadRequest();
            }

            _context.Entry(itemCartegory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemCartegoryExists(id))
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

        // POST: api/ItemCartegories
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ItemCartegory>> PostItemCartegory(ItemCartegory itemCartegory)
        {
            _context.ItemCartegories.Add(itemCartegory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItemCartegory", new { id = itemCartegory.Id }, itemCartegory);
        }

        // DELETE: api/ItemCartegories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ItemCartegory>> DeleteItemCartegory(Guid id)
        {
            var itemCartegory = await _context.ItemCartegories.FindAsync(id);
            if (itemCartegory == null)
            {
                return NotFound();
            }

            _context.ItemCartegories.Remove(itemCartegory);
            await _context.SaveChangesAsync();

            return itemCartegory;
        }

        private bool ItemCartegoryExists(Guid id)
        {
            return _context.ItemCartegories.Any(e => e.Id == id);
        }
    }
}
