using CarritoMVC.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace CarritoMVC.Models
{
    public class Cliente : Usuario
    {   //Como declarar un constructor con herencia en C#?
        

        public int ClienteId { get; set; }
        //public int UsuarioId { get; set; }

        //[ForeignKey("Carrito")]
        //[Display(Name = Alias.CarritoId)]
        //public int CarritoId { get; set; }

        //public Carrito Carrito { get; set; }

        //public List<Compra> Compra { get; set; }

        [Required]
        //[Phone]
        public int Telefono { get; set; }

        [Required(ErrorMessage = ErrorMsgs.Requerido)]
        public String Direccion { get; set; }


    }
}
