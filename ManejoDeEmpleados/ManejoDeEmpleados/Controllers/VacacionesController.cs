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
    public class VacacionesController : Controller
    {
        private readonly manejoempleadosContext _context;

        public VacacionesController(manejoempleadosContext context)
        {
            _context = context;
        }

        // GET: Vacaciones
        public async Task<IActionResult> Index()
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
            if (ModelState.IsValid)
            {
                _context.Add(vacacione);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
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
            return RedirectToAction(nameof(Index));
        }

        private bool VacacioneExists(int id)
        {
            return _context.Vacaciones.Any(e => e.Id == id);
        }
    }
}
