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
    public class Booking_Header_MasterController : ControllerBase
    {
        private readonly EtourContext _context;

        public Booking_Header_MasterController(EtourContext context)
        {
            _context = context;
        }

        // GET: api/Booking_Header_Master
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking_Header_Master>>> GetBooking_Header_Masters()
        {
          if (_context.Booking_Header_Masters == null)
          {
              return NotFound();
          }
            return await _context.Booking_Header_Masters.ToListAsync();
        }

        // GET: api/Booking_Header_Master/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Booking_Header_Master>> GetBooking_Header_Master(int id)
        {
          if (_context.Booking_Header_Masters == null)
          {
              return NotFound();
          }
            var booking_Header_Master = await _context.Booking_Header_Masters.FindAsync(id);

            if (booking_Header_Master == null)
            {
                return NotFound();
            }

            return booking_Header_Master;
        }

        // PUT: api/Booking_Header_Master/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooking_Header_Master(int id, Booking_Header_Master booking_Header_Master)
        {
            if (id != booking_Header_Master.Booking_id)
            {
                return BadRequest();
            }

            _context.Entry(booking_Header_Master).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Booking_Header_MasterExists(id))
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

        // POST: api/Booking_Header_Master
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Booking_Header_Master>> PostBooking_Header_Master(Booking_Header_Master booking_Header_Master)
        {
          if (_context.Booking_Header_Masters == null)
          {
              return Problem("Entity set 'EtourContext.Booking_Header_Masters'  is null.");
          }
            _context.Booking_Header_Masters.Add(booking_Header_Master);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBooking_Header_Master", new { id = booking_Header_Master.Booking_id }, booking_Header_Master);
        }

        // DELETE: api/Booking_Header_Master/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking_Header_Master(int id)
        {
            if (_context.Booking_Header_Masters == null)
            {
                return NotFound();
            }
            var booking_Header_Master = await _context.Booking_Header_Masters.FindAsync(id);
            if (booking_Header_Master == null)
            {
                return NotFound();
            }

            _context.Booking_Header_Masters.Remove(booking_Header_Master);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Booking_Header_MasterExists(int id)
        {
            return (_context.Booking_Header_Masters?.Any(e => e.Booking_id == id)).GetValueOrDefault();
        }
    }
}
