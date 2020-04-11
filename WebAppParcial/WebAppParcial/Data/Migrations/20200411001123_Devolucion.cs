using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppParcial.Data.Migrations
{
    public partial class Devolucion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Devolucion",
                columns: table => new
                {
                    DevolucionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrestamoID = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devolucion", x => x.DevolucionID);
                    table.ForeignKey(
                        name: "FK_Devolucion_Prestamo_PrestamoID",
                        column: x => x.PrestamoID,
                        principalTable: "Prestamo",
                        principalColumn: "PrestamoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Devolucion_PrestamoID",
                table: "Devolucion",
                column: "PrestamoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Devolucion");
        }
    }
}
