using CarritoMVC.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace CarritoMVC.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ClienteId")]
        [Display(Name = Alias.ClienteId)]
        public int IdCliente { get; set; }

        [ForeignKey("EmpleadoId")]
        [Display(Name = Alias.EmpleadoId)]
        public int IdEmpleado { get; set; }

        //public Cliente Cliente { get; set; }
        //public Empleado Empleado { get; set; }

        [Required(ErrorMessage = ErrorMsgs.Requerido)]
        [StringLength(100, MinimumLength = 2, ErrorMessage = ErrorMsgs.StrMaxMin)]
        [RegularExpression(@"[a-zA-Z áéíóú]*", ErrorMessage = ErrorMsgs.StrSoloAlfab)]
        public String Nombre { get; set; }

        [Required(ErrorMessage = ErrorMsgs.Requerido)]
        public String Apellido { get; set; }

        public String NombreCompleto
        {
            get
            {
                if (string.IsNullOrEmpty(Apellido) && string.IsNullOrEmpty(Nombre)) return "Sin definir";
                if (string.IsNullOrEmpty(Apellido)) return Nombre;
                if (string.IsNullOrEmpty(Apellido)) return Apellido.ToUpper();

                return $"{Apellido.ToUpper()}, {Nombre}";
            }
        }

        [Required(ErrorMessage = ErrorMsgs.Requerido)]
        [Range(1000000, 99999999, ErrorMessage = ErrorMsgs.Range)]
        [Display(Name = Alias.PersonaDocumento)]
        public int Dni { get; set; }

        [Required(ErrorMessage = ErrorMsgs.Requerido)]
        [EmailAddress(ErrorMessage = ErrorMsgs.NotValid)]
        [Display(Name = Alias.CorreoElectronico)]
        public String Email { get; set; }

        [Required(ErrorMessage = ErrorMsgs.Requerido)]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd HH:mm}")]
        public DateTime FechaAlta { get; set; }

        [Required(ErrorMessage = ErrorMsgs.Requerido)]
        [DataType(DataType.Password)]
        public String Password { get; set; }


        public Usuario(int id, string nombre, string email, string password)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Email = email;
            this.FechaAlta = DateTime.Now;
            this.Password = password;
        }
    }
}
