using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Etour.Model;

namespace Etour.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Passanger_TableController : ControllerBase
    {
        private readonly EtourContext _context;

        public Passanger_TableController(EtourContext context)
        {
            _context = context;
        }

        // GET: api/Passanger_Table
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Passanger_Table>>> GetPassenger_Tables()
        {
          if (_context.Passenger_Tables == null)
          {
              return NotFound();
          }
            return await _context.Passenger_Tables.ToListAsync();
        }

        // GET: api/Passanger_Table/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Passanger_Table>> GetPassanger_Table(int id)
        {
          if (_context.Passenger_Tables == null)
          {
              return NotFound();
          }
            var passanger_Table = await _context.Passenger_Tables.FindAsync(id);

            if (passanger_Table == null)
            {
                return NotFound();
            }

            return passanger_Table;
        }

        // PUT: api/Passanger_Table/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPassanger_Table(int id, Passanger_Table passanger_Table)
        {
            if (id != passanger_Table.Pax_id)
            {
                return BadRequest();
            }

            _context.Entry(passanger_Table).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Passanger_TableExists(id))
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

        // POST: api/Passanger_Table
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Passanger_Table>> PostPassanger_Table(Passanger_Table passanger_Table)
        {
          if (_context.Passenger_Tables == null)
          {
              return Problem("Entity set 'EtourContext.Passenger_Tables'  is null.");
          }
            _context.Passenger_Tables.Add(passanger_Table);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPassanger_Table", new { id = passanger_Table.Pax_id }, passanger_Table);
        }

        // DELETE: api/Passanger_Table/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePassanger_Table(int id)
        {
            if (_context.Passenger_Tables == null)
            {
                return NotFound();
            }
            var passanger_Table = await _context.Passenger_Tables.FindAsync(id);
            if (passanger_Table == null)
            {
                return NotFound();
            }

            _context.Passenger_Tables.Remove(passanger_Table);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Passanger_TableExists(int id)
        {
            return (_context.Passenger_Tables?.Any(e => e.Pax_id == id)).GetValueOrDefault();
        }
    }
}
