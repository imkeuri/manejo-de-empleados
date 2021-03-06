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
    public class VacacionesController : Controller
    {
        private readonly manejoempleadosContext _context;

        public VacacionesController(manejoempleadosContext context)
        {
            _context = context;
        }

        public IActionResult VerificarCodigo()
        {

            return View();
        }

        // GET: Vacaciones
        public async Task<IActionResult> Index(string codigo)
        {
            ServiceEmpleado service = new();
            ServiceNomina SerNomina = new();



            if (codigo == null)
            {
                return NotFound();
            }


            var empleado = service.GetEmpleadoByCode(codigo);

            if (empleado == null)
            {
                return NotFound();
            }

            var Empleado = _context.Empleados.FirstOrDefault(m => m.Id == empleado.Id);

            DateTime fechaTiempo = DateTime.Now.Date;

            empleado.FechaContratacion = empleado.FechaContratacion.Date;

            TimeSpan time = fechaTiempo - empleado.FechaContratacion;

            int dias = time.Days;

            if (dias <= 365)
            {
                return NotFound("Debes de tener por lo menos un año para poder solicitar Vacaciones");
            }

            var manejoempleadosContext = _context.Vacaciones.Include(v => v.Empleado);
            return View(await manejoempleadosContext.ToListAsync());
        }
        
        public async Task<IActionResult> List()
        {
            var manejoempleadosContext = _context.Vacaciones.Include(v => v.Empleado);
            return View(await manejoempleadosContext.ToListAsync());
        }

        // GET: Vacaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacacione = await _context.Vacaciones
                .Include(v => v.Empleado)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vacacione == null)
            {
                return NotFound();
            }

            return View(vacacione);
        }

        // GET: Vacaciones/Create
        public IActionResult Create()
        {

            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Apellido");
            return View();
        }

        // POST: Vacaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,InicioVacaciones,HastaVacaciones,EmpleadoId")] Vacacione vacacione)
        {
            ServiceEstadoVacaciones estadoVacaciones = new ServiceEstadoVacaciones();

            if (ModelState.IsValid)
            {
                _context.Add(vacacione);
                await _context.SaveChangesAsync();
                var EmpleadoE = await _context.Vacaciones.FirstOrDefaultAsync(m => m.Id == vacacione.Id);
                estadoVacaciones.AddVacacionesEstados(EmpleadoE);
                return RedirectToAction(nameof(VerificarCodigo));
            }
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Apellido", vacacione.EmpleadoId);
            return View(vacacione);
        }

        // GET: Vacaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacacione = await _context.Vacaciones.FindAsync(id);
            if (vacacione == null)
            {
                return NotFound();
            }
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Apellido", vacacione.EmpleadoId);
            return View(vacacione);
        }

        // POST: Vacaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,InicioVacaciones,HastaVacaciones,EmpleadoId")] Vacacione vacacione)
        {
            if (id != vacacione.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vacacione);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VacacioneExists(vacacione.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Apellido", vacacione.EmpleadoId);
            return View(vacacione);
        }

        // GET: Vacaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacacione = await _context.Vacaciones
                .Include(v => v.Empleado)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vacacione == null)
            {
                return NotFound();
            }

            return View(vacacione);
        }

        // POST: Vacaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vacacione = await _context.Vacaciones.FindAsync(id);
            _context.Vacaciones.Remove(vacacione);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }

        private bool VacacioneExists(int id)
        {
            return _context.Vacaciones.Any(e => e.Id == id);
        }
    }
}
