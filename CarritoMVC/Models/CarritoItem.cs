using CarritoMVC.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace CarritoMVC.Models
{
    public class CarritoItem
    {
        [Key]
        [Display(Name = Alias.CarritoItemId)]
        public int CarritoItemId { get; set; }

        //[ForeignKey("ProductoId")]
        //[Display(Name = Alias.ProductoId)]
        //public int ProductoId { get; set; }

        public Producto Producto { get; set; }

        [Required(ErrorMessage = ErrorMsgs.Requerido)]
        public double ValorUnitario { get; set; }

        [Required(ErrorMessage = ErrorMsgs.Requerido)]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = ErrorMsgs.Requerido)]
        public int Subtotal { get; set; }

        //public CarritoItem(int idCarritoItem, int idProducto, double valorUnitario, int cantidad)
        //{
        //    this.IdCarritoItem = idCarritoItem;
        //    this.IdProducto = idProducto;
        //    this.ValorUnitario = valorUnitario;
        //    this.Cantidad = cantidad;
        //    this.Subtotal = (int)(valorUnitario * cantidad);
        //}
    }
}
