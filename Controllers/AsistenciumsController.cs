using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aplicacion.Models;

namespace Aplicacion.Controllers
{
    public class AsistenciumsController : Controller
    {
        private readonly DBPRUEBAContext _context;

        public AsistenciumsController(DBPRUEBAContext context)
        {
            _context = context;
        }

        // GET: Asistenciums
        public async Task<IActionResult> Index()
        {
            var cursos = await _context.Cursos
                .Include(c => c.HistoricoCursosAlumnos)
                .ThenInclude(x => x.IdAlumnoNavigation)
                .Include(a => a.Asistencia)
                .ToListAsync();
            return View(cursos);
        }

        // GET: Asistenciums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Asistencia == null)
            {
                return NotFound();
            }

            var asistencium = await _context.Asistencia
                .Include(a => a.IdAlumnoNavigation)
                .Include(a => a.IdCursoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (asistencium == null)
            {
                return NotFound();
            }

            return View(asistencium);
        }

        // GET: Asistenciums/Create
        public IActionResult Create(int id)
        {
            List<Alumno> alumnos = new List<Alumno>();
            var historico = _context.HistoricoCursosAlumnos.Include(x => x.IdAlumnoNavigation).Where(x => x.IdCurso == id).ToList();
            return View(historico);
        }
        // GET: Asistenciums/GetAsistencia
        [HttpGet]
        public IActionResult GetAsistencia(int cursoId, DateTime fecha)
        {

            var response = new Response();
            var asistencia = _context.Asistencia
                .Where(a => a.IdCurso == cursoId && a.Fecha == fecha)
                .ToList();


            if(asistencia.Count > 0)
            {
                response.Estado = true;
            }
            else
            {
                response.Estado = false;
            }

            response.Data = asistencia;
            


            return Json(response);
        }


        // POST: Asistenciums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DateTime fecha, int cursoId, Dictionary<int, Asistencium> asistenciaList)
        {
            if (ModelState.IsValid)
            {
                List<Asistencium> asistencia = new List<Asistencium>();
                foreach (var entry in asistenciaList)
                {
                    asistencia.Add(new Asistencium
                    {
                        IdCurso = cursoId,
                        IdAlumno = entry.Value.IdAlumno,
                        Fecha = fecha,
                        Estado = entry.Value.Estado == true ? true : false,

                    });


                }

                foreach (var item in asistencia)
                {
                    var exist = await _context.Asistencia.Where(x => x.IdAlumno == item.IdAlumno && x.IdCurso == item.IdCurso && x.Fecha == item.Fecha).FirstOrDefaultAsync();
                    if (exist == null)
                    {
                        await _context.Asistencia.AddAsync(item);
                    }
                    else
                    {
                        exist.Estado = item.Estado;
                        _context.Update(exist);

                    }
                }




                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }


        // GET: Asistenciums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Asistencia == null)
            {
                return NotFound();
            }

            var asistencium = await _context.Asistencia.FindAsync(id);
            if (asistencium == null)
            {
                return NotFound();
            }
            ViewData["IdAlumno"] = new SelectList(_context.Alumnos, "Id", "Id", asistencium.IdAlumno);
            ViewData["IdCurso"] = new SelectList(_context.Cursos, "Id", "Id", asistencium.IdCurso);
            return View(asistencium);
        }

        // POST: Asistenciums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdAlumno,IdCurso,Fecha,Estado")] Asistencium asistencium)
        {
            if (id != asistencium.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asistencium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsistenciumExists(asistencium.Id))
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
            ViewData["IdAlumno"] = new SelectList(_context.Alumnos, "Id", "Id", asistencium.IdAlumno);
            ViewData["IdCurso"] = new SelectList(_context.Cursos, "Id", "Id", asistencium.IdCurso);
            return View(asistencium);
        }

        // GET: Asistenciums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Asistencia == null)
            {
                return NotFound();
            }

            var asistencium = await _context.Asistencia
                .Include(a => a.IdAlumnoNavigation)
                .Include(a => a.IdCursoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (asistencium == null)
            {
                return NotFound();
            }

            return View(asistencium);
        }

        // POST: Asistenciums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Asistencia == null)
            {
                return Problem("Entity set 'DBPRUEBAContext.Asistencia'  is null.");
            }
            var asistencium = await _context.Asistencia.FindAsync(id);
            if (asistencium != null)
            {
                _context.Asistencia.Remove(asistencium);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsistenciumExists(int id)
        {
            return (_context.Asistencia?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }

    public class Response
    {
        public bool Estado { get; set; }
        public object Data { get; set; }
    }
}
