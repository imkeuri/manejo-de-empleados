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
    public class DepartamentopuestoesController : ControllerBase
    {
        private readonly manejoempleadosContext _context;

        public DepartamentopuestoesController(manejoempleadosContext context)
        {
            _context = context;
        }

        // GET: api/Departamentopuestoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Departamentopuesto>>> GetDepartamentopuestos()
        {
            return await _context.Departamentopuestos.ToListAsync();
        }

        // GET: api/Departamentopuestoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Departamentopuesto>> GetDepartamentopuesto(int id)
        {
            var departamentopuesto = await _context.Departamentopuestos.FindAsync(id);

            if (departamentopuesto == null)
            {
                return NotFound();
            }

            return departamentopuesto;
        }

        // PUT: api/Departamentopuestoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartamentopuesto(int id, Departamentopuesto departamentopuesto)
        {
            if (id != departamentopuesto.Id)
            {
                return BadRequest();
            }

            _context.Entry(departamentopuesto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartamentopuestoExists(id))
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

        // POST: api/Departamentopuestoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Departamentopuesto>> PostDepartamentopuesto(Departamentopuesto departamentopuesto)
        {
            _context.Departamentopuestos.Add(departamentopuesto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDepartamentopuesto", new { id = departamentopuesto.Id }, departamentopuesto);
        }

        // DELETE: api/Departamentopuestoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartamentopuesto(int id)
        {
            var departamentopuesto = await _context.Departamentopuestos.FindAsync(id);
            if (departamentopuesto == null)
            {
                return NotFound();
            }

            _context.Departamentopuestos.Remove(departamentopuesto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DepartamentopuestoExists(int id)
        {
            return _context.Departamentopuestos.Any(e => e.Id == id);
        }
    }
}
