using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameStore.Data;
using GameStore.Models.Catalogo;
using GameStore.Models.BindingModel;

namespace GameStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmploymentApplicationController : ControllerBase
    {
        private readonly GameStoreDBContext _context;

        public EmploymentApplicationController(GameStoreDBContext context)
        {
            _context = context;
        }

        // GET: api/EmploymentApplication
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmploymentApplication>>> GetEmploymentApplication()
        {
            return await _context.EmploymentApplication.ToListAsync();
        }

        // GET: api/EmploymentApplication/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmploymentApplication>> GetEmploymentApplication(int id)
        {
            var employmentApplication = await _context.EmploymentApplication.FindAsync(id);

            if (employmentApplication == null)
            {
                return NotFound();
            }

            return employmentApplication;
        }

        [HttpGet("GetEmploymentApplicationByEmail/{email}")]
        public async Task<ActionResult<EmploymentApplication>> GetEmploymentApplicationByEmail(string email)
        {
            try
            {
                var employmentApplication = await _context.EmploymentApplication.Where(x => x.Email == email).FirstOrDefaultAsync();
                return employmentApplication;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet("GetAllEmploymentApplicationsByStatusId/{statusId}")]
        public async Task<IEnumerable<EmploymentApplication>> GetAllEmploymentApplicationsByStatusId(int statusId)
        {
            try
            {
                var employmentApplicationList = await _context.EmploymentApplication.Where(x => x.ApplicationStatus == statusId).ToListAsync();
                return employmentApplicationList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        // PUT: api/EmploymentApplication/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmploymentApplication(int id, EmploymentApplication employmentApplication)
        {
            if (id != employmentApplication.EmploymentApplicationId)
            {
                return BadRequest();
            }

            _context.Entry(employmentApplication).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmploymentApplicationExists(id))
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

        [HttpPost("UpdateApplicationStatus")]
        public async Task<ActionResult<EmploymentApplication>> UpdateApplicationStatus([FromBody] UpdateApplicationStatusEmploymentApplicationBindingModel model)
        {
            try
            {
                var employmentApplication = await _context.EmploymentApplication.Where(x => x.Email == model.Email).SingleAsync();
                employmentApplication.ApplicationStatus = model.ApplicationStatus;
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetEmploymentApplication", new { id = employmentApplication.EmploymentApplicationId }, employmentApplication);

            } catch (Exception ex)
            {
                return null;
            }

        }

        // POST: api/EmploymentApplication
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmploymentApplication>> PostEmploymentApplication(EmploymentApplication employmentApplication)
        {
            _context.EmploymentApplication.Add(employmentApplication);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmploymentApplication", new { id = employmentApplication.EmploymentApplicationId }, employmentApplication);
        }

        // DELETE: api/EmploymentApplication/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmploymentApplication(int id)
        {
            var employmentApplication = await _context.EmploymentApplication.FindAsync(id);
            if (employmentApplication == null)
            {
                return NotFound();
            }

            _context.EmploymentApplication.Remove(employmentApplication);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmploymentApplicationExists(int id)
        {
            return _context.EmploymentApplication.Any(e => e.EmploymentApplicationId == id);
        }
    }
}
