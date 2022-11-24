using CarritoMVC.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace CarritoMVC.Models
{
    public abstract class Usuario
    {
       

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

        [Required]

        public int Telefono { get; set; }

        [Required(ErrorMessage = ErrorMsgs.Requerido)]
        public String Direccion { get; set; }


    }
}
