using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PedidosApp.Migrations
{
    public partial class Ordenes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ordenes",
                columns: table => new
                {
                    OrdenId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    SuplidorId = table.Column<int>(nullable: false),
                    Monto = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ordenes", x => x.OrdenId);
                });

            migrationBuilder.CreateTable(
                name: "productos",
                columns: table => new
                {
                    ProductoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(maxLength: 40, nullable: false),
                    Costo = table.Column<decimal>(nullable: false),
                    Inventario = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos", x => x.ProductoId);
                });

            migrationBuilder.CreateTable(
                name: "suplidores",
                columns: table => new
                {
                    SuplidorId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_suplidores", x => x.SuplidorId);
                });

            migrationBuilder.CreateTable(
                name: "OrdenDetalle",
                columns: table => new
                {
                    DetalleId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrdenId = table.Column<int>(nullable: false),
                    ProductoId = table.Column<int>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    Costo = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenDetalle", x => x.DetalleId);
                    table.ForeignKey(
                        name: "FK_OrdenDetalle_ordenes_OrdenId",
                        column: x => x.OrdenId,
                        principalTable: "ordenes",
                        principalColumn: "OrdenId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdenDetalle_productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "productos",
                columns: new[] { "ProductoId", "Costo", "Descripcion", "Inventario" },
                values: new object[] { 1, 450m, "Salami", 10 });

            migrationBuilder.InsertData(
                table: "productos",
                columns: new[] { "ProductoId", "Costo", "Descripcion", "Inventario" },
                values: new object[] { 2, 60m, "ListaMilk", 40 });

            migrationBuilder.InsertData(
                table: "productos",
                columns: new[] { "ProductoId", "Costo", "Descripcion", "Inventario" },
                values: new object[] { 3, 45m, "Naranja sin azucar", 10 });

            migrationBuilder.InsertData(
                table: "productos",
                columns: new[] { "ProductoId", "Costo", "Descripcion", "Inventario" },
                values: new object[] { 4, 60m, "Carnation", 15 });

            migrationBuilder.InsertData(
                table: "productos",
                columns: new[] { "ProductoId", "Costo", "Descripcion", "Inventario" },
                values: new object[] { 5, 45m, "Leche Condenzada", 7 });

            migrationBuilder.InsertData(
                table: "suplidores",
                columns: new[] { "SuplidorId", "Nombre" },
                values: new object[] { 1, "Rica" });

            migrationBuilder.InsertData(
                table: "suplidores",
                columns: new[] { "SuplidorId", "Nombre" },
                values: new object[] { 2, "Induveca" });

            migrationBuilder.InsertData(
                table: "suplidores",
                columns: new[] { "SuplidorId", "Nombre" },
                values: new object[] { 3, "Nestle" });

            migrationBuilder.CreateIndex(
                name: "IX_OrdenDetalle_OrdenId",
                table: "OrdenDetalle",
                column: "OrdenId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenDetalle_ProductoId",
                table: "OrdenDetalle",
                column: "ProductoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdenDetalle");

            migrationBuilder.DropTable(
                name: "suplidores");

            migrationBuilder.DropTable(
                name: "ordenes");

            migrationBuilder.DropTable(
                name: "productos");
        }
    }
}
