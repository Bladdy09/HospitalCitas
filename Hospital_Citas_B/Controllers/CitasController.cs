using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital_Citas_B.Models;

namespace Hospital_Citas_B.Controllers
{
    public class CitasController : Controller
    {
        private readonly HospitalContext _context;

        public CitasController(HospitalContext context)
        {
            _context = context;
        }

        // GET: Citas
        public async Task<IActionResult> Index()
        {
            var hospitalContext = _context.Cita.Include(c => c.IddoctorNavigation).Include(c => c.IdpacienteNavigation).Include(c => c.IdsecretariaNavigation);
            return View(await hospitalContext.ToListAsync());
        }

        // GET: Citas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citas = await _context.Cita
                .Include(c => c.IddoctorNavigation)
                .Include(c => c.IdpacienteNavigation)
                .Include(c => c.IdsecretariaNavigation)
                .FirstOrDefaultAsync(m => m.Idcita == id);
            if (citas == null)
            {
                return NotFound();
            }

            return View(citas);
        }

        // GET: Citas/Create
        public IActionResult Create()
        {
            ViewData["Iddoctor"] = new SelectList(_context.Doctors, "Iddoctor", "Iddoctor");
            ViewData["Idpaciente"] = new SelectList(_context.Pacientes, "Idpaciente", "Idpaciente");
            ViewData["Idsecretaria"] = new SelectList(_context.Secretaria, "Idsecretaria", "Idsecretaria");
            return View();
        }

        // POST: Citas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idcita,FechaInicio,FechaFinal,Idpaciente,Idsecretaria,Iddoctor,EstadoDeLaCita,Notas,CitaCompletada,DuracionDeLaCita")] Citas citas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(citas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Iddoctor"] = new SelectList(_context.Doctors, "Iddoctor", "Iddoctor", citas.Iddoctor);
            ViewData["Idpaciente"] = new SelectList(_context.Pacientes, "Idpaciente", "Idpaciente", citas.Idpaciente);
            ViewData["Idsecretaria"] = new SelectList(_context.Secretaria, "Idsecretaria", "Idsecretaria", citas.Idsecretaria);
            return View(citas);
        }

        // GET: Citas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citas = await _context.Cita.FindAsync(id);
            if (citas == null)
            {
                return NotFound();
            }
            ViewData["Iddoctor"] = new SelectList(_context.Doctors, "Iddoctor", "Iddoctor", citas.Iddoctor);
            ViewData["Idpaciente"] = new SelectList(_context.Pacientes, "Idpaciente", "Idpaciente", citas.Idpaciente);
            ViewData["Idsecretaria"] = new SelectList(_context.Secretaria, "Idsecretaria", "Idsecretaria", citas.Idsecretaria);
            return View(citas);
        }

        // POST: Citas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idcita,FechaInicio,FechaFinal,Idpaciente,Idsecretaria,Iddoctor,EstadoDeLaCita,Notas,CitaCompletada,DuracionDeLaCita")] Citas citas)
        {
            if (id != citas.Idcita)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(citas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CitasExists(citas.Idcita))
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
            ViewData["Iddoctor"] = new SelectList(_context.Doctors, "Iddoctor", "Iddoctor", citas.Iddoctor);
            ViewData["Idpaciente"] = new SelectList(_context.Pacientes, "Idpaciente", "Idpaciente", citas.Idpaciente);
            ViewData["Idsecretaria"] = new SelectList(_context.Secretaria, "Idsecretaria", "Idsecretaria", citas.Idsecretaria);
            return View(citas);
        }

        // GET: Citas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citas = await _context.Cita
                .Include(c => c.IddoctorNavigation)
                .Include(c => c.IdpacienteNavigation)
                .Include(c => c.IdsecretariaNavigation)
                .FirstOrDefaultAsync(m => m.Idcita == id);
            if (citas == null)
            {
                return NotFound();
            }

            return View(citas);
        }

        // POST: Citas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var citas = await _context.Cita.FindAsync(id);
            _context.Cita.Remove(citas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CitasExists(int id)
        {
            return _context.Cita.Any(e => e.Idcita == id);
        }
    }
}
