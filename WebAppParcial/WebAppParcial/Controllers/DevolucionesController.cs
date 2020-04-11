using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppParcial.Data;
using WebAppParcial.Models;

namespace WebAppParcial.Controllers
{
    public class DevolucionesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DevolucionesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Devoluciones
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Devolucion.Include(d => d.Prestamo);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Devoluciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var devolucion = await _context.Devolucion
                .Include(d => d.Prestamo)
                .FirstOrDefaultAsync(m => m.DevolucionID == id);
            if (devolucion == null)
            {
                return NotFound();
            }

            return View(devolucion);
        }

        // GET: Devoluciones/Create
        public IActionResult Create()
        {
            ViewData["PrestamoID"] = new SelectList(_context.Prestamo, "PrestamoID", "PrestamoID");
            return View();
        }

        // POST: Devoluciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DevolucionID,PrestamoID,Fecha")] Devolucion devolucion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(devolucion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PrestamoID"] = new SelectList(_context.Prestamo, "PrestamoID", "PrestamoID", devolucion.PrestamoID);
            return View(devolucion);
        }

        // GET: Devoluciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var devolucion = await _context.Devolucion.FindAsync(id);
            if (devolucion == null)
            {
                return NotFound();
            }
            ViewData["PrestamoID"] = new SelectList(_context.Prestamo, "PrestamoID", "PrestamoID", devolucion.PrestamoID);
            return View(devolucion);
        }

        // POST: Devoluciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DevolucionID,PrestamoID,Fecha")] Devolucion devolucion)
        {
            if (id != devolucion.DevolucionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(devolucion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DevolucionExists(devolucion.DevolucionID))
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
            ViewData["PrestamoID"] = new SelectList(_context.Prestamo, "PrestamoID", "PrestamoID", devolucion.PrestamoID);
            return View(devolucion);
        }

        // GET: Devoluciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var devolucion = await _context.Devolucion
                .Include(d => d.Prestamo)
                .FirstOrDefaultAsync(m => m.DevolucionID == id);
            if (devolucion == null)
            {
                return NotFound();
            }

            return View(devolucion);
        }

        // POST: Devoluciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var devolucion = await _context.Devolucion.FindAsync(id);
            _context.Devolucion.Remove(devolucion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DevolucionExists(int id)
        {
            return _context.Devolucion.Any(e => e.DevolucionID == id);
        }
    }
}
