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
    public class ConsumoEmpleadosController : ControllerBase
    {
        private readonly manejoempleadosContext _context;

        public ConsumoEmpleadosController(manejoempleadosContext context)
        {
            _context = context;
        }

        // GET: api/CosumoEmpleadosController
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConsumoEmpleado>>> GetConusmoEmpleados()
        {
            return await _context.ConsumoEmpleados.ToListAsync();
        }

        // GET: api/ConusmoEmpleados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConsumoEmpleado>> GetConusmoEmpleado(int id)
        {
            var consumo = await _context.ConsumoEmpleados.FindAsync(id);

            if (consumo == null)
            {
                return NotFound();
            }

            return consumo;
        }

        [HttpGet("EmpleadoId/{id}")]
        public async Task<ActionResult<CalcularNomina>> GetEmpleadoNomina(int id)
        {

            var empleadoNomina = await _context.ConsumoEmpleados.FirstOrDefaultAsync(x=> x.EmpleadoId == id);
            var empleadoSueldo = await _context.Empleados.FindAsync(id);

            var Nomina = CalcularNomina.CalculaNomina(empleadoNomina, empleadoSueldo);

            if (empleadoNomina == null)
            {
                return NotFound();
            }

            return Nomina;
        }

        // PUT: api/ConusmoEmpleados/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsumoEmpleado(int id, ConsumoEmpleado empleado)
        {
            if (id != empleado.Id)
            {
                return BadRequest();
            }

            _context.Entry(empleado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConusmoEmpleadoExists(id))
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

        // POST: api/ConusmoEmpleados
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ConsumoEmpleado>> PostConsumoEmpleado(ConsumoEmpleado empleado)
        {
            _context.ConsumoEmpleados.Add(empleado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConusmoEmpleado", new { id = empleado.Id }, empleado);
        }

        // DELETE: api/ConusmoEmpleados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsumoEmpleado(int id)
        {
            var empleado = await _context.ConsumoEmpleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }

            _context.ConsumoEmpleados.Remove(empleado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConusmoEmpleadoExists(int id)
        {
            return _context.ConsumoEmpleados.Any(e => e.Id == id);
        }

    }
}
