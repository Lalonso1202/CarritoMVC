using CarritoMVC.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace CarritoMVC.Models
{
    public class Compra
    {
        [Key]
        [Display(Name = Alias.CompraId)]
        public int CompraId { get; set; }

        //[ForeignKey("CarritoId")]
        //[Display(Name = Alias.CarritoId)]
        //public int CarritoId { get; set; }

        public Carrito Carrito { get; set; }
        //public Cliente Cliente { get; set; }

        [Required(ErrorMessage = ErrorMsgs.Requerido)]
        public double Total { get; set; }

       
    }
}
