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
    public class VacacionesestadoesController : ControllerBase
    {
        private readonly manejoempleadosContext _context;

        public VacacionesestadoesController(manejoempleadosContext context)
        {
            _context = context;
        }

        // GET: api/Vacacionesestadoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vacacionesestado>>> GetVacacionesestados()
        {
            return await _context.Vacacionesestados.ToListAsync();
        }

        // GET: api/Vacacionesestadoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vacacionesestado>> GetVacacionesestado(int id)
        {
            var vacacionesestado = await _context.Vacacionesestados.FindAsync(id);

            if (vacacionesestado == null)
            {
                return NotFound();
            }

            return vacacionesestado;
        }

        // PUT: api/Vacacionesestadoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVacacionesestado(int id, Vacacionesestado vacacionesestado)
        {
            if (id != vacacionesestado.Id)
            {
                return BadRequest();
            }

            _context.Entry(vacacionesestado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VacacionesestadoExists(id))
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

        // POST: api/Vacacionesestadoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vacacionesestado>> PostVacacionesestado(Vacacionesestado vacacionesestado)
        {
            _context.Vacacionesestados.Add(vacacionesestado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVacacionesestado", new { id = vacacionesestado.Id }, vacacionesestado);
        }

        // DELETE: api/Vacacionesestadoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVacacionesestado(int id)
        {
            var vacacionesestado = await _context.Vacacionesestados.FindAsync(id);
            if (vacacionesestado == null)
            {
                return NotFound();
            }

            _context.Vacacionesestados.Remove(vacacionesestado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VacacionesestadoExists(int id)
        {
            return _context.Vacacionesestados.Any(e => e.Id == id);
        }
    }
}
