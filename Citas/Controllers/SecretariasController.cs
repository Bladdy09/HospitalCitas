using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Citas.Models;

namespace Citas.Controllers
{
    public class SecretariasController : Controller
    {
        private readonly HospitalContext _context;

        public SecretariasController(HospitalContext context)
        {
            _context = context;
        }

        // GET: Secretarias
        public async Task<IActionResult> Index()
        {
            return View(await _context.Secretaria.ToListAsync());
        }

        // GET: Secretarias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var secretaria = await _context.Secretaria
                .FirstOrDefaultAsync(m => m.Idsecretaria == id);
            if (secretaria == null)
            {
                return NotFound();
            }

            return View(secretaria);
        }

        // GET: Secretarias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Secretarias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idsecretaria,Nombre,Apellido,Cargo,Telefono,Correo,Contrasena")] Secretaria secretaria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(secretaria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(secretaria);
        }

        // GET: Secretarias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var secretaria = await _context.Secretaria.FindAsync(id);
            if (secretaria == null)
            {
                return NotFound();
            }
            return View(secretaria);
        }

        // POST: Secretarias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idsecretaria,Nombre,Apellido,Cargo,Telefono,Correo,Contrasena")] Secretaria secretaria)
        {
            if (id != secretaria.Idsecretaria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(secretaria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SecretariaExists(secretaria.Idsecretaria))
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
            return View(secretaria);
        }

        // GET: Secretarias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var secretaria = await _context.Secretaria
                .FirstOrDefaultAsync(m => m.Idsecretaria == id);
            if (secretaria == null)
            {
                return NotFound();
            }

            return View(secretaria);
        }

        // POST: Secretarias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var secretaria = await _context.Secretaria.FindAsync(id);
            _context.Secretaria.Remove(secretaria);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SecretariaExists(int id)
        {
            return _context.Secretaria.Any(e => e.Idsecretaria == id);
        }
    }
}
