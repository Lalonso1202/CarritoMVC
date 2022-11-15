﻿// <auto-generated />
using System;
using CarritoMVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarritoMVC.Migrations
{
    [DbContext(typeof(CarritoContext))]
    partial class CarritoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CarritoMVC.Models.Carrito", b =>
                {
                    b.Property<int>("CarritoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarritoId"), 1L, 1);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<double>("SubTotal")
                        .HasColumnType("float");

                    b.HasKey("CarritoId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Carritos");
                });

            modelBuilder.Entity("CarritoMVC.Models.CarritoItem", b =>
                {
                    b.Property<int>("CarritoItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarritoItemId"), 1L, 1);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int?>("CarritoId")
                        .HasColumnType("int");

                    b.Property<int>("ProductoIdCategoria")
                        .HasColumnType("int");

                    b.Property<int>("Subtotal")
                        .HasColumnType("int");

                    b.Property<double>("ValorUnitario")
                        .HasColumnType("float");

                    b.HasKey("CarritoItemId");

                    b.HasIndex("CarritoId");

                    b.HasIndex("ProductoIdCategoria");

                    b.ToTable("CarritoItems");
                });

            modelBuilder.Entity("CarritoMVC.Models.Categoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoriaId"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("CarritoMVC.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteId"), 1L, 1);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Dni")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaAlta")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("CarritoMVC.Models.Compra", b =>
                {
                    b.Property<int>("CompraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompraId"), 1L, 1);

                    b.Property<int>("CarritoId")
                        .HasColumnType("int");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.HasKey("CompraId");

                    b.HasIndex("CarritoId");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("CarritoMVC.Models.Empleado", b =>
                {
                    b.Property<int>("EmpleadoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmpleadoId"), 1L, 1);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Dni")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaAlta")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.HasKey("EmpleadoId");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("CarritoMVC.Models.Producto", b =>
                {
                    b.Property<int>("IdCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCategoria"), 1L, 1);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Destacado")
                        .HasColumnType("bit");

                    b.Property<string>("Imagen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PrecioVigente")
                        .HasColumnType("float");

                    b.HasKey("IdCategoria");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("CarritoMVC.Models.Stock", b =>
                {
                    b.Property<int>("StockId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StockId"), 1L, 1);

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.HasKey("StockId");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("CarritoMVC.Models.StockItem", b =>
                {
                    b.Property<int>("StockItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StockItemId"), 1L, 1);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("ProductoIdCategoria")
                        .HasColumnType("int");

                    b.Property<int>("StockId")
                        .HasColumnType("int");

                    b.HasKey("StockItemId");

                    b.HasIndex("ProductoIdCategoria");

                    b.HasIndex("StockId");

                    b.ToTable("StockItems");
                });

            modelBuilder.Entity("CarritoMVC.Models.Carrito", b =>
                {
                    b.HasOne("CarritoMVC.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("CarritoMVC.Models.CarritoItem", b =>
                {
                    b.HasOne("CarritoMVC.Models.Carrito", null)
                        .WithMany("CarritoItems")
                        .HasForeignKey("CarritoId");

                    b.HasOne("CarritoMVC.Models.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoIdCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("CarritoMVC.Models.Compra", b =>
                {
                    b.HasOne("CarritoMVC.Models.Carrito", "Carrito")
                        .WithMany()
                        .HasForeignKey("CarritoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carrito");
                });

            modelBuilder.Entity("CarritoMVC.Models.Producto", b =>
                {
                    b.HasOne("CarritoMVC.Models.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("CarritoMVC.Models.StockItem", b =>
                {
                    b.HasOne("CarritoMVC.Models.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoIdCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarritoMVC.Models.Stock", "Stock")
                        .WithMany("StockItems")
                        .HasForeignKey("StockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("CarritoMVC.Models.Carrito", b =>
                {
                    b.Navigation("CarritoItems");
                });

            modelBuilder.Entity("CarritoMVC.Models.Stock", b =>
                {
                    b.Navigation("StockItems");
                });
#pragma warning restore 612, 618
        }
    }
}
