using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ManejoDeEmpleados.Models;
using Microsoft.AspNetCore.Authorization;
using ManejoDeEmpleados.Services;

namespace ManejoDeEmpleados.Controllers
{
    public class EmpleadoesController : Controller
    {
        private readonly manejoempleadosContext _context;

        public EmpleadoesController(manejoempleadosContext context)
        {
            _context = context;
        }

        // GET: Empleadoes
        [Authorize(Roles = "admin")] 
        public async Task<IActionResult> Index()
        {
            var manejoempleadosContext = _context.Empleados.Include(e => e.DepartamentoPuesto);
            return View(await manejoempleadosContext.ToListAsync());
        }

        // GET: Empleadoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados
                .Include(e => e.DepartamentoPuesto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // GET: Empleadoes/Create
        public IActionResult Create()
        {
            ViewData["DepartamentoPuestoId"] = new SelectList(_context.Departamentopuestos, "Id", "Nombre");
            return View();
        }

        // POST: Empleadoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Telefono,Correo,FechaNacimiento,DepartamentoPuestoId,FechaContratacion,SueldoEmpleado")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                ServiceEmpleado service = new();
                ServiceNomina SerNomina = new();
                service.GenerarSecuencia(empleado);
                _context.Add(empleado);
                await _context.SaveChangesAsync();
                SerNomina.AddNomina(empleado);
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartamentoPuestoId"] = new SelectList(_context.Departamentopuestos, "Id", "Nombre", empleado.DepartamentoPuestoId);
            return View(empleado);
        }

        // GET: Empleadoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }
            ViewData["DepartamentoPuestoId"] = new SelectList(_context.Departamentopuestos, "Id", "Nombre", empleado.DepartamentoPuestoId);
            return View(empleado);
        }

        // POST: Empleadoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,Telefono,Correo,FechaNacimiento,DepartamentoPuestoId,FechaContratacion,SueldoEmpleado")] Empleado empleado)
        {
            if (id != empleado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoExists(empleado.Id))
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
            ViewData["DepartamentoPuestoId"] = new SelectList(_context.Departamentopuestos, "Id", "Nombre", empleado.DepartamentoPuestoId);
            return View(empleado);
        }

        // GET: Empleadoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados
                .Include(e => e.DepartamentoPuesto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // POST: Empleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadoExists(int id)
        {
            return _context.Empleados.Any(e => e.Id == id);
        }
    }
}
