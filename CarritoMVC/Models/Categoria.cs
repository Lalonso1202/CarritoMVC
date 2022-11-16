using CarritoMVC.Helpers;
using System.ComponentModel.DataAnnotations;

namespace CarritoMVC.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        [Required(ErrorMessage = ErrorMsgs.Requerido)]
        public String Descripcion { get; set; }

        
    }
}
