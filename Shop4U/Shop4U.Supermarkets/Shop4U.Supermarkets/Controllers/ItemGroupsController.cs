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
    public class ItemGroupsController : ControllerBase
    {
        private readonly SupermarketDbContext _context;

        public ItemGroupsController(SupermarketDbContext context)
        {
            _context = context;
        }

        // GET: api/ItemGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemGroup>>> GetItemGroups()
        {
            return await _context.ItemGroups.ToListAsync();
        }

        // GET: api/ItemGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemGroup>> GetItemGroup(Guid id)
        {
            var itemGroup = await _context.ItemGroups.FindAsync(id);

            if (itemGroup == null)
            {
                return NotFound();
            }

            return itemGroup;
        }

        // PUT: api/ItemGroups/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemGroup(Guid id, ItemGroup itemGroup)
        {
            if (id != itemGroup.Id)
            {
                return BadRequest();
            }

            _context.Entry(itemGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemGroupExists(id))
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

        // POST: api/ItemGroups
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ItemGroup>> PostItemGroup(ItemGroup itemGroup)
        {
            _context.ItemGroups.Add(itemGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItemGroup", new { id = itemGroup.Id }, itemGroup);
        }

        // DELETE: api/ItemGroups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ItemGroup>> DeleteItemGroup(Guid id)
        {
            var itemGroup = await _context.ItemGroups.FindAsync(id);
            if (itemGroup == null)
            {
                return NotFound();
            }

            _context.ItemGroups.Remove(itemGroup);
            await _context.SaveChangesAsync();

            return itemGroup;
        }

        private bool ItemGroupExists(Guid id)
        {
            return _context.ItemGroups.Any(e => e.Id == id);
        }
    }
}
