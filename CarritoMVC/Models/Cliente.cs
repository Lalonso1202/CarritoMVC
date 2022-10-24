using CarritoMVC.Helpers;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CarritoMVC.Models
{
    public class Cliente : Usuario
    {   //Como declarar un constructor con herencia en C#?
        public Cliente(int id, string nombre, string email, string password) : base(id, nombre, email, password)
        {
        }

        [Key]
        [Display(Name = Alias.ClienteId)]
        public int IdCliente { get; set; }

        [Key]
        [Display(Name = Alias.UsuarioId)]
        public int IdUsuario { get; set; }

        public Carrito Carrito { get; set; }

        public List<Compra> Compra { get; set; }

        public Usuario Usuario { get; set; }

        [Required]
        [Phone]
        public int Telefono { get; set; }

        [Required(ErrorMessage = ErrorMsgs.Requerido)]
        public String Direccion { get; set; }


    }
}
