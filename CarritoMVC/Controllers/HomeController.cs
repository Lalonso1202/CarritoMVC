using CarritoMVC.Data;
using CarritoMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Xml.Linq;


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

        public ActionResult Index()
        {

            ViewBag.productos = _context.Productos.Include(p => p.Categoria).Where(p => p.Destacado.Equals(true)).Where(p => p.Activo.Equals(true)).Take(8).OrderByDescending(p => p.Nombre);
            return View();
        }

        public async Task<IActionResult> Tienda()
        {
            var carritoContext = _context.Productos.Include(p => p.Categoria).Where(p => p.Activo.Equals(true));
            ViewBag.categorias = _context.Categorias.ToList();
            return View(await carritoContext.ToListAsync());
        }

        public IActionResult cerrarSesion()
        {
            HttpContext.Session.SetString("EmpleadoId", "0");
            HttpContext.Session.SetString("NombreCompleto", "");
            
            return RedirectToAction("Index"); 
        }

        //public ActionResult agregarACarrito(Producto producto, int cantidad, double subtotal, int carritoId) 
        //{
        //    CarritoItem miCarritoItem = new CarritoItem();
        //    miCarritoItem.productoId = producto.ProductoId;
        //    miCarritoItem.Cantidad = cantidad;
        //    miCarritoItem.Subtotal = (int)(producto.PrecioVigente * cantidad);
        //    miCarritoItem.
        //}
        public IActionResult Logueo(String email, String password)
        {
            var queryEmpleado = _context.Empleados.Where(e => e.Email.Equals(email) && e.Password.Equals(password)).FirstOrDefault();

            var queryCliente = _context.Clientes.Where(e => e.Email.Equals(email) && e.Password.Equals(password)).FirstOrDefault();

           
            if ((queryEmpleado != null && queryCliente == null) || (queryEmpleado != null && queryCliente != null))
            {
                HttpContext.Session.SetString("EmpleadoId", queryEmpleado.EmpleadoId.ToString());
                HttpContext.Session.SetString("NombreCompleto", queryEmpleado.NombreCompleto);
                HttpContext.Session.SetString("Admin", true.ToString());
                HttpContext.Session.SetString("Email", email);


                return RedirectToAction("Index", "Backoffice");
            }else if(queryCliente != null && queryEmpleado == null)
            {
                HttpContext.Session.SetString("ClienteId", queryCliente.ClienteId.ToString());
                HttpContext.Session.SetString("NombreCompleto", queryCliente.NombreCompleto);
                HttpContext.Session.SetString("Admin", false.ToString());
                HttpContext.Session.SetString("Email", email);
                //ViewBag.nombreUsuario = HttpContext.Session.GetString("nombreCompleto");
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