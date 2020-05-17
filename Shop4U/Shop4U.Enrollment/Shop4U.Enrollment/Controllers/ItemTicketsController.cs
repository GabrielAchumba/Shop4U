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
    public class ItemTicketsController : ControllerBase
    {
        private readonly EnrollmentDbContext _context;

        public ItemTicketsController(EnrollmentDbContext context)
        {
            _context = context;
        }

        // GET: api/ItemTickets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemTicket>>> GetItemTickets()
        {
            return await _context.ItemTickets.ToListAsync();
        }

        // GET: api/ItemTickets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemTicket>> GetItemTicket(Guid id)
        {
            var itemTicket = await _context.ItemTickets.FindAsync(id);

            if (itemTicket == null)
            {
                return NotFound();
            }

            return itemTicket;
        }

        // PUT: api/ItemTickets/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemTicket(Guid id, ItemTicket itemTicket)
        {
            if (id != itemTicket.Id)
            {
                return BadRequest();
            }

            _context.Entry(itemTicket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemTicketExists(id))
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

        // POST: api/ItemTickets
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ItemTicket>> PostItemTicket(ItemTicket itemTicket)
        {

            bool check = false;


            foreach (var item in _context.ItemTickets)
            {
                if (item.Id == itemTicket.Id)
                {
                    check = true; break;
                }
            }

            if (check == true) itemTicket.Id = Guid.NewGuid();

            _context.ItemTickets.Add(itemTicket);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItemTicket", new { id = itemTicket.Id }, itemTicket);
        }

        // DELETE: api/ItemTickets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ItemTicket>> DeleteItemTicket(Guid id)
        {
            var itemTicket = await _context.ItemTickets.FindAsync(id);
            if (itemTicket == null)
            {
                return NotFound();
            }

            _context.ItemTickets.Remove(itemTicket);
            await _context.SaveChangesAsync();

            return itemTicket;
        }

        [HttpDelete("DeleteItemTicketByStringId/{id}")]
        public async Task<ActionResult<ItemTicket>> DeleteItemTicketByStringId(string id_string)
        {
            Guid id = new Guid(id_string);
            var itemTicket = await _context.ItemTickets.FindAsync(id);
            if (itemTicket == null)
            {
                return NotFound();
            }

            _context.ItemTickets.Remove(itemTicket);
            await _context.SaveChangesAsync();

            return itemTicket;
        }

        private bool ItemTicketExists(Guid id)
        {
            return _context.ItemTickets.Any(e => e.Id == id);
        }
    }
}
