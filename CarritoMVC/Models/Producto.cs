using CarritoMVC.Helpers;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CarritoMVC.Models
{
    public class Producto
    {
        [Key]
        [Display(Name = Alias.CategoriaId)]
        public int IdCategoria { get; set; }

        //public StockItem StockItem { get; set; }

        public Categoria Categoria { get; set; }

        //public CarritoItem CarritoItem { get; set; }

        [Required(ErrorMessage = ErrorMsgs.Requerido)]
        [StringLength(100, MinimumLength = 2, ErrorMessage = ErrorMsgs.StrMaxMin)]
        [RegularExpression(@"[a-zA-Z áéíóú]*", ErrorMessage = ErrorMsgs.StrSoloAlfab)]
        public String Nombre { get; set; }

        [Required(ErrorMessage = ErrorMsgs.Requerido)]
        public String Descripcion { get; set; }

        [Required(ErrorMessage = ErrorMsgs.Requerido)]
        public double PrecioVigente { get; set; }

        [Required(ErrorMessage = ErrorMsgs.Requerido)]
        public Boolean Activo { get; set; }
    }
}
