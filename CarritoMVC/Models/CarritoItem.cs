﻿using CarritoMVC.Helpers;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CarritoMVC.Models
{
    public class CarritoItem
    {
        [Key]
        [Display(Name = Alias.CarritoItemId)]
        public int IdCarritoItem { get; set; }

        [Key]
        [Display(Name = Alias.ProductoId)]
        public int IdProducto { get; set; }

        public Producto Producto { get; set; }

        [Required(ErrorMessage = ErrorMsgs.Requerido)]
        public double ValorUnitario { get; set; }

        [Required(ErrorMessage = ErrorMsgs.Requerido)]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = ErrorMsgs.Requerido)]
        public int Subtotal { get; set; }

        public CarritoItem(int idCarritoItem, int idProducto, double valorUnitario, int cantidad)
        {
            this.IdCarritoItem = idCarritoItem;
            this.IdProducto = idProducto;
            this.ValorUnitario = valorUnitario;
            this.Cantidad = cantidad;
            this.Subtotal = (int)(valorUnitario * cantidad);
        }
    }
}
