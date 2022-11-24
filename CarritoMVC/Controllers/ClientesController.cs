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
    public class ClientesController : Controller
    {
        private readonly CarritoContext _context;

        public ClientesController(CarritoContext context)
        {
            _context = context;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            if (Login() && HttpContext.Session.GetString("Admin").Equals(true.ToString()))
            {
                return View(await _context.Clientes.ToListAsync());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (Login() && devolverSessionId(HttpContext.Session.GetString("Email")).Equals(id.ToString()) || HttpContext.Session.GetString("Admin").Equals(true.ToString()))
            {
                if (id == null || _context.Clientes == null)
                {
                    return NotFound();
                }

                var cliente = await _context.Clientes
                    .FirstOrDefaultAsync(m => m.ClienteId == id);
                if (cliente == null)
                {
                    return NotFound();
                }

                return View(cliente);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

        public String devolverSessionId(String email)
        {
            String clienteId = _context.Clientes.First(v => v.Email.Equals(email)).ClienteId.ToString();
            if (Login())
            {
                clienteId = HttpContext.Session.GetString("ClienteId").ToString();
            }

            return clienteId;
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClienteId,Telefono,Direccion,Nombre,Apellido,Dni,Email,FechaAlta,Password")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                if (!yaExiste(cliente.Email))
                {
                    
                   
                    HttpContext.Session.SetString("NombreCompleto", cliente.NombreCompleto);
                    HttpContext.Session.SetString("Email", cliente.Email);
                    HttpContext.Session.SetString("Admin", false.ToString());
                    _context.Add(cliente);
                    Carrito miCarrito = new Carrito();
                    miCarrito.Activo = true;
                    miCarrito.Cliente = cliente;
                    miCarrito.SubTotal = 0;

                    _context.Carritos.Add(miCarrito);

                    await _context.SaveChangesAsync();
                    HttpContext.Session.SetString("ClienteId", devolverSessionId(cliente.Email));
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Msg = "Ya se encuentra registrado ese mail";
                    return View("Create");
                }
               
            }
            return RedirectToAction("Home","Index");
        }
        public Boolean yaExiste(String email)
        {
            Boolean existe = false;
            var queryCliente = _context.Clientes.Where(e => e.Email.Equals(email)).FirstOrDefault();
            var queryEmpleado = _context.Empleados.Where(e => e.Email.Equals(email)).FirstOrDefault();
            if (queryCliente != null || queryEmpleado != null)
            {
                existe = true;
            }

            return existe;
        }
        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (Login())
            {
                if (id == null || _context.Clientes == null)
                {
                    return NotFound();
                }

                var cliente = await _context.Clientes.FindAsync(id);
                if (cliente == null)
                {
                    return NotFound();
                }
                return View(cliente);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClienteId,Telefono,Direccion,Nombre,Apellido,Dni,Email,FechaAlta,Password")] Cliente cliente)
        {
            if (Login())
            {
                if (id != cliente.ClienteId)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(cliente);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ClienteExists(cliente.ClienteId))
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
                return View(cliente);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
           
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (Login())
            {
                if (id == null || _context.Clientes == null)
                {
                    return NotFound();
                }

                var cliente = await _context.Clientes
                    .FirstOrDefaultAsync(m => m.ClienteId == id);
                if (cliente == null)
                {
                    return NotFound();
                }

                return View(cliente);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (Login() && HttpContext.Session.GetString("Admin").Equals(true.ToString()))
            {
                if (_context.Clientes == null)
                {
                    return Problem("Entity set 'CarritoContext.Clientes'  is null.");
                }
                var cliente = await _context.Clientes.FindAsync(id);
                if (cliente != null)
                {
                    _context.Clientes.Remove(cliente);
                   
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else if(Login() && HttpContext.Session.GetString("Admin").Equals(false.ToString()))
            {
                if (_context.Clientes == null)
                {
                    return Problem("Entity set 'CarritoContext.Clientes'  is null.");
                }
                var cliente = await _context.Clientes.FindAsync(id);
                if (cliente != null)
                {
                    _context.Clientes.Remove(cliente);
                    HttpContext.Session.SetString("EmpleadoId", "0");
                    HttpContext.Session.SetString("NombreCompleto", "");
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));



            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
           
        }

       
        public bool Login()
        {
            bool l;
            if (HttpContext.Session.GetString("ClienteId") != null || HttpContext.Session.GetString("EmpleadoId") != null)
            {
                l = true;
            }
            else
            {
                l = false;
            }
            return l;
        }
        private bool ClienteExists(int id)
        {
          return _context.Clientes.Any(e => e.ClienteId == id);
        }
    }
}
