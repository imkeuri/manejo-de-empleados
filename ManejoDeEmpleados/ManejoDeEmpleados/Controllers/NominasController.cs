using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ManejoDeEmpleados.Models;

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
        public async Task<IActionResult> Index()
        {
            var manejoempleadosContext = _context.Nominas.Include(n => n.Empleado);
            return View(await manejoempleadosContext.ToListAsync());
        }

        // GET: Nominas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nomina = await _context.Nominas
                .Include(n => n.Empleado)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nomina == null)
            {
                return NotFound();
            }

            return View(nomina);
        }

        private bool NominaExists(int id)
        {
            return _context.Nominas.Any(e => e.Id == id);
        }
    }
}
