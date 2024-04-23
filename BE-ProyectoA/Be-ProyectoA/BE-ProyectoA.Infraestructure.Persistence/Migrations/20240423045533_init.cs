using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BE_ProyectoA.Infraestructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoordinadoresGenerales",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    NumeroTelefono = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Direccion_Provincia = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Direccion_Sector = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CantidadVotantes = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoordinadoresGenerales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Directores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CantidadVotantes = table.Column<int>(type: "int", nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    NumeroTelefono = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DirigentesMultiplicadores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CantidadVotantes = table.Column<int>(type: "int", nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    NumeroTelefono = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Direccion_Provincia = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Direccion_Sector = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirigentesMultiplicadores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubCoordinadores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CantidadVotantes = table.Column<int>(type: "int", nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    Direccion_Provincia = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Direccion_Sector = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    NumeroTelefono = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCoordinadores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Votantes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Direccion_Provincia = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Direccion_Sector = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    NumeroTelefono = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votantes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grupos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreGrupo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DirigentesMultiplicadoresId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubCoordinadoresId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoordinadoresGeneralesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grupos_CoordinadoresGenerales_CoordinadoresGeneralesId",
                        column: x => x.CoordinadoresGeneralesId,
                        principalTable: "CoordinadoresGenerales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Grupos_DirigentesMultiplicadores_DirigentesMultiplicadoresId",
                        column: x => x.DirigentesMultiplicadoresId,
                        principalTable: "DirigentesMultiplicadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Grupos_SubCoordinadores_SubCoordinadoresId",
                        column: x => x.SubCoordinadoresId,
                        principalTable: "SubCoordinadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grupos_CoordinadoresGeneralesId",
                table: "Grupos",
                column: "CoordinadoresGeneralesId");

            migrationBuilder.CreateIndex(
                name: "IX_Grupos_DirigentesMultiplicadoresId",
                table: "Grupos",
                column: "DirigentesMultiplicadoresId");

            migrationBuilder.CreateIndex(
                name: "IX_Grupos_SubCoordinadoresId",
                table: "Grupos",
                column: "SubCoordinadoresId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Directores");

            migrationBuilder.DropTable(
                name: "Grupos");

            migrationBuilder.DropTable(
                name: "Votantes");

            migrationBuilder.DropTable(
                name: "CoordinadoresGenerales");

            migrationBuilder.DropTable(
                name: "DirigentesMultiplicadores");

            migrationBuilder.DropTable(
                name: "SubCoordinadores");
        }
    }
}
