using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarritoMVC.Controllers
{
    public class BackofficeController : Controller
    {
        // GET: BackofficeControlle
        public ActionResult Index()
        {
            if (Login())
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index","Home");
            }
            
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
