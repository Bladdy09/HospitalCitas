using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital_Citas_B.Models;
using Microsoft.AspNetCore.Http;

namespace Hospital_Citas_B.Controllers
{
    public class SecretariasController : Controller
    {
        private readonly HospitalContext _context;

        public SecretariasController(HospitalContext context)
        {
            _context = context;
        }

        //[HttpGet]
        public ActionResult LoginSecretary()
        {
            return View();
        }


        //[HttpPost]
        //public ActionResult LoginSecretary(string email, string password)
        //{

        //    if (string.IsNullOrEmpty(email) && string.IsNullOrEmpty(password))
        //    {

        //        var secre = _context.Secretaria.FirstOrDefault(e => e.Correo == email && e.Contrasena == password);
        //        //si secretaria es diferente de null

        //        if (secre.Correo == email && secre.Contrasena == password)
        //        {
        //            //encontramos una secretaria con los datos
        //            //FormsAuthentication.SetAuthCookie(email, true);
        //            return View("Bienvenido");

        //        }
        //        else
        //        {
        //            return Json("sus datos son incorrectos");
        //        }
        //    }
        //    else
        //    {
        //        return View();
        //    }



        //}


        // [HttpPost]
        //public IActionResult LoginSecretary(IFormCollection form)
        // {
        //     string email = form["email"];
        //     string password = form["password"];
        //     return View();



        // }

        // GET: Secretarias
        //[HttpPost]
        // public IActionResult LoginSecretary(string email, string password)
        // {

        //     if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
        //     {
        //         HospitalContext db = new HospitalContext();
        //         var secre = db.Secretaria.FirstOrDefault(e => e.Correo == email && e.Contrasena == password);
        //         //si secretaria es diferente de null
        //         if (secre != null)
        //         {
        //             //encontramos una secretaria con los datos
        //             //FormsAuthentication.SetAuthCookie(email, true);
        //             return View(_context.Doctors.ToList());

        //         }
        //         else
        //         {
        //             return View("No encontramos tus datos");
        //         }
        //     }
        //     else
        //     {
        //         return View("Por favor llenar los campos para iniciar sesion");
        //     }

        //}

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
