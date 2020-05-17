using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop4U.Enrollment.Helpers;
using Shop4U.Enrollment.Models;

namespace Shop4U.Enrollment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodDetailsController : ControllerBase
    {
        private readonly EnrollmentDbContext _context;

        public GoodDetailsController(EnrollmentDbContext context)
        {
            _context = context;
        }

        // GET: api/GoodDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GoodDetail>>> GetGoodDetails()
        {
            return await _context.GoodDetails.ToListAsync();
        }

        [HttpGet("GetFreshFoods")]
        public async Task<ActionResult<IEnumerable<GoodDetail>>> GetFreshFoods()
        {
            return await _context.GoodDetails.Where(GoodDetail => GoodDetail.ItemCategory == StaticVariables.FreshFood).ToListAsync();
        }

        [HttpGet("GetProvisions")]
        public async Task<ActionResult<IEnumerable<GoodDetail>>> GetProvisions()
        {
            return await _context.GoodDetails.Where(GoodDetail => GoodDetail.ItemCategory == StaticVariables.Provision).ToListAsync();
        }

        [HttpGet("GetHouseHoldAppliances")]
        public async Task<ActionResult<IEnumerable<GoodDetail>>> GetHouseHoldAppliances()
        {
            return await _context.GoodDetails.Where(GoodDetail => GoodDetail.ItemCategory == StaticVariables.HouseHold_Appliances).ToListAsync();
        }

        // GET: api/GoodDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GoodDetail>> GetGoodDetail(Guid id)
        {
            var goodDetail = await _context.GoodDetails.FindAsync(id);

            if (goodDetail == null)
            {
                return NotFound();
            }

            return goodDetail;
        }

        // PUT: api/GoodDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGoodDetail(Guid id, GoodDetail goodDetail)
        {
            if (id != goodDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(goodDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GoodDetailExists(id))
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

        // POST: api/GoodDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<GoodDetail>> PostGoodDetail(GoodDetail goodDetail)
        {

           

            bool check = false;

            foreach (var item in _context.GoodDetails)
            {
                if (item.Id == goodDetail.Id)
                {
                    check = true; break;
                }
            }

            if (check == true) goodDetail.Id = Guid.NewGuid();

            _context.GoodDetails.Add(goodDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGoodDetail", new { id = goodDetail.Id }, goodDetail);
        }

        // DELETE: api/GoodDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GoodDetail>> DeleteGoodDetail(Guid id)
        {
            var goodDetail = await _context.GoodDetails.FindAsync(id);
            if (goodDetail == null)
            {
                return NotFound();
            }

            _context.GoodDetails.Remove(goodDetail);
            await _context.SaveChangesAsync();

            return goodDetail;
        }

        private bool GoodDetailExists(Guid id)
        {
            return _context.GoodDetails.Any(e => e.Id == id);
        }
    }
}
