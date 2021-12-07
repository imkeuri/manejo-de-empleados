using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ManejoDeEmpleados.Models;
using ManejoDeEmpleados.Services;

namespace ManejoDeEmpleados.Controllers
{
    public class NominasController : Controller
    {
        private readonly manejoempleadosContext _context;

        public NominasController(manejoempleadosContext context)
        {
            _context = context;
        }

        // GET: Nominas
        public IActionResult Index()
        {
            return View();
        }

        // GET: Nominas/Details/5
        public async Task<IActionResult> Details(string? codigo)
        {

            ServiceEmpleado service = new();
            ServiceNomina SerNomina = new();

            if (codigo == null)
            {
                return NotFound();
            }


            var empleado = service.GetEmpleadoByCode(codigo);

            if(empleado == null) {
                return NotFound();
            }

            

            var Empleado = await _context.Empleados.FirstOrDefaultAsync(m => m.Id == empleado.Id);

            var consumoEmpleado = await _context.ConsumoEmpleados
                .Include(n => n.Empleado)
                .FirstOrDefaultAsync(x => x.EmpleadoId == empleado.Id);

            var EmpleadoNomina = await _context.Nominas
                .Include(n => n.Empleado)
                .FirstOrDefaultAsync(m => m.EmpleadoId == empleado.Id);


            if (EmpleadoNomina == null)
            {
                return NotFound();
            }else if (consumoEmpleado == null)
            {
                return NotFound("Por favor Realize un consunmo para poder ver su nomina");
            }

            SerNomina.AddNomina(Empleado, consumoEmpleado);
            return View(EmpleadoNomina);
        }

        private bool NominaExists(int id)
        {
            return _context.Nominas.Any(e => e.Id == id);
        }
    }
}
