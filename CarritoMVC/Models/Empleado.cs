using CarritoMVC.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace CarritoMVC.Models
{
    public class Empleado : Usuario
    {
        
        public int EmpleadoId { get; set; }

        

    }
}
