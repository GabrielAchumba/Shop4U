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
    public class SupermarketsController : ControllerBase
    {
        private readonly SupermarketDbContext _context;

        public SupermarketsController(SupermarketDbContext context)
        {
            _context = context;
        }

        //GET: $"api/{controllerName}/GetSupermarkets";
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supermarket>>> GetSupermarkets()
        {
            return await _context.Supermarkets.ToListAsync();
        }

        // GET: api/Supermarkets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Supermarket>> GetSupermarket(Guid id)
        {
            var supermarket = await _context.Supermarkets.FindAsync(id);

            if (supermarket == null)
            {
                return NotFound();
            }

            return supermarket;
        }

        // PUT: api/Supermarkets/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupermarket(Guid id, Supermarket supermarket)
        {
            if (id != supermarket.Id)
            {
                return BadRequest();
            }

            _context.Entry(supermarket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupermarketExists(id))
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

        // POST: api/Supermarkets
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Supermarket>> PostSupermarket(Supermarket supermarket)
        {
            if (supermarket.Id == null) supermarket.Id = Guid.NewGuid();
            _context.Supermarkets.Add(supermarket);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSupermarket", new { id = supermarket.Id }, supermarket);
        }

        // DELETE: api/Supermarkets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Supermarket>> DeleteSupermarket(Guid id)
        {
            var supermarket = await _context.Supermarkets.FindAsync(id);
            if (supermarket == null)
            {
                return NotFound();
            }

            _context.Supermarkets.Remove(supermarket);
            await _context.SaveChangesAsync();

            return supermarket;
        }

        private bool SupermarketExists(Guid id)
        {
            return _context.Supermarkets.Any(e => e.Id == id);
        }
    }
}
