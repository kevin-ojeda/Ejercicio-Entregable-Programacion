using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClasesEjercicioPrueba.Migrations
{
    /// <inheritdoc />
    public partial class Clases : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "vehiculos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "vehiculos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cantidadPuertas = table.Column<int>(type: "int", nullable: false),
                    marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    motor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    patente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tieneAuxiliar = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehiculos", x => x.id);
                });
        }
    }
}
