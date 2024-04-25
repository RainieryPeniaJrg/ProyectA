using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BE_ProyectoA.Infraestructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Correccion_de_relacion_grupos : Migration
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
                    Cedula = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NumeroTelefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Direccion_Provincia = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Direccion_Sector = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Direccion_CasaElectoral = table.Column<int>(type: "int", nullable: false),
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
                    Cedula = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NumeroTelefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Votantes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Direccion_Provincia = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Direccion_Sector = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Direccion_CasaElectoral = table.Column<int>(type: "int", nullable: false),
                    NumeroTelefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
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
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubCoordinadores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CantidadVotantes = table.Column<int>(type: "int", nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    Direccion_Provincia = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Direccion_Sector = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Direccion_CasaElectoral = table.Column<int>(type: "int", nullable: false),
                    NumeroTelefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CoordinadorsGeneralesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCoordinadores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCoordinadores_CoordinadoresGenerales_CoordinadorsGeneralesId",
                        column: x => x.CoordinadorsGeneralesId,
                        principalTable: "CoordinadoresGenerales",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DirigentesMultiplicadores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CantidadVotantes = table.Column<int>(type: "int", nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NumeroTelefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Direccion_Provincia = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Direccion_Sector = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Direccion_CasaElectoral = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    SubCoordinadoresId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirigentesMultiplicadores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DirigentesMultiplicadores_SubCoordinadores_SubCoordinadoresId",
                        column: x => x.SubCoordinadoresId,
                        principalTable: "SubCoordinadores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GrupoSubCoordinador",
                columns: table => new
                {
                    GrupoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubCoordinadorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoSubCoordinador", x => new { x.GrupoId, x.SubCoordinadorId });
                    table.ForeignKey(
                        name: "FK_GrupoSubCoordinador_Grupos_GrupoId",
                        column: x => x.GrupoId,
                        principalTable: "Grupos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GrupoSubCoordinador_SubCoordinadores_SubCoordinadorId",
                        column: x => x.SubCoordinadorId,
                        principalTable: "SubCoordinadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GrupoDirigente",
                columns: table => new
                {
                    GrupoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DirigenteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoDirigente", x => new { x.GrupoId, x.DirigenteId });
                    table.ForeignKey(
                        name: "FK_GrupoDirigente_DirigentesMultiplicadores_DirigenteId",
                        column: x => x.DirigenteId,
                        principalTable: "DirigentesMultiplicadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GrupoDirigente_Grupos_GrupoId",
                        column: x => x.GrupoId,
                        principalTable: "Grupos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DirigentesMultiplicadores_SubCoordinadoresId",
                table: "DirigentesMultiplicadores",
                column: "SubCoordinadoresId");

            migrationBuilder.CreateIndex(
                name: "IX_GrupoDirigente_DirigenteId",
                table: "GrupoDirigente",
                column: "DirigenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Grupos_CoordinadoresGeneralesId",
                table: "Grupos",
                column: "CoordinadoresGeneralesId");

            migrationBuilder.CreateIndex(
                name: "IX_GrupoSubCoordinador_SubCoordinadorId",
                table: "GrupoSubCoordinador",
                column: "SubCoordinadorId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCoordinadores_CoordinadorsGeneralesId",
                table: "SubCoordinadores",
                column: "CoordinadorsGeneralesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Directores");

            migrationBuilder.DropTable(
                name: "GrupoDirigente");

            migrationBuilder.DropTable(
                name: "GrupoSubCoordinador");

            migrationBuilder.DropTable(
                name: "Votantes");

            migrationBuilder.DropTable(
                name: "DirigentesMultiplicadores");

            migrationBuilder.DropTable(
                name: "Grupos");

            migrationBuilder.DropTable(
                name: "SubCoordinadores");

            migrationBuilder.DropTable(
                name: "CoordinadoresGenerales");
        }
    }
}
