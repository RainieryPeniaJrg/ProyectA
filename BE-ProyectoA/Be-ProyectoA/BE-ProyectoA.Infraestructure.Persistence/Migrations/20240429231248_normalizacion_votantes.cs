using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BE_ProyectoA.Infraestructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class normalizacion_votantes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VotantesCoordinadores_Votantes_VotanteId",
                        column: x => x.VotanteId,
                        principalTable: "Votantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VotantesDirectors",
                columns: table => new
                {
                    VotanteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DirectoresId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VotantesDirectors", x => new { x.VotanteId, x.DirectoresId });
                    table.ForeignKey(
                        name: "FK_VotantesDirectors_Directores_DirectoresId",
                        column: x => x.DirectoresId,
                        principalTable: "Directores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VotantesDirectors_Votantes_VotanteId",
                        column: x => x.VotanteId,
                        principalTable: "Votantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VotantesDirigentes",
                columns: table => new
                {
                    VotanteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DirigentesMultiplicadoresId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VotantesDirigentes", x => new { x.VotanteId, x.DirigentesMultiplicadoresId });
                    table.ForeignKey(
                        name: "FK_VotantesDirigentes_DirigentesMultiplicadores_DirigentesMultiplicadoresId",
                        column: x => x.DirigentesMultiplicadoresId,
                        principalTable: "DirigentesMultiplicadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VotantesDirigentes_Votantes_VotanteId",
                        column: x => x.VotanteId,
                        principalTable: "Votantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VotantesSubCoordinadores_Votantes_VotanteId",
                        column: x => x.VotanteId,
                        principalTable: "Votantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VotantesCoordinadores_CoordinadorId",
                table: "VotantesCoordinadores",
                column: "CoordinadorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VotantesCoordinadores_VotanteId",
                table: "VotantesCoordinadores",
                column: "VotanteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VotantesDirectors_DirectoresId",
                table: "VotantesDirectors",
                column: "DirectoresId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VotantesDirectors_VotanteId",
                table: "VotantesDirectors",
                column: "VotanteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VotantesDirigentes_DirigentesMultiplicadoresId",
                table: "VotantesDirigentes",
                column: "DirigentesMultiplicadoresId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VotantesDirigentes_VotanteId",
                table: "VotantesDirigentes",
                column: "VotanteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VotantesSubCoordinadores_SubCoordinadorId",
                table: "VotantesSubCoordinadores",
                column: "SubCoordinadorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VotantesSubCoordinadores_VotanteId",
                table: "VotantesSubCoordinadores",
                column: "VotanteId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VotantesCoordinadores");

            migrationBuilder.DropTable(
                name: "VotantesDirectors");

            migrationBuilder.DropTable(
                name: "VotantesDirigentes");

            migrationBuilder.DropTable(
                name: "VotantesSubCoordinadores");
        }
    }
}
