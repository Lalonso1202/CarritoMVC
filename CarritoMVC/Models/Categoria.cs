using CarritoMVC.Helpers;
using System.ComponentModel.DataAnnotations;

namespace CarritoMVC.Models
{
    public class Categoria
    {

        //public Producto Producto { get; set; }
        [Key]
        [Required(ErrorMessage = ErrorMsgs.Requerido)]
        public String Nombre { get; set; }

        [Required(ErrorMessage = ErrorMsgs.Requerido)]
        public String Descripcion { get; set; }

        public Categoria(string nombre, string descripcion)
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
        }
    }
}
