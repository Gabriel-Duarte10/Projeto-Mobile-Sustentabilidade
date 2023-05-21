using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoMobileSustentabilidade.Migrations
{
    /// <inheritdoc />
    public partial class dataConfirmadaePosto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataConfirmada",
                table: "TransacoesPosto",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "IdPosto",
                table: "TransacoesPosto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PostoId",
                table: "TransacoesPosto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TransacoesPosto_PostoId",
                table: "TransacoesPosto",
                column: "PostoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransacoesPosto_Postos_PostoId",
                table: "TransacoesPosto",
                column: "PostoId",
                principalTable: "Postos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransacoesPosto_Postos_PostoId",
                table: "TransacoesPosto");

            migrationBuilder.DropIndex(
                name: "IX_TransacoesPosto_PostoId",
                table: "TransacoesPosto");

            migrationBuilder.DropColumn(
                name: "DataConfirmada",
                table: "TransacoesPosto");

            migrationBuilder.DropColumn(
                name: "IdPosto",
                table: "TransacoesPosto");

            migrationBuilder.DropColumn(
                name: "PostoId",
                table: "TransacoesPosto");
        }
    }
}
