using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_Mysql.Net_5_.Models;

namespace WebApi_Mysql.Net_5_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacacionesController : ControllerBase
    {
        private readonly manejoempleadosContext _context;

        public VacacionesController(manejoempleadosContext context)
        {
            _context = context;
        }

        // GET: api/Vacaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vacacione>>> GetVacaciones()
        {
            return await _context.Vacaciones.ToListAsync();
        }

        // GET: api/Vacaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vacacione>> GetVacacione(int id)
        {
            var vacacione = await _context.Vacaciones.FindAsync(id);

            if (vacacione == null)
            {
                return NotFound();
            }

            return vacacione;
        }

        // PUT: api/Vacaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVacacione(int id, Vacacione vacacione)
        {
            if (id != vacacione.Id)
            {
                return BadRequest();
            }

            _context.Entry(vacacione).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VacacioneExists(id))
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

        // POST: api/Vacaciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vacacione>> PostVacacione(Vacacione vacacione)
        {
            _context.Vacaciones.Add(vacacione);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVacacione", new { id = vacacione.Id }, vacacione);
        }

        // DELETE: api/Vacaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVacacione(int id)
        {
            var vacacione = await _context.Vacaciones.FindAsync(id);
            if (vacacione == null)
            {
                return NotFound();
            }

            _context.Vacaciones.Remove(vacacione);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VacacioneExists(int id)
        {
            return _context.Vacaciones.Any(e => e.Id == id);
        }
    }
}
