using CarritoMVC.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace CarritoMVC.Models
{
    public class StockItem
    {
        [Key]
        [Display(Name =Alias.StockItemId)]
        public int StockItemId { get; set; }

        //[Key]
        //[Display(Name = Alias.StockItemId)]
        //public int IdStockItem;

        [ForeignKey("ProductoId")]
        [Display(Name = Alias.ProductoId)]
        public int IdProducto;

        public Stock Stock { get; set; }

        //public Producto Producto { get; set; }

        [Required(ErrorMessage = ErrorMsgs.Requerido)]

        public int Cantidad;
    }
}
