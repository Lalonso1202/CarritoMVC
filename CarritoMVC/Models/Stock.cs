using CarritoMVC.Helpers;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CarritoMVC.Models
{
    public class Stock
    {
        [Key]
        [Display(Name = Alias.StockId)]
        public int IdStock { get; set; }

        //public StockItem StockItem { get; set; }

        [Required(ErrorMessage = ErrorMsgs.Requerido)]
        [StringLength(100, MinimumLength = 2, ErrorMessage = ErrorMsgs.StrMaxMin)]
        [RegularExpression(@"[a-zA-Z áéíóú]*", ErrorMessage = ErrorMsgs.StrSoloAlfab)]
        public String Nombre { get; set; }

        [Required(ErrorMessage = ErrorMsgs.Requerido)]
        public String Direccion { get; set; }
        [Required]
        [Phone]
        public int Telefono { get; set; }

        [Required]
        [EmailAddress]
        public String Email { get; set; }

        public List<StockItem> StockItems { get; set; }
    }
}
