using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftwareForecasting.Models;
using SoftwareForecasting.Utils;
using SoftwareForecasting.DTO;
using Microsoft.AspNetCore.Hosting;
using System.Text;
using OfficeOpenXml;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using SoftwareForecasting.Mathematics;

namespace SoftwareForecasting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InputDecksController : ControllerBase
    {
        private readonly ForecastDbContext _context;
        private readonly IHostingEnvironment hostingEnvironment;

        public InputDecksController(ForecastDbContext context, IHostingEnvironment _hostingEnvironment)
        {
            hostingEnvironment = _hostingEnvironment;
            _context = context;
        }

        // GET: api/InputDecks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InputDeck>>> GetInputDecks()
        {
            return await _context.InputDecks.ToListAsync();
        }

        // GET: api/InputDecks/inputDeckId
        [HttpGet("inputdecks/{inputDeckId}", Name = "GetInputDecksByInputDeckId")]
        public async Task<ActionResult<IEnumerable<InputDeck>>> GetInputDecksByInputDeckId(Guid inputDeckId)
        {

            var records = await _context.InputDecks.ToListAsync();
            List<InputDeck> selectedInputDecks = new List<InputDeck>();
            foreach (var inputdeck in selectedInputDecks)
            {
                if (inputDeckId == inputdeck.InputDeckId)
                {
                    selectedInputDecks.Add(inputdeck);
                }
            }

            return Ok(selectedInputDecks);
        }


        // GET: api/InputDecks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InputDeck>> GetInputDeck(Guid id)
        {
            var inputDeck = await _context.InputDecks.FindAsync(id);

            if (inputDeck == null)
            {
                return NotFound();
            }

            return inputDeck;
        }

        // PUT: api/InputDecks/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInputDeck(Guid id, InputDeck inputDeck)
        {
            if (id != inputDeck.id)
            {
                return BadRequest();
            }

            _context.Entry(inputDeck).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InputDeckExists(id))
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

        // POST: api/InputDecks
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<InputDeck>> PostInputDeck(InputDeck inputDeck)
        {
            _context.InputDecks.Add(inputDeck);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInputDeck", new { id = inputDeck.id }, inputDeck);
        }

        [HttpPost("saveinputdeck", Name = "saveinputdeck")]
        public async Task<ActionResult<InputDeckDTO>> saveinputdeck(InputDeckDTO inputDeckDTO)
        {
            try
            {
                for (int i = 0; i < inputDeckDTO.decks.Count; i++)
                {
                    _context.InputDecks.Add(inputDeckDTO.decks[i]);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {


            }


            return Ok(inputDeckDTO);
        }



        //Step 1
        [HttpPost("UploadFile")]
        public async Task<ActionResult<string>> UploadFile(IFormFile file)
        {
            //if (this.Request.Form.Files.Count < 0)
            //{
            //    return return NotFound();
            //}

            //IFormFile file = Request.Form.Files[0];

            if (file.Length < 0)
            {
                return NotFound();
            }

            
            string sWebRootFolder = hostingEnvironment.WebRootPath;
            string directoryName = "Upload";
            string directorypath = Path.Combine(sWebRootFolder, directoryName);

            DirectoryInfo directory = new DirectoryInfo(directorypath);
            foreach (var _file in directory.GetFiles())
            {
                if(file.FileName == _file.Name)
                {
                    _file.Delete();
                }
               
            }

           

            var fileName = Path.Combine(directorypath, Path.GetFileName(file.FileName));

            file.CopyTo(new FileStream(fileName, FileMode.Create));

            return Ok(file.FileName);

            //return DemoResponse<List<CustomExcelWorkSheet>>.GetResult(200, file.FileName);

        }

        //Step 2
        [HttpPost("GetSheetNames")]
        public async Task<ActionResult<string>> GetSheetNames(string fileName)
        {
            
            Integration.TestArrayOfInts();

            List<string> sheetNames = Util.ReadExcel(hostingEnvironment, fileName);

            return Ok(sheetNames);
        }

        //Step 3
        [HttpPost("GetVariableNames")]
        public async Task<ActionResult<List<string>>> GetVariableNames(MappedData mappedData)
        {
            List<string> ColumnHeadersNames = Util.GetVariableNames(hostingEnvironment, mappedData.SheetName, mappedData.FileName);

            return Ok(ColumnHeadersNames);
        }

        //Step 4
        [HttpPost("GetAutoMappedVariables")]
        public async Task<ActionResult<MappedData>> GetAutoMappedVariables(MappedData mappedData)
        {
            var props = typeof(InputDeck).GetProperties();
            MappedData _mappedData = Util.AutoMapper(mappedData.ColumnHeadersCopy, props);

            return Ok(_mappedData);
        }

        //Step 5
        [HttpPost("GetCrossCheckedData")]
        public async Task<ActionResult<InputDeck>> GetCrossCheckedData(MappedData mappedData)
        {
            List<ExtendedInputDeck> decks = new List<ExtendedInputDeck>();

            List<ExtendedInputDeck> ExtendedInputDecks = Util.GetCrossCheckedDecks(mappedData.MappedDictionary, hostingEnvironment,
                mappedData.SheetName, mappedData.FileName, mappedData.StartRow, mappedData.EndRow);

            try
            {
                byte[] data = ByteUtil.SerializeToByteArray(ExtendedInputDecks);

                HttpContext.Session.Set(ReadonlyNames.ExtendedInputDecks, data);


                if (mappedData.StartRow <= 0) mappedData.StartRow = 1;

                for (int i = mappedData.StartRow - 1; i < mappedData.EndRow; i++)
                {
                    decks.Add(ExtendedInputDecks[i]);

                }
            }
            catch (Exception ex)
            {

            }



            return Ok(decks);
        }


        


        [HttpDelete("{id}")]
        public async Task<ActionResult<InputDeck>> DeleteInputDeck(Guid id)
        {
            var inputDeck = await _context.InputDecks.FindAsync(id);
            if (inputDeck == null)
            {
                return NotFound();
            }

            _context.InputDecks.Remove(inputDeck);
            await _context.SaveChangesAsync();

            return inputDeck;
        }

        private bool InputDeckExists(Guid id)
        {
            return _context.InputDecks.Any(e => e.id == id);
        }
    }
}
