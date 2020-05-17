using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftwareForecasting.DTO;
using SoftwareForecasting.Forecast;
using SoftwareForecasting.Models;
using SoftwareForecasting.Utils;

namespace SoftwareForecasting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForecastResultsController : ControllerBase
    {
        private readonly ForecastDbContext _context;

        public ForecastResultsController(ForecastDbContext context)
        {
            _context = context;
        }

        // GET: api/ForecastResults
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ForecastResult>>> GetForecastResults()
        {
            return await _context.ForecastResults.ToListAsync();
        }

        // GET: api/ForecastResults/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ForecastResult>> GetForecastResult(Guid id)
        {
            var forecastResult = await _context.ForecastResults.FindAsync(id);

            if (forecastResult == null)
            {
                return NotFound();
            }

            return forecastResult;
        }

        [HttpGet("RunForecast")]
        public async Task<ActionResult<List<ForecastResult>>> RunForecast(ForecastDTO forecastDTO)
        {
            byte[] deckbytes = HttpContext.Session.Get(ReadonlyNames.ExtendedInputDecks);
            List<ExtendedInputDeck> ExtendedInputDecks = ByteUtil.Deserialize(deckbytes) as List<ExtendedInputDeck>;

            byte[] facilitybytes = HttpContext.Session.Get(ReadonlyNames.ExtendedFacilityDecks);
            List<ExtendedFacilityDeck> ExtendedFacilityDecks = ByteUtil.Deserialize(facilitybytes) as List<ExtendedFacilityDeck>;

            List<DateTime> dates = DateCreation.GetDateList(ExtendedInputDecks, forecastDTO.StopDate);

            var facilities = GrouppingFacilities.GetFacilitiesByGroup(ref ExtendedFacilityDecks, ref ExtendedInputDecks);

            var facilities_1P1C = new Dictionary<ExtendedFacilityDeck, List<ExtendedInputDeck>>(facilities);
            var facilities_2P2C = new Dictionary<ExtendedFacilityDeck, List<ExtendedInputDeck>>(facilities);
            var facilities_3P3C = new Dictionary<ExtendedFacilityDeck, List<ExtendedInputDeck>>(facilities);

            
            await CalculateDeckVariables.GetDeckVariables(facilities_1P1C, dates, 1);
            await CalculateDeckVariables.GetDeckVariables(facilities_2P2C, dates, 2);
            await CalculateDeckVariables.GetDeckVariables(facilities_3P3C, dates, 3);

            

            return Ok(null);
        }

        // PUT: api/ForecastResults/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutForecastResult(Guid id, ForecastResult forecastResult)
        {
            if (id != forecastResult.id)
            {
                return BadRequest();
            }

            _context.Entry(forecastResult).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ForecastResultExists(id))
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

        // POST: api/ForecastResults
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ForecastResult>> PostForecastResult(ForecastResult forecastResult)
        {
            _context.ForecastResults.Add(forecastResult);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetForecastResult", new { id = forecastResult.id }, forecastResult);
        }

        // DELETE: api/ForecastResults/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ForecastResult>> DeleteForecastResult(Guid id)
        {
            var forecastResult = await _context.ForecastResults.FindAsync(id);
            if (forecastResult == null)
            {
                return NotFound();
            }

            _context.ForecastResults.Remove(forecastResult);
            await _context.SaveChangesAsync();

            return forecastResult;
        }

        private bool ForecastResultExists(Guid id)
        {
            return _context.ForecastResults.Any(e => e.id == id);
        }
    }
}
