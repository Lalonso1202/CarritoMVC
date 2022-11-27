using CarritoMVC.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace CarritoMVC.Models
{
    public class Compra
    {
       
        public int CompraId { get; set; }

       
        public Carrito? Carrito { get; set; }
       

        [Required(ErrorMessage = ErrorMsgs.Requerido)]
        public double Total { get; set; }

       
    }
}
