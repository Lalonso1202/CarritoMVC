using CarritoMVC.Helpers;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CarritoMVC.Models
{
    public class Producto
    {
        public int ProductoId { get; set; }
        
        public int CategoriaId { get; set; }
        [Key]
        public Categoria? Categoria { get; set; }
        public String Imagen { get; set; }


        [Required(ErrorMessage = ErrorMsgs.Requerido)]
        [StringLength(100, MinimumLength = 2, ErrorMessage = ErrorMsgs.StrMaxMin)]
        [RegularExpression(@"[a-zA-Z áéíóú]*", ErrorMessage = ErrorMsgs.StrSoloAlfab)]
        public String Nombre { get; set; }

        [Required(ErrorMessage = ErrorMsgs.Requerido)]
        public String Descripcion { get; set; }

        [Required(ErrorMessage = ErrorMsgs.Requerido)]
        public double PrecioVigente { get; set; }
        public Boolean Activo { get; set; }
        public Boolean Destacado { get; set; }

        public int Cantidad { get; set; }

        
    }
}
