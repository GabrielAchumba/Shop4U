using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using Microsoft.EntityFrameworkCore;
using Shop4U.Enrollment.Helpers;
using Shop4U.Enrollment.Models;

namespace Shop4U.Enrollment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodsController : ControllerBase
    {
        private readonly EnrollmentDbContext _context;

        public GoodsController(EnrollmentDbContext context)
        {
            _context = context;
        }

        // GET: api/Goods

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Good>>> GetGoods()
        {
            return await _context.Goods.ToListAsync();
        }

        [HttpGet("GetFreshFoods")]
        public async Task<ActionResult<IEnumerable<Good>>> GetFreshFoods()
        {
            return await _context.Goods.Where(Good => Good.ItemCategory == StaticVariables.FreshFood).ToListAsync(); 
        }

        [HttpGet("GetProvisions")]
        public async Task<ActionResult<IEnumerable<Good>>> GetProvisions()
        {
            return await _context.Goods.Where(Good => Good.ItemCategory == StaticVariables.Provision).ToListAsync();
        }

        [HttpGet("GetHouseHoldAppliances")]
        public async Task<ActionResult<IEnumerable<Good>>> GetHouseHoldAppliances()
        {
            return await _context.Goods.Where(Good => Good.ItemCategory == StaticVariables.HouseHold_Appliances).ToListAsync();
        }

        // GET: api/Goods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Good>> GetGood(Guid id)
        {
            var good = await _context.Goods.FindAsync(id);

            if (good == null)
            {
                return NotFound();
            }

            return good;
        }

        // PUT: api/Goods/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGood(Guid id, Good good)
        {
            if (id != good.Id)
            {
                return BadRequest();
            }

            _context.Entry(good).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                //Then create an ItemTicket
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GoodExists(id))
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


        [HttpPost("FindSelectedGood")]
        public async Task<ActionResult<string>> FindSelectedGood(Good good)
        {
            foreach (var item in _context.Goods)
            {
                if (item.ItemName == good.ItemName && item.SharedCategory == good.SharedCategory
                    && item.ItemStatus == good.ItemStatus && item.IsSold == good.IsSold)
                {
                    return Ok(item);
                }
            }

            Good _good = null;
            return Ok(_good);
        }

        // POST: api/Goods
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("CreateGood")]
        public async Task<ActionResult<Good>> CreateGood(Good good)
        {
            GoodDetail goodDetail = new GoodDetail();

            foreach (var item in _context.GoodDetails)
            {
                if(good.ItemName == item.ItemName)
                {
                    goodDetail = item; // Good must be found
                    break;
                }

            }

            good.ActualPrice = Convert.ToDouble(goodDetail.Price);

            bool check = false;

         
                foreach (var item in _context.Goods)
                {
                    if (item.Id == good.Id)
                    {
                        check = true; break;
                    }
                }

                if (check == true) good.Id = Guid.NewGuid();

                _context.Goods.Add(good);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGood", new { id = good.Id }, good);
            //Then create an ItemTicket
        }

        // DELETE: api/Goods/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Good>> DeleteGood(Guid id)
        {
            var good = await _context.Goods.FindAsync(id);
            if (good == null)
            {
                return NotFound();
            }

            _context.Goods.Remove(good);
            await _context.SaveChangesAsync();

            return good;
        }

        private bool GoodExists(Guid id)
        {
            return _context.Goods.Any(e => e.Id == id);
        }
    }
}
