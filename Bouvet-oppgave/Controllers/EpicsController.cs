using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bouvet_oppgave.Data;
using Bouvet_oppgave.Models;

namespace Bouvet_oppgave.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EpicsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EpicsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Epics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Epic>>> GetEpics()
        {
          if (_context.Epics == null)
          {
              return NotFound();
          }
            return await _context.Epics.ToListAsync();
        }

        // GET: api/Epics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Epic>> GetEpic(int id)
        {
          if (_context.Epics == null)
          {
              return NotFound();
          }
            var epic = await _context.Epics.FindAsync(id);

            if (epic == null)
            {
                return NotFound();
            }

            return epic;
        }

        // PUT: api/Epics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEpic(int id, Epic epic)
        {
            if (id != epic.Id)
            {
                return BadRequest();
            }

            _context.Entry(epic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EpicExists(id))
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

        // POST: api/Epics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Epic>> PostEpic(Epic epic)
        {
          if (_context.Epics == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Epics'  is null.");
          }
            _context.Epics.Add(epic);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEpic", new { id = epic.Id }, epic);
        }

        // DELETE: api/Epics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEpic(int id)
        {
            if (_context.Epics == null)
            {
                return NotFound();
            }
            var epic = await _context.Epics.FindAsync(id);
            if (epic == null)
            {
                return NotFound();
            }

            _context.Epics.Remove(epic);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EpicExists(int id)
        {
            return (_context.Epics?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
