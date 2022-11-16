using CarritoMVC.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace CarritoMVC.Models
{
    public class StockItem
    {
        [Key]
        public int StockItemId { get; set; }

        public Producto Producto { get; set; }
        public Stock Stock { get; set; }

       
        [Required(ErrorMessage = ErrorMsgs.Requerido)]

        public int Cantidad { get; set; }
    }
}
