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
    public class FastfoodsController : ControllerBase
    {
        private readonly FastfoodDbContext _context;

        public FastfoodsController(FastfoodDbContext context)
        {
            _context = context;
        }

        // GET: api/Fastfoods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fastfood>>> GetFastfoods()
        {
            return await _context.Fastfoods.ToListAsync();
        }

        // GET: api/Fastfoods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fastfood>> GetFastfood(Guid id)
        {
            var fastfood = await _context.Fastfoods.FindAsync(id);

            if (fastfood == null)
            {
                return NotFound();
            }

            return fastfood;
        }

        // PUT: api/Fastfoods/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFastfood(Guid id, Fastfood fastfood)
        {
            if (id != fastfood.Id)
            {
                return BadRequest();
            }

            _context.Entry(fastfood).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FastfoodExists(id))
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

        // POST: api/Fastfoods
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Fastfood>> PostFastfood(Fastfood fastfood)
        {
            _context.Fastfoods.Add(fastfood);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFastfood", new { id = fastfood.Id }, fastfood);
        }

        // DELETE: api/Fastfoods/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Fastfood>> DeleteFastfood(Guid id)
        {
            var fastfood = await _context.Fastfoods.FindAsync(id);
            if (fastfood == null)
            {
                return NotFound();
            }

            _context.Fastfoods.Remove(fastfood);
            await _context.SaveChangesAsync();

            return fastfood;
        }

        private bool FastfoodExists(Guid id)
        {
            return _context.Fastfoods.Any(e => e.Id == id);
        }
    }
}
