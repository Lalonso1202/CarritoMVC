using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarritoMVC.Data;
using CarritoMVC.Models;
using Microsoft.AspNetCore.Http;

namespace CarritoMVC.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly CarritoContext _context;

        public CategoriasController(CarritoContext context)
        {
            _context = context;
        }

        // GET: Categorias
        public async Task<IActionResult> Index()
        {
            if (Login())
            {
                return View(await _context.Categorias.ToListAsync());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
             
        }

        

        // GET: Categorias/Create
        public IActionResult Create()
        {
            if (Login())
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
           
        }

        // POST: Categorias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoriaId,Descripcion")] Categoria categoria)
        {
            if (Login())
            {
                if (ModelState.IsValid)
                {
                    _context.Add(categoria);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(categoria);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
           
        }

        // GET: Categorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (Login())
            {
                if (id == null || _context.Categorias == null)
                {
                    return NotFound();
                }

                var categoria = await _context.Categorias.FindAsync(id);
                if (categoria == null)
                {
                    return NotFound();
                }
                return View(categoria);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

        // POST: Categorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoriaId,Descripcion")] Categoria categoria)
        {
            if (Login())
            {
                if (id != categoria.CategoriaId)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(categoria);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!CategoriaExists(categoria.CategoriaId))
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
                return View(categoria);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
           
        }

        // GET: Categorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (Login())
            {
                if (id == null || _context.Categorias == null)
                {
                    return NotFound();
                }

                var categoria = await _context.Categorias
                    .FirstOrDefaultAsync(m => m.CategoriaId == id);
                if (categoria == null)
                {
                    return NotFound();
                }

                return View(categoria);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
           
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (Login())
            {
                if (_context.Categorias == null)
                {
                    return Problem("Entity set 'CarritoContext.Categorias'  is null.");
                }
                var categoria = await _context.Categorias.FindAsync(id);
                if (categoria != null)
                {
                    _context.Categorias.Remove(categoria);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

        private bool CategoriaExists(int id)
        {
          return _context.Categorias.Any(e => e.CategoriaId == id);
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
