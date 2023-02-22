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
    public class Itinerery_MasterController : ControllerBase
    {
        private readonly EtourContext _context;

        public Itinerery_MasterController(EtourContext context)
        {
            _context = context;
        }

        // GET: api/Itinerery_Master
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Itinerery_Master>>> GetItireneries()
        {
          if (_context.Itireneries == null)
          {
              return NotFound();
          }
            return await _context.Itireneries.ToListAsync();
        }

        // GET: api/Itinerery_Master/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Itinerery_Master>> GetItinerery_Master(int id)
        {
          if (_context.Itireneries == null)
          {
              return NotFound();
          }
            var itinerery_Master = await _context.Itireneries.FindAsync(id);

            if (itinerery_Master == null)
            {
                return NotFound();
            }

            return itinerery_Master;
        }

        // PUT: api/Itinerery_Master/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItinerery_Master(int id, Itinerery_Master itinerery_Master)
        {
            if (id != itinerery_Master.itr_Id)
            {
                return BadRequest();
            }

            _context.Entry(itinerery_Master).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Itinerery_MasterExists(id))
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

        // POST: api/Itinerery_Master
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Itinerery_Master>> PostItinerery_Master(Itinerery_Master itinerery_Master)
        {
          if (_context.Itireneries == null)
          {
              return Problem("Entity set 'EtourContext.Itireneries'  is null.");
          }
            _context.Itireneries.Add(itinerery_Master);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItinerery_Master", new { id = itinerery_Master.itr_Id }, itinerery_Master);
        }

        // DELETE: api/Itinerery_Master/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItinerery_Master(int id)
        {
            if (_context.Itireneries == null)
            {
                return NotFound();
            }
            var itinerery_Master = await _context.Itireneries.FindAsync(id);
            if (itinerery_Master == null)
            {
                return NotFound();
            }

            _context.Itireneries.Remove(itinerery_Master);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Itinerery_MasterExists(int id)
        {
            return (_context.Itireneries?.Any(e => e.itr_Id == id)).GetValueOrDefault();
        }
    }
}
