using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aplicacion.Models;
using Microsoft.AspNetCore.Authorization;

namespace Aplicacion.Controllers
{
    [Authorize]
    public class HistoricoCursosAlumnoesController : Controller
    {
        private readonly DBPRUEBAContext _context;

        public HistoricoCursosAlumnoesController(DBPRUEBAContext context)
        {
            _context = context;
        }

        // GET: HistoricoCursosAlumnoes
        public async Task<IActionResult> Index()
        {
            var dBPRUEBAContext = _context.HistoricoCursosAlumnos.Include(h => h.IdAlumnoNavigation).Include(h => h.IdCursoNavigation);
            return View(await dBPRUEBAContext.ToListAsync());
        }

        // GET: HistoricoCursosAlumnoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HistoricoCursosAlumnos == null)
            {
                return NotFound();
            }

            var historicoCursosAlumno = await _context.HistoricoCursosAlumnos
                .Include(h => h.IdAlumnoNavigation)
                .Include(h => h.IdCursoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (historicoCursosAlumno == null)
            {
                return NotFound();
            }

            return View(historicoCursosAlumno);
        }

        // GET: HistoricoCursosAlumnoes/Create
        public IActionResult Create()
        {

            ViewData["IdAlumno"] = new SelectList(_context.Alumnos, "Id", "NombreCompleto");
            ViewData["IdCurso"] = new SelectList(_context.Cursos, "Id", "Nombre");
            return View();
        }

        // POST: HistoricoCursosAlumnoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAlumno,IdCurso")] HistoricoCursosAlumno historicoCursosAlumno)
        {
            if (ModelState.IsValid)
            {
                historicoCursosAlumno.FechaRegistro = DateTime.Now;
                _context.Add(historicoCursosAlumno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAlumno"] = new SelectList(_context.Alumnos, "Id", "Id", historicoCursosAlumno.IdAlumno);
            ViewData["IdCurso"] = new SelectList(_context.Cursos, "Id", "Id", historicoCursosAlumno.IdCurso);
            return View(historicoCursosAlumno);
        }

        // GET: HistoricoCursosAlumnoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historicoCursosAlumno = await _context.HistoricoCursosAlumnos.FindAsync(id);
            if (historicoCursosAlumno == null)
            {
                return NotFound();
            }
            ViewData["IdAlumno"] = new SelectList(_context.Alumnos, "Id", "NombreCompleto", historicoCursosAlumno.IdAlumno);
            ViewData["IdCurso"] = new SelectList(_context.Cursos, "Id", "Nombre", historicoCursosAlumno.IdCurso);
            return View(historicoCursosAlumno);
        }

        // POST: HistoricoCursosAlumnoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdAlumno,IdCurso,FechaRegistro")] HistoricoCursosAlumno historicoCursosAlumno)
        {
            if (id != historicoCursosAlumno.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(historicoCursosAlumno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistoricoCursosAlumnoExists(historicoCursosAlumno.Id))
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
            ViewData["IdAlumno"] = new SelectList(_context.Alumnos, "Id", "NombreCompleto", historicoCursosAlumno.IdAlumno);
            ViewData["IdCurso"] = new SelectList(_context.Cursos, "Id", "Nombre", historicoCursosAlumno.IdCurso);
            return View(historicoCursosAlumno);
        }

        // GET: HistoricoCursosAlumnoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HistoricoCursosAlumnos == null)
            {
                return NotFound();
            }

            var historicoCursosAlumno = await _context.HistoricoCursosAlumnos
                .Include(h => h.IdAlumnoNavigation)
                .Include(h => h.IdCursoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (historicoCursosAlumno == null)
            {
                return NotFound();
            }

            return View(historicoCursosAlumno);
        }

        // POST: HistoricoCursosAlumnoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HistoricoCursosAlumnos == null)
            {
                return Problem("Entity set 'DBPRUEBAContext.HistoricoCursosAlumnos'  is null.");
            }
            var historicoCursosAlumno = await _context.HistoricoCursosAlumnos.FindAsync(id);
            if (historicoCursosAlumno != null)
            {
                _context.HistoricoCursosAlumnos.Remove(historicoCursosAlumno);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistoricoCursosAlumnoExists(int id)
        {
          return (_context.HistoricoCursosAlumnos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
