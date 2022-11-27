using CarritoMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CarritoMVC.Data
{
    public class CarritoContext : DbContext
    {
        public CarritoContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Categoria>()
                .HasData(
                    new Categoria
                    {
                        CategoriaId = 1,
                        Descripcion = "Remeras"
                    },
                    new Categoria
                    {
                        CategoriaId = 2,
                        Descripcion = "Buzos"
                    },
                    new Categoria
                    {
                        CategoriaId = 3,
                        Descripcion = "Shorts"
                    },
                    new Categoria
                    {
                        CategoriaId = 4,
                        Descripcion = "Pantalones largos"
                    },
                    new Categoria
                    {
                        CategoriaId = 5,
                        Descripcion = "Deportiva"
                    }

                );


            //modelBuilder.Entity<Producto>()
            //    .HasData(
            //        //"CategoriaId,Imagen,Nombre,Descripcion,PrecioVigente,Activo,Destacado,Cantidad"
            //        new Producto
            //        {
            //            ProductoId = 1,
            //            CategoriaId = 1,
            //            Imagen = "remera1.webp",
            //            Nombre = "Remera Blanca Wintertex",
            //            Descripcion = "Wintertex",
            //            PrecioVigente = 2490,
            //            Activo = true,
            //            Destacado = false,
            //            Cantidad = 0

            //        },
            //        new Producto
            //        {
            //            ProductoId = 2,
            //            CategoriaId = 1,
            //            Imagen = "remera2.webp",
            //            Nombre = "Remera Blanca Levi's Graphic Set In Neck Vin",
            //            Descripcion = "Levi's",
            //            PrecioVigente = 8289,
            //            Activo = true,
            //            Destacado = true,
            //            Cantidad = 0

            //        }
            //        ,
            //        new Producto
            //        {
            //            ProductoId = 3,
            //            Nombre = "Remera Azul Wellington Polo Club",
            //            Descripcion = "Wellington Polo Club",
            //            PrecioVigente = 3999,
            //            Imagen = "remera3.webp",
            //            Destacado = true,
            //            Activo = true,
            //            CategoriaId = 1,
            //            Cantidad = 0

            //        },
            //        new Producto
            //        {
            //            ProductoId = 4,
            //            Nombre = "Buzo Verde Kaba Line",
            //            Descripcion = "Kaba Line",
            //            PrecioVigente = 18450,
            //            Imagen = "buzo1.webp",
            //            Destacado = false,
            //            Activo = true,
            //            CategoriaId = 2,
            //            Cantidad = 0

            //        },
            //        new Producto
            //        {
            //            ProductoId = 5,
            //            Nombre = "Buzo Blanco Polo Label Botones",
            //            Descripcion = "Polo Label",
            //            PrecioVigente = 3389,
            //            Imagen = "buzo2.webp",
            //            Destacado = true,
            //            Activo = true,
            //            CategoriaId = 2,
            //            Cantidad = 0

            //        },
            //        new Producto
            //        {
            //            ProductoId = 6,
            //            Nombre = "Buzo Azul Bensimon 1998",
            //            Descripcion = "BENSIMON",
            //            PrecioVigente = 15479,
            //            Imagen = "buzo3.webp",
            //            Destacado = true,
            //            Activo = true,
            //            CategoriaId = 2,
            //            Cantidad = 0

            //        },
            //        new Producto
            //        {
            //            ProductoId = 7,
            //            Nombre = "Short Gris Chelsea Market Manuel",
            //            Descripcion = "Chelsea Market",
            //            PrecioVigente = 3994,
            //            Imagen = "short1.webp",
            //            Destacado = false,
            //            Activo = true,
            //            CategoriaId = 3,
            //            Cantidad = 0

            //        },
            //        new Producto
            //        {
            //            ProductoId = 8,
            //            Nombre = "Bermuda Gris El Genoves Cesena",
            //            Descripcion = "El Genovés",
            //            PrecioVigente = 7980,
            //            Imagen = "short2.webp",
            //            Destacado = true,
            //            Activo = true,
            //            CategoriaId = 3,
            //            Cantidad = 0

            //        },
            //        new Producto
            //        {
            //            ProductoId = 9,
            //            Nombre = "Bermuda Gris Bravo Golden",
            //            Descripcion = "Bravo",
            //            PrecioVigente = 8259,
            //            Imagen = "short3.webp",
            //            Destacado = false,
            //            Activo = true,
            //            CategoriaId = 3,
            //            Cantidad = 0

            //        },
            //        new Producto
            //        {
            //            ProductoId = 10,
            //            Nombre = "Pantalón Negro Kill PAMERO",
            //            Descripcion = "Kill",
            //            PrecioVigente = 14629,
            //            Imagen = "largo1.webp",
            //            Destacado = true,
            //            Activo = true,
            //            CategoriaId = 4,
            //            Cantidad = 0

            //        },
            //        new Producto
            //        {
            //            ProductoId = 11,
            //            Nombre = "Jean Azul Airborn Jagger Dark Hawk",
            //            Descripcion = "Airborn",
            //            PrecioVigente = 15330,
            //            Imagen = "largo2.webp",
            //            Destacado = false,
            //            Activo = true,
            //            CategoriaId = 4,
            //            Cantidad = 0

            //        },
            //        new Producto
            //        {
            //            ProductoId = 12,
            //            Nombre = "Pantalón Natural Portsaid Jefferson",
            //            Descripcion = "Portsaid",
            //            PrecioVigente = 10239,
            //            Imagen = "largo3.webp",
            //            Destacado = false,
            //            Activo = true,
            //            CategoriaId = 4,
            //            Cantidad = 0

            //        },
            //        new Producto
            //        {
            //            ProductoId = 13,
            //            Nombre = "CAMISETA TITULAR ARGENTINA 22",
            //            Descripcion = "ARGENTINA 22",
            //            PrecioVigente = 16999,
            //            Imagen = "deportiva1.webp",
            //            Destacado = true,
            //            Activo = true,
            //            CategoriaId = 5,
            //            Cantidad = 0

            //        },
            //        new Producto
            //        {
            //            ProductoId = 14,
            //            Nombre = "CAMISETA TITULAR BOCA JUNIORS 22/23",
            //            Descripcion = "BOCA JUNIORS 22/23",
            //            PrecioVigente = 16999,
            //            Imagen = "deportiva2.webp",
            //            Destacado = true,
            //            Activo = true,
            //            CategoriaId = 5,
            //            Cantidad = 0

            //        },
            //        new Producto
            //        {
            //            ProductoId = 15,
            //            Nombre = "CAMISETA TITULAR RIVER PLATE 22/23",
            //            Descripcion = "RIVER PLATE 22/23",
            //            PrecioVigente = 16999,
            //            Imagen = "deportiva3.webp",
            //            Destacado = false,
            //            Activo = true,
            //            CategoriaId = 5,
            //            Cantidad = 0

            //        }
            //    );


        }

        //Consultar sobre las funciones que crea en el video 19

        public DbSet<Carrito> Carritos { get; set; }
        public DbSet<CarritoItem> CarritoItems { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Producto> Productos { get; set; }
        
        

    }
}
