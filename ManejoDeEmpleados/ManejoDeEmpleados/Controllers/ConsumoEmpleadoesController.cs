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
    public class ConsumoEmpleadoesController : Controller
    {
        private readonly manejoempleadosContext _context;

        public ConsumoEmpleadoesController(manejoempleadosContext context)
        {
            _context = context;
        }

        // GET: ConsumoEmpleadoes
        public async Task<IActionResult> Index()
        {
            var manejoempleadosContext = _context.ConsumoEmpleados.Include(c => c.Empleado);
            return View(await manejoempleadosContext.ToListAsync());
        }

        // GET: ConsumoEmpleadoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumoEmpleado = await _context.ConsumoEmpleados
                .Include(c => c.Empleado)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consumoEmpleado == null)
            {
                return NotFound();
            }

            return View(consumoEmpleado);
        }

        // GET: ConsumoEmpleadoes/Create
        public IActionResult Create()
        {
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Apellido");
            return View();
        }

        // POST: ConsumoEmpleadoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cooperativa,Comision,Cafeteria,EmpleadoId")] ConsumoEmpleado consumoEmpleado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consumoEmpleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Apellido", consumoEmpleado.EmpleadoId);
            return View(consumoEmpleado);
        }

        // GET: ConsumoEmpleadoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumoEmpleado = await _context.ConsumoEmpleados.FindAsync(id);
            if (consumoEmpleado == null)
            {
                return NotFound();
            }
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Apellido", consumoEmpleado.EmpleadoId);
            return View(consumoEmpleado);
        }

        // POST: ConsumoEmpleadoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cooperativa,Comision,Cafeteria,EmpleadoId")] ConsumoEmpleado consumoEmpleado)
        {
            if (id != consumoEmpleado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consumoEmpleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsumoEmpleadoExists(consumoEmpleado.Id))
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
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Apellido", consumoEmpleado.EmpleadoId);
            return View(consumoEmpleado);
        }

        // GET: ConsumoEmpleadoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumoEmpleado = await _context.ConsumoEmpleados
                .Include(c => c.Empleado)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consumoEmpleado == null)
            {
                return NotFound();
            }

            return View(consumoEmpleado);
        }

        // POST: ConsumoEmpleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consumoEmpleado = await _context.ConsumoEmpleados.FindAsync(id);
            _context.ConsumoEmpleados.Remove(consumoEmpleado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsumoEmpleadoExists(int id)
        {
            return _context.ConsumoEmpleados.Any(e => e.Id == id);
        }
    }
}
