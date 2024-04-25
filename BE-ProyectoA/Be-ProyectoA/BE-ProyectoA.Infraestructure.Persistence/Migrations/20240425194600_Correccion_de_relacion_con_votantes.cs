using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BE_ProyectoA.Infraestructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Correccion_de_relacion_con_votantes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CoordinadorGeneralId",
                table: "Votantes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DirectorId",
                table: "Votantes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DirigenteId",
                table: "Votantes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SubCoordinadorId",
                table: "Votantes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.AddForeignKey(
                name: "FK_Votantes_CoordinadoresGenerales_CoordinadorGeneralId",
                table: "Votantes",
                column: "CoordinadorGeneralId",
                principalTable: "CoordinadoresGenerales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Votantes_Directores_DirectorId",
                table: "Votantes",
                column: "DirectorId",
                principalTable: "Directores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Votantes_DirigentesMultiplicadores_DirigenteId",
                table: "Votantes",
                column: "DirigenteId",
                principalTable: "DirigentesMultiplicadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Votantes_SubCoordinadores_SubCoordinadorId",
                table: "Votantes",
                column: "SubCoordinadorId",
                principalTable: "SubCoordinadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votantes_CoordinadoresGenerales_CoordinadorGeneralId",
                table: "Votantes");

            migrationBuilder.DropForeignKey(
                name: "FK_Votantes_Directores_DirectorId",
                table: "Votantes");

            migrationBuilder.DropForeignKey(
                name: "FK_Votantes_DirigentesMultiplicadores_DirigenteId",
                table: "Votantes");

            migrationBuilder.DropForeignKey(
                name: "FK_Votantes_SubCoordinadores_SubCoordinadorId",
                table: "Votantes");

            migrationBuilder.DropIndex(
                name: "IX_Votantes_CoordinadorGeneralId",
                table: "Votantes");

            migrationBuilder.DropIndex(
                name: "IX_Votantes_DirectorId",
                table: "Votantes");

            migrationBuilder.DropIndex(
                name: "IX_Votantes_DirigenteId",
                table: "Votantes");

            migrationBuilder.DropIndex(
                name: "IX_Votantes_SubCoordinadorId",
                table: "Votantes");

            migrationBuilder.DropColumn(
                name: "CoordinadorGeneralId",
                table: "Votantes");

            migrationBuilder.DropColumn(
                name: "DirectorId",
                table: "Votantes");

            migrationBuilder.DropColumn(
                name: "DirigenteId",
                table: "Votantes");

            migrationBuilder.DropColumn(
                name: "SubCoordinadorId",
                table: "Votantes");
        }
    }
}
