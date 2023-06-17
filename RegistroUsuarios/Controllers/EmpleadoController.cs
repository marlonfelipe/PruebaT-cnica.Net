using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RegistroUsuarios.Models;

namespace RegistroUsuarios.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly DbtestContext _context;

        public EmpleadoController(DbtestContext context)
        {
            _context = context;
        }

        // GET: Empleado
        public async Task<IActionResult> Index()
        {
              return View(await _context.Empleado.ToListAsync());
        }

        // GET: Empleado/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Empleado == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleado
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // GET: Empleado/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Empleado/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DPI,NombreCompleto,CantidadHijos,SalarioBase,BonoDecreto,Usuario,FechaCreacion,Igss,Irtra,BonoPaternidad,SalarioTotal,SalarioLiquido")] Empleado empleado)
        {
            empleado.BonoDecreto = 250;

            empleado.CalcularValores();

            if (ModelState.IsValid)

            {
                _context.Add(empleado);
                Console.WriteLine(empleado.ToString());
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException ex)
                {
                    var innerException = ex.InnerException;

                    Console.WriteLine(innerException.Message);

                    throw;

                }


                return RedirectToAction(nameof(Index));
            }
            return View(empleado);
        }

        // GET: Empleado/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Empleado == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleado.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }
            return View(empleado);
        }

        // POST: Empleado/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DPI,NombreCompleto,CantidadHijos,SalarioBase,BonoDecreto,Usuario,FechaCreacion,Igss,Irtra,BonoPaternidad,SalarioTotal,SalarioLiquido")] Empleado empleado)
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
            return View(empleado);
        }

        // GET: Empleado/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Empleado == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleado
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // POST: Empleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Empleado == null)
            {
                return Problem("Entity set 'DbtestContext.Empleado'  is null.");
            }
            var empleado = await _context.Empleado.FindAsync(id);
            if (empleado != null)
            {
                _context.Empleado.Remove(empleado);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadoExists(int id)
        {
          return _context.Empleado.Any(e => e.Id == id);
        }
    }
}
