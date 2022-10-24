using CarritoMVC.Helpers;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CarritoMVC.Models
{
    public class StockItem
    {

        [Key]
        [Display(Name = Alias.SucursalId)]
        public int IdSucursal;

        [Key]
        [Display(Name = Alias.ProductoId)]
        public int IdProducto;

        public Sucursal Sucursal { get; set; }

        public Producto Producto { get; set; }

        [Required(ErrorMessage = ErrorMsgs.Requerido)]

        public int Cantidad;
    }
}
