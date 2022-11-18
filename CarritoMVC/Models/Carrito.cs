using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using CarritoMVC.Helpers;

namespace CarritoMVC.Models
{
    public class Carrito
    {
        
        public int CarritoId { get; set; }

       
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

       

        public List<CarritoItem> CarritoItems { get; set; }

        [Required(ErrorMessage = ErrorMsgs.Requerido)]
        public bool Activo { get; set; }

        [Required(ErrorMessage = ErrorMsgs.Requerido)]
        public double SubTotal { get; set; }

        public Carrito(int carritoId, int clienteId, Cliente cliente, bool activo, double subTotal)
        {
            CarritoId = carritoId;
            ClienteId = clienteId;
            Cliente = cliente;
            CarritoItems = new List<CarritoItem>();
            Activo = activo;
            SubTotal = subTotal;
        }
        public Carrito()
        {

        }
    }
}
