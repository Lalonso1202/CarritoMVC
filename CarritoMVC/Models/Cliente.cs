using CarritoMVC.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace CarritoMVC.Models
{
    public class Cliente : Usuario
    {   //Como declarar un constructor con herencia en C#?
        

        public int ClienteId { get; set; }
       

       


    }
}
