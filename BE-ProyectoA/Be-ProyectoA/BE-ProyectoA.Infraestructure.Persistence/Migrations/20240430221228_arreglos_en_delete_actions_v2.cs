using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BE_ProyectoA.Infraestructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class arreglos_en_delete_actions_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoordinadoresGenerales",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NumeroTelefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Direccion_Provincia = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Direccion_Sector = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Direccion_CasaElectoral = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CantidadVotantes = table.Column<int>(type: "int", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    VotantesCoordinadoresGeneralesVotanteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VotantesCoordinadoresGeneralesCoordinadorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoordinadoresGenerales", x => x.Id);
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
                name: "Directores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CantidadVotantes = table.Column<int>(type: "int", nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NumeroTelefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    VotantesDirectorVotanteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VotantesDirectorDirectorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CantidadVotantes = table.Column<int>(type: "int", nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NumeroTelefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Direccion_Provincia = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Direccion_Sector = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Direccion_CasaElectoral = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    VotantesDirigentesVotanteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VotantesDirigentesDirigenteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubCoordinadoresId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirigentesMultiplicadores", x => x.Id);
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
                });

            migrationBuilder.CreateTable(
                name: "SubCoordinadores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CantidadVotantes = table.Column<int>(type: "int", nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    Direccion_Provincia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Direccion_Sector = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Direccion_CasaElectoral = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroTelefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CoordinadorsGeneralesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VotantesSubCoordinadorVotanteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VotantesSubCoordinadorSubCoordinadorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                name: "Votantes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Direccion_Provincia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Direccion_Sector = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Direccion_CasaElectoral = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroTelefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    DirectorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SubCoordinadorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CoordinadorGeneralId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DirigenteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Votantes_CoordinadoresGenerales_CoordinadorGeneralId",
                        column: x => x.CoordinadorGeneralId,
                        principalTable: "CoordinadoresGenerales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Votantes_Directores_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Directores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Votantes_DirigentesMultiplicadores_DirigenteId",
                        column: x => x.DirigenteId,
                        principalTable: "DirigentesMultiplicadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Votantes_SubCoordinadores_SubCoordinadorId",
                        column: x => x.SubCoordinadorId,
                        principalTable: "SubCoordinadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VotantesCoordinadores",
                columns: table => new
                {
                    VotanteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoordinadorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VotantesCoordinadores", x => new { x.VotanteId, x.CoordinadorId });
                    table.ForeignKey(
                        name: "FK_VotantesCoordinadores_CoordinadoresGenerales_CoordinadorId",
                        column: x => x.CoordinadorId,
                        principalTable: "CoordinadoresGenerales",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VotantesCoordinadores_Votantes_VotanteId",
                        column: x => x.VotanteId,
                        principalTable: "Votantes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VotantesDirectors",
                columns: table => new
                {
                    VotanteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DirectorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VotantesDirectors", x => new { x.VotanteId, x.DirectorId });
                    table.ForeignKey(
                        name: "FK_VotantesDirectors_Directores_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Directores",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VotantesDirectors_Votantes_VotanteId",
                        column: x => x.VotanteId,
                        principalTable: "Votantes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VotantesDirigentes",
                columns: table => new
                {
                    VotanteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DirigenteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VotantesDirigentes", x => new { x.VotanteId, x.DirigenteId });
                    table.ForeignKey(
                        name: "FK_VotantesDirigentes_DirigentesMultiplicadores_DirigenteId",
                        column: x => x.DirigenteId,
                        principalTable: "DirigentesMultiplicadores",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VotantesDirigentes_Votantes_VotanteId",
                        column: x => x.VotanteId,
                        principalTable: "Votantes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VotantesSubCoordinadores",
                columns: table => new
                {
                    VotanteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubCoordinadorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VotantesSubCoordinadores", x => new { x.VotanteId, x.SubCoordinadorId });
                    table.ForeignKey(
                        name: "FK_VotantesSubCoordinadores_SubCoordinadores_SubCoordinadorId",
                        column: x => x.SubCoordinadorId,
                        principalTable: "SubCoordinadores",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VotantesSubCoordinadores_Votantes_VotanteId",
                        column: x => x.VotanteId,
                        principalTable: "Votantes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoordinadoresGenerales_VotantesCoordinadoresGeneralesVotanteId_VotantesCoordinadoresGeneralesCoordinadorId",
                table: "CoordinadoresGenerales",
                columns: new[] { "VotantesCoordinadoresGeneralesVotanteId", "VotantesCoordinadoresGeneralesCoordinadorId" });

            migrationBuilder.CreateIndex(
                name: "IX_Directores_VotantesDirectorVotanteId_VotantesDirectorDirectorId",
                table: "Directores",
                columns: new[] { "VotantesDirectorVotanteId", "VotantesDirectorDirectorId" });

            migrationBuilder.CreateIndex(
                name: "IX_DirigentesMultiplicadores_SubCoordinadoresId",
                table: "DirigentesMultiplicadores",
                column: "SubCoordinadoresId");

            migrationBuilder.CreateIndex(
                name: "IX_DirigentesMultiplicadores_VotantesDirigentesVotanteId_VotantesDirigentesDirigenteId",
                table: "DirigentesMultiplicadores",
                columns: new[] { "VotantesDirigentesVotanteId", "VotantesDirigentesDirigenteId" });

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

            migrationBuilder.CreateIndex(
                name: "IX_SubCoordinadores_VotantesSubCoordinadorVotanteId_VotantesSubCoordinadorSubCoordinadorId",
                table: "SubCoordinadores",
                columns: new[] { "VotantesSubCoordinadorVotanteId", "VotantesSubCoordinadorSubCoordinadorId" });

            migrationBuilder.CreateIndex(
                name: "IX_Votantes_CoordinadorGeneralId",
                table: "Votantes",
                column: "CoordinadorGeneralId");

            migrationBuilder.CreateIndex(
                name: "IX_Votantes_DirectorId",
                table: "Votantes",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Votantes_DirigenteId",
                table: "Votantes",
                column: "DirigenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Votantes_SubCoordinadorId",
                table: "Votantes",
                column: "SubCoordinadorId");

            migrationBuilder.CreateIndex(
                name: "IX_VotantesCoordinadores_CoordinadorId",
                table: "VotantesCoordinadores",
                column: "CoordinadorId");

            migrationBuilder.CreateIndex(
                name: "IX_VotantesDirectors_DirectorId",
                table: "VotantesDirectors",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_VotantesDirigentes_DirigenteId",
                table: "VotantesDirigentes",
                column: "DirigenteId");

            migrationBuilder.CreateIndex(
                name: "IX_VotantesSubCoordinadores_SubCoordinadorId",
                table: "VotantesSubCoordinadores",
                column: "SubCoordinadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_CoordinadoresGenerales_VotantesCoordinadores_VotantesCoordinadoresGeneralesVotanteId_VotantesCoordinadoresGeneralesCoordinad~",
                table: "CoordinadoresGenerales",
                columns: new[] { "VotantesCoordinadoresGeneralesVotanteId", "VotantesCoordinadoresGeneralesCoordinadorId" },
                principalTable: "VotantesCoordinadores",
                principalColumns: new[] { "VotanteId", "CoordinadorId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Directores_VotantesDirectors_VotantesDirectorVotanteId_VotantesDirectorDirectorId",
                table: "Directores",
                columns: new[] { "VotantesDirectorVotanteId", "VotantesDirectorDirectorId" },
                principalTable: "VotantesDirectors",
                principalColumns: new[] { "VotanteId", "DirectorId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DirigentesMultiplicadores_SubCoordinadores_SubCoordinadoresId",
                table: "DirigentesMultiplicadores",
                column: "SubCoordinadoresId",
                principalTable: "SubCoordinadores",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DirigentesMultiplicadores_VotantesDirigentes_VotantesDirigentesVotanteId_VotantesDirigentesDirigenteId",
                table: "DirigentesMultiplicadores",
                columns: new[] { "VotantesDirigentesVotanteId", "VotantesDirigentesDirigenteId" },
                principalTable: "VotantesDirigentes",
                principalColumns: new[] { "VotanteId", "DirigenteId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GrupoSubCoordinador_SubCoordinadores_SubCoordinadorId",
                table: "GrupoSubCoordinador",
                column: "SubCoordinadorId",
                principalTable: "SubCoordinadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCoordinadores_VotantesSubCoordinadores_VotantesSubCoordinadorVotanteId_VotantesSubCoordinadorSubCoordinadorId",
                table: "SubCoordinadores",
                columns: new[] { "VotantesSubCoordinadorVotanteId", "VotantesSubCoordinadorSubCoordinadorId" },
                principalTable: "VotantesSubCoordinadores",
                principalColumns: new[] { "VotanteId", "SubCoordinadorId" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoordinadoresGenerales_VotantesCoordinadores_VotantesCoordinadoresGeneralesVotanteId_VotantesCoordinadoresGeneralesCoordinad~",
                table: "CoordinadoresGenerales");

            migrationBuilder.DropForeignKey(
                name: "FK_Directores_VotantesDirectors_VotantesDirectorVotanteId_VotantesDirectorDirectorId",
                table: "Directores");

            migrationBuilder.DropForeignKey(
                name: "FK_DirigentesMultiplicadores_SubCoordinadores_SubCoordinadoresId",
                table: "DirigentesMultiplicadores");

            migrationBuilder.DropForeignKey(
                name: "FK_Votantes_SubCoordinadores_SubCoordinadorId",
                table: "Votantes");

            migrationBuilder.DropForeignKey(
                name: "FK_VotantesSubCoordinadores_SubCoordinadores_SubCoordinadorId",
                table: "VotantesSubCoordinadores");

            migrationBuilder.DropForeignKey(
                name: "FK_DirigentesMultiplicadores_VotantesDirigentes_VotantesDirigentesVotanteId_VotantesDirigentesDirigenteId",
                table: "DirigentesMultiplicadores");

            migrationBuilder.DropTable(
                name: "GrupoDirigente");

            migrationBuilder.DropTable(
                name: "GrupoSubCoordinador");

            migrationBuilder.DropTable(
                name: "Grupos");

            migrationBuilder.DropTable(
                name: "VotantesCoordinadores");

            migrationBuilder.DropTable(
                name: "VotantesDirectors");

            migrationBuilder.DropTable(
                name: "SubCoordinadores");

            migrationBuilder.DropTable(
                name: "VotantesSubCoordinadores");

            migrationBuilder.DropTable(
                name: "VotantesDirigentes");

            migrationBuilder.DropTable(
                name: "Votantes");

            migrationBuilder.DropTable(
                name: "CoordinadoresGenerales");

            migrationBuilder.DropTable(
                name: "Directores");

            migrationBuilder.DropTable(
                name: "DirigentesMultiplicadores");
        }
    }
}
