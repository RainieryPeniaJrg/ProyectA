using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BE_ProyectoA.Infraestructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Habilitando_nullables_en_tabla_votantes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votantes_CoordinadoresGenerales_CoordinadorGeneralId1",
                table: "Votantes");

            migrationBuilder.DropIndex(
                name: "IX_Votantes_CoordinadorGeneralId1",
                table: "Votantes");

            migrationBuilder.DropColumn(
                name: "CoordinadorGeneralId1",
                table: "Votantes");

            migrationBuilder.AddColumn<Guid>(
                name: "CoordinadorGeneralId",
                table: "Votantes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Votantes_CoordinadorGeneralId",
                table: "Votantes",
                column: "CoordinadorGeneralId");

            migrationBuilder.AddForeignKey(
                name: "FK_Votantes_CoordinadoresGenerales_CoordinadorGeneralId",
                table: "Votantes",
                column: "CoordinadorGeneralId",
                principalTable: "CoordinadoresGenerales",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votantes_CoordinadoresGenerales_CoordinadorGeneralId",
                table: "Votantes");

            migrationBuilder.DropIndex(
                name: "IX_Votantes_CoordinadorGeneralId",
                table: "Votantes");

            migrationBuilder.DropColumn(
                name: "CoordinadorGeneralId",
                table: "Votantes");

            migrationBuilder.AddColumn<Guid>(
                name: "CoordinadorGeneralId1",
                table: "Votantes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Votantes_CoordinadorGeneralId1",
                table: "Votantes",
                column: "CoordinadorGeneralId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Votantes_CoordinadoresGenerales_CoordinadorGeneralId1",
                table: "Votantes",
                column: "CoordinadorGeneralId1",
                principalTable: "CoordinadoresGenerales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
