using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameStore.Data;
using GameStore.Models.Catalogo;

namespace GameStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationStatusController : ControllerBase
    {
        private readonly GameStoreDBContext _context;

        public ApplicationStatusController(GameStoreDBContext context)
        {
            _context = context;
        }

        // GET: api/ApplicationStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationStatus>>> GetApplicationStatus()
        {
            return await _context.ApplicationStatus.ToListAsync();
        }

        // GET: api/ApplicationStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationStatus>> GetApplicationStatus(int id)
        {
            var applicationStatus = await _context.ApplicationStatus.FindAsync(id);

            if (applicationStatus == null)
            {
                return NotFound();
            }

            return applicationStatus;
        }

        // PUT: api/ApplicationStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApplicationStatus(int id, ApplicationStatus applicationStatus)
        {
            if (id != applicationStatus.ApplicationStatusId)
            {
                return BadRequest();
            }

            _context.Entry(applicationStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationStatusExists(id))
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

        // POST: api/ApplicationStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ApplicationStatus>> PostApplicationStatus(ApplicationStatus applicationStatus)
        {
            _context.ApplicationStatus.Add(applicationStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetApplicationStatus", new { id = applicationStatus.ApplicationStatusId }, applicationStatus);
        }

        // DELETE: api/ApplicationStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplicationStatus(int id)
        {
            var applicationStatus = await _context.ApplicationStatus.FindAsync(id);
            if (applicationStatus == null)
            {
                return NotFound();
            }

            _context.ApplicationStatus.Remove(applicationStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ApplicationStatusExists(int id)
        {
            return _context.ApplicationStatus.Any(e => e.ApplicationStatusId == id);
        }
    }
}
