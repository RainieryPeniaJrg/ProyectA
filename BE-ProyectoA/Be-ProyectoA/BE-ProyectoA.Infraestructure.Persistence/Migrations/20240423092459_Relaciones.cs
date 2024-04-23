using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BE_ProyectoA.Infraestructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Relaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CoordinadorsGeneralesId",
                table: "SubCoordinadores",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SubCoordinadoresId",
                table: "DirigentesMultiplicadores",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_SubCoordinadores_CoordinadorsGeneralesId",
                table: "SubCoordinadores",
                column: "CoordinadorsGeneralesId");

            migrationBuilder.CreateIndex(
                name: "IX_DirigentesMultiplicadores_SubCoordinadoresId",
                table: "DirigentesMultiplicadores",
                column: "SubCoordinadoresId");

            migrationBuilder.AddForeignKey(
                name: "FK_DirigentesMultiplicadores_SubCoordinadores_SubCoordinadoresId",
                table: "DirigentesMultiplicadores",
                column: "SubCoordinadoresId",
                principalTable: "SubCoordinadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCoordinadores_CoordinadoresGenerales_CoordinadorsGeneralesId",
                table: "SubCoordinadores",
                column: "CoordinadorsGeneralesId",
                principalTable: "CoordinadoresGenerales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DirigentesMultiplicadores_SubCoordinadores_SubCoordinadoresId",
                table: "DirigentesMultiplicadores");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCoordinadores_CoordinadoresGenerales_CoordinadorsGeneralesId",
                table: "SubCoordinadores");

            migrationBuilder.DropIndex(
                name: "IX_SubCoordinadores_CoordinadorsGeneralesId",
                table: "SubCoordinadores");

            migrationBuilder.DropIndex(
                name: "IX_DirigentesMultiplicadores_SubCoordinadoresId",
                table: "DirigentesMultiplicadores");

            migrationBuilder.DropColumn(
                name: "CoordinadorsGeneralesId",
                table: "SubCoordinadores");

            migrationBuilder.DropColumn(
                name: "SubCoordinadoresId",
                table: "DirigentesMultiplicadores");
        }
    }
}
