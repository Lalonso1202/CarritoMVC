using CarritoMVC.Helpers;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CarritoMVC.Models
{
    public class Compra
    {
        [Key]
        [Display(Name = Alias.CompraId)]
        public int IdCompra { get; set; }

        [Key]
        [Display(Name = Alias.ClienteId)]
        public int IdCliente { get; set; }

        [Key]
        [Display(Name = Alias.CarritoId)]
        public int IdCarrito { get; set; }

        public Carrito Carrito { get; set; }
        public Cliente Cliente { get; set; }

        [Required(ErrorMessage = ErrorMsgs.Requerido)]
        public double Total { get; set; }

        public Compra(int idCompra, int idCliente, int idCarrito, double total)
        {
            this.IdCompra = idCompra;
            this.IdCliente = idCliente;
            this.IdCarrito = idCarrito;
            this.Total = total;
        }
    }
}
