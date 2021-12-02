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
    public class DepartamentoclsController : ControllerBase
    {
        private readonly manejoempleadosContext _context;

        public DepartamentoclsController(manejoempleadosContext context)
        {
            _context = context;
        }

        // GET: api/Departamentocls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Departamentocl>>> GetDepartamentocls()
        {
            return await _context.Departamentocls.ToListAsync();
        }

        // GET: api/Departamentocls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Departamentocl>> GetDepartamentocl(int id)
        {
            var departamentocl = await _context.Departamentocls.FindAsync(id);

            if (departamentocl == null)
            {
                return NotFound();
            }

            return departamentocl;
        }

        // PUT: api/Departamentocls/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartamentocl(int id, Departamentocl departamentocl)
        {
            if (id != departamentocl.Id)
            {
                return BadRequest();
            }

            _context.Entry(departamentocl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartamentoclExists(id))
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

        // POST: api/Departamentocls
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Departamentocl>> PostDepartamentocl(Departamentocl departamentocl)
        {
            _context.Departamentocls.Add(departamentocl);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDepartamentocl", new { id = departamentocl.Id }, departamentocl);
        }

        // DELETE: api/Departamentocls/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartamentocl(int id)
        {
            var departamentocl = await _context.Departamentocls.FindAsync(id);
            if (departamentocl == null)
            {
                return NotFound();
            }

            _context.Departamentocls.Remove(departamentocl);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DepartamentoclExists(int id)
        {
            return _context.Departamentocls.Any(e => e.Id == id);
        }
    }
}
