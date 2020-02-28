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
    public class ItemPricesController : ControllerBase
    {
        private readonly SupermarketDbContext _context;

        public ItemPricesController(SupermarketDbContext context)
        {
            _context = context;
        }

        // GET: api/ItemPrices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemPrice>>> GetItemPrices()
        {
            return await _context.ItemPrices.ToListAsync();
        }

        // GET: api/ItemPrices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemPrice>> GetItemPrice(Guid id)
        {
            var itemPrice = await _context.ItemPrices.FindAsync(id);

            if (itemPrice == null)
            {
                return NotFound();
            }

            return itemPrice;
        }

        // PUT: api/ItemPrices/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemPrice(Guid id, ItemPrice itemPrice)
        {
            if (id != itemPrice.Id)
            {
                return BadRequest();
            }

            _context.Entry(itemPrice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemPriceExists(id))
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

        // POST: api/ItemPrices
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ItemPrice>> PostItemPrice(ItemPrice itemPrice)
        {
            ItemPrice _itemPriceTemp = await _context.ItemPrices.FindAsync(itemPrice.Id);
            if (_itemPriceTemp == null)
            {
                _context.ItemPrices.Add(itemPrice);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetItemPrice", new { id = itemPrice.Id }, itemPrice);
            }

            return NotFound();
        }

        // DELETE: api/ItemPrices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ItemPrice>> DeleteItemPrice(Guid id)
        {
            var itemPrice = await _context.ItemPrices.FindAsync(id);
            if (itemPrice == null)
            {
                return NotFound();
            }

            _context.ItemPrices.Remove(itemPrice);
            await _context.SaveChangesAsync();

            return itemPrice;
        }

        private bool ItemPriceExists(Guid id)
        {
            return _context.ItemPrices.Any(e => e.Id == id);
        }
    }
}
