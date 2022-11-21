using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using CarritoMVC.Helpers;

namespace CarritoMVC.Models
{
    public class Carrito
    {
        
        public int CarritoId { get; set; }

       
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

       

        public List<CarritoItem>? CarritoItems { get; set; }

        [Required(ErrorMessage = ErrorMsgs.Requerido)]
        public bool Activo { get; set; }

        [Required(ErrorMessage = ErrorMsgs.Requerido)]
        public double SubTotal { get; set; }

        
    }
}
