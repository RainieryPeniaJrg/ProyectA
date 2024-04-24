using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BE_ProyectoA.Infraestructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class añadiendo_casa_Electoral : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Direccion_CasaElectoral",
                table: "Votantes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Direccion_CasaElectoral",
                table: "SubCoordinadores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Direccion_CasaElectoral",
                table: "DirigentesMultiplicadores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Direccion_CasaElectoral",
                table: "CoordinadoresGenerales",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Direccion_CasaElectoral",
                table: "Votantes");

            migrationBuilder.DropColumn(
                name: "Direccion_CasaElectoral",
                table: "SubCoordinadores");

            migrationBuilder.DropColumn(
                name: "Direccion_CasaElectoral",
                table: "DirigentesMultiplicadores");

            migrationBuilder.DropColumn(
                name: "Direccion_CasaElectoral",
                table: "CoordinadoresGenerales");
        }
    }
}
