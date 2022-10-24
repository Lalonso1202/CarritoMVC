using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using CarritoMVC.Helpers;

namespace CarritoMVC.Models
{
    public class Carrito
    {
        [Key]
        [Display(Name = Alias.CarritoId)]
        public int IdCarrito { get; set; }

        public Cliente Cliente { get; set; }

        public Compra Compra { get; set; }

        public List<CarritoItem> CarritoItems { get; set; }

        [Required(ErrorMessage = ErrorMsgs.Requerido)]
        public bool Activo { get; set; }

        [Required(ErrorMessage = ErrorMsgs.Requerido)]
        public double SubTotal { get; set; }

    }
}
