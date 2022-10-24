﻿using CarritoMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CarritoMVC.Data
{
    public class CarritoContext : DbContext
    {
        public CarritoContext(DbContextOptions options) : base(options)
        {

        }

        //Consultar sobre las funciones que crea en el video 19

        public DbSet<Carrito> Carritos { get; set; }
        public DbSet<CarritoItem> CarritoItems { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Producto> productos { get; set; }
        public DbSet<StockItem> StockItems { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}