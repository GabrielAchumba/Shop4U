using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftwareForecasting.Models;
using SoftwareForecasting.Utils;

namespace SoftwareForecasting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilityDecksController : ControllerBase
    {
        private readonly ForecastDbContext _context;
        private readonly IHostingEnvironment hostingEnvironment;

        public FacilityDecksController(ForecastDbContext context, IHostingEnvironment _hostingEnvironment)
        {
            hostingEnvironment = _hostingEnvironment;
            _context = context;
        }

        // GET: api/FacilityDecks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FacilityDeck>>> GetFacilityDecks()
        {
            return await _context.FacilityDecks.ToListAsync();
        }

        // GET: api/FacilityDecks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FacilityDeck>> GetFacilityDeck(Guid id)
        {
            var facilityDeck = await _context.FacilityDecks.FindAsync(id);

            if (facilityDeck == null)
            {
                return NotFound();
            }

            return facilityDeck;
        }

        // PUT: api/FacilityDecks/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFacilityDeck(Guid id, FacilityDeck facilityDeck)
        {
            if (id != facilityDeck.id)
            {
                return BadRequest();
            }

            _context.Entry(facilityDeck).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacilityDeckExists(id))
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

        // POST: api/FacilityDecks
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<FacilityDeck>> PostFacilityDeck(FacilityDeck facilityDeck)
        {
            _context.FacilityDecks.Add(facilityDeck);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFacilityDeck", new { id = facilityDeck.id }, facilityDeck);
        }

        // DELETE: api/FacilityDecks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FacilityDeck>> DeleteFacilityDeck(Guid id)
        {
            var facilityDeck = await _context.FacilityDecks.FindAsync(id);
            if (facilityDeck == null)
            {
                return NotFound();
            }

            _context.FacilityDecks.Remove(facilityDeck);
            await _context.SaveChangesAsync();

            return facilityDeck;
        }

        private bool FacilityDeckExists(Guid id)
        {
            return _context.FacilityDecks.Any(e => e.id == id);
        }

        #region Wizard for Importing Facility Data

        //Step 1
        [HttpPost("upload", Name = "upload")]
        public async Task<ActionResult<string>> upload(IFormFile file)
        {

            if (file.Length < 0)
            {
                return NotFound();
            }


            string sWebRootFolder = hostingEnvironment.WebRootPath;
            string directoryName = "Facility";
            string directorypath = Path.Combine(sWebRootFolder, directoryName);

            DirectoryInfo directory = new DirectoryInfo(directorypath);
            foreach (var _file in directory.GetFiles())
            {
                _file.Delete();
            }



            var fileName = Path.Combine(directorypath, Path.GetFileName(file.FileName));

            file.CopyTo(new FileStream(fileName, FileMode.Create));

            return Ok(file.FileName);

        }

        //Step 2
        [HttpPost("GetSheetNames")]
        public async Task<ActionResult<string>> GetSheetNames(string fileName)
        {
            List<string> sheetNames = Util.ReadExcel(hostingEnvironment, fileName, "Facility");

            return Ok(sheetNames);
        }

        //Step 3
        [HttpPost("GetVariableNames")]
        public async Task<ActionResult<List<string>>> GetVariableNames(MappedData mappedData)
        {
            List<string> ColumnHeadersNames = Util.GetVariableNames(hostingEnvironment, mappedData.SheetName, mappedData.FileName,
                "Facility");

            return Ok(ColumnHeadersNames);
        }

        //Step 4
        [HttpPost("GetAutoMappedVariables")]
        public async Task<ActionResult<MappedData>> GetAutoMappedVariables(MappedData mappedData)
        {
            var props = typeof(FacilityDeck).GetProperties();
            MappedData _mappedData = Util.AutoMapper(mappedData.ColumnHeadersCopy, props);

            return Ok(_mappedData);
        }

        //Step 5
        [HttpPost("GetCrossCheckedData")]
        public async Task<ActionResult<ExtendedFacilityDeck>> GetCrossCheckedData(MappedData mappedData)
        {
            List<ExtendedInputDeck> decks = new List<ExtendedInputDeck>();

            List<ExtendedFacilityDeck> ExtendedFacilityDecks = Util.GetCrossCheckedFacilityDecks(mappedData.MappedDictionary, hostingEnvironment,
                mappedData.SheetName, mappedData.FileName);

            try
            {
                byte[] data = ByteUtil.SerializeToByteArray(ExtendedFacilityDecks);

                HttpContext.Session.Set(ReadonlyNames.ExtendedFacilityDecks, data);

            }
            catch (Exception ex)
            {

            }



            return Ok(ExtendedFacilityDecks);
        }
        #endregion
    }
}
