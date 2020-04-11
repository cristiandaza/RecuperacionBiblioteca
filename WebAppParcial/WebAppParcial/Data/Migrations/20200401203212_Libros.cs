using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppParcial.Data.Migrations
{
    public partial class Libros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    AreaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    TiempoPrestamo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.AreaID);
                });

            migrationBuilder.CreateTable(
                name: "Libro",
                columns: table => new
                {
                    LibroID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaID = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    NumeroPaginas = table.Column<string>(nullable: true),
                    Autor = table.Column<string>(nullable: true),
                    Editorial = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libro", x => x.LibroID);
                    table.ForeignKey(
                        name: "FK_Libro_Area_AreaID",
                        column: x => x.AreaID,
                        principalTable: "Area",
                        principalColumn: "AreaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prestamo",
                columns: table => new
                {
                    PrestamoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LibroID = table.Column<int>(nullable: false),
                    UsuarioID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamo", x => x.PrestamoID);
                    table.ForeignKey(
                        name: "FK_Prestamo_Libro_LibroID",
                        column: x => x.LibroID,
                        principalTable: "Libro",
                        principalColumn: "LibroID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prestamo_Usuario_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Libro_AreaID",
                table: "Libro",
                column: "AreaID");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamo_LibroID",
                table: "Prestamo",
                column: "LibroID");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamo_UsuarioID",
                table: "Prestamo",
                column: "UsuarioID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prestamo");

            migrationBuilder.DropTable(
                name: "Libro");

            migrationBuilder.DropTable(
                name: "Area");
        }
    }
}
