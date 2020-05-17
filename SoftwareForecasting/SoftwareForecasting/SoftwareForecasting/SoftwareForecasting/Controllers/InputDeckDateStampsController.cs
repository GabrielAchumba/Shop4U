using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftwareForecasting.Models;

namespace SoftwareForecasting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InputDeckDateStampsController : ControllerBase
    {
        private readonly ForecastDbContext _context;

        public InputDeckDateStampsController(ForecastDbContext context)
        {
            _context = context;
        }

        // GET: api/InputDeckDateStamps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InputDeckDateStamp>>> GetInputDeckDateStamp()
        {
            return await _context.InputDeckDateStamp.ToListAsync();
        }

        // GET: api/InputDeckDateStamps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InputDeckDateStamp>> GetInputDeckDateStamp(Guid id)
        {
            var inputDeckDateStamp = await _context.InputDeckDateStamp.FindAsync(id);

            if (inputDeckDateStamp == null)
            {
                return NotFound();
            }

            return inputDeckDateStamp;
        }

        // PUT: api/InputDeckDateStamps/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInputDeckDateStamp(Guid id, InputDeckDateStamp inputDeckDateStamp)
        {
            if (id != inputDeckDateStamp.id)
            {
                return BadRequest();
            }

            _context.Entry(inputDeckDateStamp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InputDeckDateStampExists(id))
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

        // POST: api/InputDeckDateStamps
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<InputDeckDateStamp>> PostInputDeckDateStamp(InputDeckDateStamp inputDeckDateStamp)
        {
            _context.InputDeckDateStamp.Add(inputDeckDateStamp);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInputDeckDateStamp", new { id = inputDeckDateStamp.id }, inputDeckDateStamp);
        }

        // DELETE: api/InputDeckDateStamps/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<InputDeckDateStamp>> DeleteInputDeckDateStamp(Guid id)
        {
            var inputDeckDateStamp = await _context.InputDeckDateStamp.FindAsync(id);
            if (inputDeckDateStamp == null)
            {
                return NotFound();
            }

            _context.InputDeckDateStamp.Remove(inputDeckDateStamp);
            await _context.SaveChangesAsync();

            return inputDeckDateStamp;
        }

        private bool InputDeckDateStampExists(Guid id)
        {
            return _context.InputDeckDateStamp.Any(e => e.id == id);
        }
    }
}
