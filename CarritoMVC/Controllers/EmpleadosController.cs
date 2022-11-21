using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarritoMVC.Data;
using CarritoMVC.Models;

namespace CarritoMVC.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly CarritoContext _context;

        public EmpleadosController(CarritoContext context)
        {
            _context = context;
        }

        // GET: Empleados
        public async Task<IActionResult> Index()
        {
            if (Login())
            {
                return View(await _context.Empleados.ToListAsync());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
              
        }

        // GET: Empleados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (Login())
            {
                if (id == null || _context.Empleados == null)
                {
                    return NotFound();
                }

                var empleado = await _context.Empleados
                    .FirstOrDefaultAsync(m => m.EmpleadoId == id);
                if (empleado == null)
                {
                    return NotFound();
                }

                return View(empleado);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

        // GET: Empleados/Create
        public IActionResult Create()
        {
            //if (Login())
            //{
                return View();
            //}
            //else
            //{
            //    return RedirectToAction("Index", "Home");
            //}
           
        }

        public Boolean yaExiste(String email)
        {
            Boolean existe = false;
            var queryEmpleado = _context.Empleados.Where(e => e.Email.Equals(email)).FirstOrDefault();
            if (queryEmpleado != null)
            {
                existe = true;
            }

            return existe;
        }

        // POST: Empleados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpleadoId,Telefono,Direccion,Nombre,Apellido,Dni,Email,FechaAlta,Password")] Empleado empleado)
        {
            //if (Login())
            //{
                if (ModelState.IsValid)
                {
                    if (!yaExiste(empleado.Email))
                    {
                        HttpContext.Session.SetString("EmpleadoId", empleado.EmpleadoId.ToString());
                        HttpContext.Session.SetString("NombreCompleto", empleado.NombreCompleto);
                        HttpContext.Session.SetString("Admin", true.ToString());
                        _context.Add(empleado);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ViewBag.Msg = "Ya se encuentra registrado ese mail";
                        return View("Create");
                    }
                }
                return View(empleado);
            //}
            //else
            //{
            //    return RedirectToAction("Index", "Home");
            //}
           
        }

        // GET: Empleados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (Login())
            {
                if (id == null || _context.Empleados == null)
                {
                    return NotFound();
                }

                var empleado = await _context.Empleados.FindAsync(id);
                if (empleado == null)
                {
                    return NotFound();
                }
                return View(empleado);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

        // POST: Empleados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmpleadoId,Telefono,Direccion,Nombre,Apellido,Dni,Email,FechaAlta,Password")] Empleado empleado)
        {
            if (Login())
            {
                if (id != empleado.EmpleadoId)
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
                        if (!EmpleadoExists(empleado.EmpleadoId))
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
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        // GET: Empleados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (Login())
            {
                if (id == null || _context.Empleados == null)
                {
                    return NotFound();
                }

                var empleado = await _context.Empleados
                    .FirstOrDefaultAsync(m => m.EmpleadoId == id);
                if (empleado == null)
                {
                    return NotFound();
                }

                return View(empleado);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
           
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (Login())
            {
                if (_context.Empleados == null)
                {
                    return Problem("Entity set 'CarritoContext.Empleados'  is null.");
                }
                var empleado = await _context.Empleados.FindAsync(id);
                if (empleado != null)
                {
                    _context.Empleados.Remove(empleado);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        private bool EmpleadoExists(int id)
        {
          return _context.Empleados.Any(e => e.EmpleadoId == id);
        }

        public bool Login()
        {
            bool l;
            if (HttpContext.Session.GetString("EmpleadoId") != null && HttpContext.Session.GetString("Admin") == true.ToString())
            {
                l = true;
            }
            else
            {
                l = false;
            }
            return l;
        }
    }
}
