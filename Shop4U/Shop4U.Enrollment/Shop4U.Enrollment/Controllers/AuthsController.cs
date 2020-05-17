using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop4U.Enrollment.Models;

using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Twilio.TwiML;
using Twilio.AspNet.Core;
using Twilio.Exceptions;

namespace Shop4U.Enrollment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController :TwilioController 
    {
        private readonly EnrollmentDbContext _context;

        public AuthsController(EnrollmentDbContext context)
        {
            _context = context;
        }

        // GET: api/Auths
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Auth>>> GetAuths()
        {
            return await _context.Auths.ToListAsync();
        }

        // GET: api/Auths/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Auth>> GetAuth(Guid id)
        {
            var auth = await _context.Auths.FindAsync(id);

            if (auth == null)
            {
                return NotFound();
            }

            return auth;
        }

        // PUT: api/Auths/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuth(Guid id, Auth auth)
        {
            if (id != auth.Id)
            {
                return BadRequest();
            }

            _context.Entry(auth).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthExists(id))
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

        // POST: api/Auths
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Auth>> PostAuth(Auth auth)
        {
            const string accountSid = "AC4378f779e88c02102b987c59a53a0062";
            const string authToken = "f74d57bd84f7cbc807be72f6b8416741";

            string OTPCode = "11111";
            string msg = "Please enter the verification code: " + OTPCode;

            TwilioClient.Init(accountSid, authToken);

            var from = new Twilio.Types.PhoneNumber("+12342043581");
            var to = new Twilio.Types.PhoneNumber("+2347032488605");
            

            var message = MessageResource.Create(
                to: to,
                from: from,
                body: msg
            );

            Console.WriteLine(message.Sid);


            _context.Auths.Add(auth);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuth", new { id = auth.Id }, auth);
        }

        // DELETE: api/Auths/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Auth>> DeleteAuth(Guid id)
        {
            var auth = await _context.Auths.FindAsync(id);
            if (auth == null)
            {
                return NotFound();
            }

            _context.Auths.Remove(auth);
            await _context.SaveChangesAsync();

            return auth;
        }

        private bool AuthExists(Guid id)
        {
            return _context.Auths.Any(e => e.Id == id);
        }
    }
}
