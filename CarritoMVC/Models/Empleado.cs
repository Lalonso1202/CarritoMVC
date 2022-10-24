using CarritoMVC.Helpers;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CarritoMVC.Models
{
    public class Empleado : Usuario
    {
        public Empleado(int id, string nombre, string email, string password) : base(id, nombre, email, password)
        {
        }

        [Key]
        [Display(Name = Alias.EmpleadoId)]
        public int IdEmpleado { get; set; }

        [Key]
        [Display(Name = Alias.UsuarioId)]
        public int IdUsuario { get; set; }

        public Usuario Usuario { get; set; }

        [Required]
        [Phone]
        public int Telefono { get; set; }

        [Required(ErrorMessage = ErrorMsgs.Requerido)]
        public String Direccion { get; set; }

    }
}
