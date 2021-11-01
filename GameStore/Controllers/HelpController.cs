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
    public class HelpController : ControllerBase
    {
        private readonly GameStoreDBContext _context;

        public HelpController(GameStoreDBContext context)
        {
            _context = context;
        }

        // GET: api/Help
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Help>>> GetHelp()
        {
            return await _context.Help.ToListAsync();
        }

        // GET: api/Help/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Help>> GetHelp(int id)
        {
            var help = await _context.Help.FindAsync(id);

            if (help == null)
            {
                return NotFound();
            }

            return help;
        }

        // PUT: api/Help/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHelp(int id, Help help)
        {
            if (id != help.HelpId)
            {
                return BadRequest();
            }

            _context.Entry(help).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HelpExists(id))
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

        // POST: api/Help
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Help>> PostHelp(Help help)
        {
            _context.Help.Add(help);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHelp", new { id = help.HelpId }, help);
        }

        // DELETE: api/Help/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHelp(int id)
        {
            var help = await _context.Help.FindAsync(id);
            if (help == null)
            {
                return NotFound();
            }

            _context.Help.Remove(help);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HelpExists(int id)
        {
            return _context.Help.Any(e => e.HelpId == id);
        }
    }
}
