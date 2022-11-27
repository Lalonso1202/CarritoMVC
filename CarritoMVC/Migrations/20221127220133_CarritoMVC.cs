using System;
using CarritoMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarritoMVC.Migrations
{
    public partial class CarritoMVC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dni = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaAlta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    EmpleadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dni = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaAlta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.EmpleadoId);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrecioVigente = table.Column<double>(type: "float", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    Destacado = table.Column<bool>(type: "bit", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductoId);
                    table.ForeignKey(
                        name: "FK_Productos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carritos",
                columns: table => new
                {
                    CarritoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    SubTotal = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carritos", x => x.CarritoId);
                    table.ForeignKey(
                        name: "FK_Carritos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarritoItems",
                columns: table => new
                {
                    CarritoItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Subtotal = table.Column<int>(type: "int", nullable: false),
                    carritoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarritoItems", x => x.CarritoItemId);
                    table.ForeignKey(
                        name: "FK_CarritoItems_Carritos_carritoId",
                        column: x => x.carritoId,
                        principalTable: "Carritos",
                        principalColumn: "CarritoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarritoItems_Productos_productoId",
                        column: x => x.productoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    CompraId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarritoId = table.Column<int>(type: "int", nullable: true),
                    Total = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.CompraId);
                    table.ForeignKey(
                        name: "FK_Compras_Carritos_CarritoId",
                        column: x => x.CarritoId,
                        principalTable: "Carritos",
                        principalColumn: "CarritoId");
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "CategoriaId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Remeras" },
                    { 2, "Buzos" },
                    { 3, "Shorts" },
                    { 4, "Pantalones largos" },
                    { 5, "Deportiva" }
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "ProductoId", "CategoriaId", "Imagen", "Nombre", "Descripcion", "PrecioVigente", "Activo", "Destacado", "Cantidad" },
                values: new object[,]
                {
                    { 1,1, "remera1.webp", "Remera Blanca Wintertex", "Wintertex", 2490.0, true, false, 0},
                    //{ 2,1, "remera2.webp", "Remera Blanca Levi's Graphic Set In Neck Vin", "Levis", 8289.0, true, true, 0},
                    { 3,1,"remera3.webp","Remera Azul Wellington Polo Club","Wellington Polo Club",3999.0,true,true,0 },
                    { 4,2, "buzo1.webp","Buzo Verde Kaba Line","Kaba Line",18450.0, true, false, 0 },
                    { 5,2, "buzo2.webp", "Buzo Blanco Polo Label Botones", "Polo Label", 3389.0, true, true, 0},
                    //{ 6,2, "buzo3.webp", "Buzo Azul Bensimon 1998", "BENSIMON", 15479.0, true, true, 0},
                    { 6,3, "short1.webp",  "Short Gris Chelsea Market Manuel", "Chelsea Market", 3994.0, true, false, 0},
                    { 7,3, "short2.webp", "Bermuda Gris El Genoves Cesena", "El Genovés", 7980.0, true, true, 0},
                    { 8,3, "short3.webp", "Bermuda Gris Bravo Golden","Bravo", 8259.0, true, false, 0 },
                    { 9, 4, "largo1.webp",  "Pantalón Negro Kill PAMERO", "Kill", 14629.0, true, true,0},
                    { 10, 4, "largo2.webp", "Jean Azul Airborn Jagger Dark Hawk", "Airborn", 15330.0, true, false, 0},
                    { 11, 4, "largo3.webp", "Pantalón Natural Portsaid Jefferson", "Portsaid", 10239.0, true, false, 0},
                    //{ 13, 5,  "deportiva1.webp", "CAMISETA TITULAR ARGENTINA 22", "ARGENTINA 22", 16999.0, true, true, 0 },
                    //{ 14, 5,  "deportiva2.webp", "CAMISETA TITULAR BOCA JUNIORS 22/23", "BOCA JUNIORS 22/23",16999.0, true, true, 0 },
                    //{ 15, 5,  "deportiva3.webp", "CAMISETA TITULAR RIVER PLATE 22/23", "RIVER PLATE 22/23",16999.0, true, false, 0 }


                }) ;
           
            migrationBuilder.CreateIndex(
                name: "IX_CarritoItems_carritoId",
                table: "CarritoItems",
                column: "carritoId");

            migrationBuilder.CreateIndex(
                name: "IX_CarritoItems_productoId",
                table: "CarritoItems",
                column: "productoId");

            migrationBuilder.CreateIndex(
                name: "IX_Carritos_ClienteId",
                table: "Carritos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_CarritoId",
                table: "Compras",
                column: "CarritoId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CategoriaId",
                table: "Productos",
                column: "CategoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarritoItems");

            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Carritos");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
