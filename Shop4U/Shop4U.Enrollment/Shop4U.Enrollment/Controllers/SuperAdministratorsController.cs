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
    public class SuperAdministratorsController : ControllerBase
    {
        private readonly EnrollmentDbContext _context;

        public SuperAdministratorsController(EnrollmentDbContext context)
        {
            _context = context;
        }

        // GET: api/SuperAdministrators
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SuperAdministrator>>> GetSuperAdministrators()
        {
            return await _context.SuperAdministrators.ToListAsync();
        }

        // GET: api/SuperAdministrators/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperAdministrator>> GetSuperAdministrator(Guid id)
        {
            var superAdministrator = await _context.SuperAdministrators.FindAsync(id);

            if (superAdministrator == null)
            {
                return NotFound();
            }

            return superAdministrator;
        }

        // PUT: api/SuperAdministrators/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSuperAdministrator(Guid id, SuperAdministrator superAdministrator)
        {
            if (id != superAdministrator.Id)
            {
                return BadRequest();
            }

            _context.Entry(superAdministrator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuperAdministratorExists(id))
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

        //POST: $"api/{controllerName}/PostSuperAdministrator";
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        [Route("PostSuperAdministrator")]
        public async Task<ActionResult<SuperAdministrator>> PostSuperAdministrator(SuperAdministrator superAdministrator)
        {

            if (superAdministrator != null)
            {
                
                    if (superAdministrator.Id == null) superAdministrator.Id = Guid.NewGuid();
                    await _context.SuperAdministrators.AddAsync(superAdministrator);
                    await _context.SaveChangesAsync();
                    return Ok(superAdministrator);

            }

            return Ok(superAdministrator);
        }


        //POST: $"api/{controllerName}/LoginSuperAdministrator/{isLogin}";
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        [Route("LoginSuperAdministrator/{IsLogin}")]
        public async Task<ActionResult<SuperAdministrator>> LoginSuperAdministrator(SuperAdministrator superAdministrator,bool isLogin)
        {
            //public bool ToLogin { get; set; }

            if (superAdministrator != null)
            {
                    var superAdmins = await _context.SuperAdministrators.ToListAsync();
                    foreach (var item in superAdmins)
                    {
                        if (superAdministrator.UserName == item.UserName && superAdministrator.Password == item.Password)
                        {
                            superAdministrator = item;
                            superAdministrator.UserType = "SuperAdmin";
                            return Ok(superAdministrator);

                        }
                    }


            }
            superAdministrator.UserType = "";
            return Ok(superAdministrator);
        }

        // DELETE: api/SuperAdministrators/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SuperAdministrator>> DeleteSuperAdministrator(Guid id)
        {
            var superAdministrator = await _context.SuperAdministrators.FindAsync(id);
            if (superAdministrator == null)
            {
                return NotFound();
            }

            _context.SuperAdministrators.Remove(superAdministrator);
            await _context.SaveChangesAsync();

            return superAdministrator;
        }

        private bool SuperAdministratorExists(Guid id)
        {
            return _context.SuperAdministrators.Any(e => e.Id == id);
        }
    }
}
