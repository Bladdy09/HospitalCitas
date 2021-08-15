using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HospitalCitas.Models;

namespace HospitalCitas.Controllers
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

            var cita = await _context.Cita
                .Include(c => c.IddoctorNavigation)
                .Include(c => c.IdpacienteNavigation)
                .Include(c => c.IdsecretariaNavigation)
                .FirstOrDefaultAsync(m => m.Idcita == id);
            if (cita == null)
            {
                return NotFound();
            }

            return View(cita);
        }

        // GET: Citas/Create
        public IActionResult Create()
        {
            
            
            ViewData["Iddoctor"] = new SelectList(_context.Doctors, "Iddoctor", "Nombre");
            ViewData["Idpaciente"] = new SelectList(_context.Pacientes, "Idpaciente", "Nombre");
            ViewData["Idsecretaria"] = new SelectList(_context.Secretaria, "Idsecretaria", "Nombre");
            return View();
        }

        // POST: Citas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idcita,FechaInicio,FechaFinal,Idpaciente,Idsecretaria,Iddoctor,EstadoDeLaCita,Notas,CitaCompletada,DuracionDeLaCita")] Cita cita)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
          //  ViewData["DuracionDeLaCita"] = new SelectList()
            ViewData["Iddoctor"] = new SelectList(_context.Doctors, "Iddoctor", "Nombre", cita.Iddoctor);
            ViewData["Idpaciente"] = new SelectList(_context.Pacientes, "Idpaciente", "Nombre", cita.Idpaciente);
            ViewData["Idsecretaria"] = new SelectList(_context.Secretaria, "Idsecretaria", "Nombre", cita.Idsecretaria);
            return View(cita);
        }

        // GET: Citas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cita = await _context.Cita.FindAsync(id);
            if (cita == null)
            {
                return NotFound();
            }
            ViewData["Iddoctor"] = new SelectList(_context.Doctors, "Iddoctor", "Nombre", cita.Iddoctor);
            ViewData["Idpaciente"] = new SelectList(_context.Pacientes, "Idpaciente", "Nombre", cita.Idpaciente);
            ViewData["Idsecretaria"] = new SelectList(_context.Secretaria, "Idsecretaria", "Nombre", cita.Idsecretaria);
            return View(cita);
        }

        // POST: Citas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idcita,FechaInicio,FechaFinal,Idpaciente,Idsecretaria,Iddoctor,EstadoDeLaCita,Notas,CitaCompletada,DuracionDeLaCita")] Cita cita)
        {
            if (id != cita.Idcita)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CitaExists(cita.Idcita))
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
            ViewData["Iddoctor"] = new SelectList(_context.Doctors, "Iddoctor", "Nombre", cita.Iddoctor);
            ViewData["Idpaciente"] = new SelectList(_context.Pacientes, "Idpaciente", "Nombre", cita.Idpaciente);
            ViewData["Idsecretaria"] = new SelectList(_context.Secretaria, "Idsecretaria", "Nombre", cita.Idsecretaria);
            return View(cita);
        }

        // GET: Citas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cita = await _context.Cita
                .Include(c => c.IddoctorNavigation)
                .Include(c => c.IdpacienteNavigation)
                .Include(c => c.IdsecretariaNavigation)
                .FirstOrDefaultAsync(m => m.Idcita == id);
            if (cita == null)
            {
                return NotFound();
            }

            return View(cita);
        }

        // POST: Citas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cita = await _context.Cita.FindAsync(id);
            _context.Cita.Remove(cita);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CitaExists(int id)
        {
            return _context.Cita.Any(e => e.Idcita == id);
        }
    }
}
