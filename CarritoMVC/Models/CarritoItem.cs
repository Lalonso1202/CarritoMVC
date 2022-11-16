using CarritoMVC.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace CarritoMVC.Models
{
    public class CarritoItem
    {
        
        public int CarritoItemId { get; set; }
        public Producto Producto { get; set; }

        [Required(ErrorMessage = ErrorMsgs.Requerido)]
        public double ValorUnitario { get; set; }

        [Required(ErrorMessage = ErrorMsgs.Requerido)]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = ErrorMsgs.Requerido)]
        public int Subtotal { get; set; }

       
    }
}
