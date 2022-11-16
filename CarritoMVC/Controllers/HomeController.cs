using CarritoMVC.Data;
using CarritoMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CarritoMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CarritoContext _context;
       
        public HomeController(ILogger<HomeController> logger, CarritoContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            var carritoContext = _context.Productos.Include(p => p.Categoria).Where(p => p.Destacado.Equals(true));
            return View(await carritoContext.ToListAsync());
        }

        public async Task<IActionResult> Tienda()
        {
            var carritoContext = _context.Productos.Include(p => p.Categoria).Where(p => p.Destacado.Equals(true));
            ViewBag.categorias = _context.Categorias.ToList();
            return View(await carritoContext.ToListAsync());
        }

        

        public ActionResult Logueo(String email, String password)
        {
            //string queryEmpleado = (from c in _context.Empleados
            //                where c.Email == Email && c.Password == Password
            //                        select c.NombreCompleto).FirstOrDefault();
            var queryEmpleado = _context.Empleados.Where(e => e.Email.Equals(email) && e.Password.Equals(password)).FirstOrDefault();

            var queryCliente = _context.Clientes.Where(e => e.Email.Equals(email) && e.Password.Equals(password)).FirstOrDefault();

           
            if ((queryEmpleado != null && queryCliente == null) || (queryEmpleado != null && queryCliente != null))
            {
                return RedirectToAction("Index", "Productos");
            }else if(queryCliente != null && queryEmpleado == null)
            {
                return RedirectToAction("Index");
            }
            return View("Login");
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}