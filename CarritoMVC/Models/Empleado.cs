using CarritoMVC.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace CarritoMVC.Models
{
    public class Empleado : Usuario
    {
        public Empleado(int id, string nombre, string email, string password) : base(id, nombre, email, password)
        {
        }

        [Required]
        [Phone]
        public int Telefono { get; set; }

        [Required(ErrorMessage = ErrorMsgs.Requerido)]
        public String Direccion { get; set; }

    }
}
