using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoMobileSustentabilidade.Migrations
{
    /// <inheritdoc />
    public partial class transacaoPostoItens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransacoesPosto_Liquidos_IdLiquido",
                table: "TransacoesPosto");

            migrationBuilder.DropForeignKey(
                name: "FK_TransacoesPosto_Postos_PostoId",
                table: "TransacoesPosto");

            migrationBuilder.DropIndex(
                name: "IX_TransacoesPosto_IdLiquido",
                table: "TransacoesPosto");

            migrationBuilder.DropIndex(
                name: "IX_TransacoesPosto_PostoId",
                table: "TransacoesPosto");

            migrationBuilder.DropColumn(
                name: "IdLiquido",
                table: "TransacoesPosto");

            migrationBuilder.DropColumn(
                name: "PostoId",
                table: "TransacoesPosto");

            migrationBuilder.DropColumn(
                name: "QtdAgendada",
                table: "TransacoesPosto");

            migrationBuilder.DropColumn(
                name: "QtdConfirmada",
                table: "TransacoesPosto");

            migrationBuilder.CreateTable(
                name: "TransacaoItens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTransacaoPosto = table.Column<int>(type: "int", nullable: false),
                    QtdAgendada = table.Column<int>(type: "int", nullable: false),
                    QtdConfirmada = table.Column<int>(type: "int", nullable: true),
                    IdLiquido = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransacaoItens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransacaoItens_Liquidos_IdLiquido",
                        column: x => x.IdLiquido,
                        principalTable: "Liquidos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TransacaoItens_TransacoesPosto_IdTransacaoPosto",
                        column: x => x.IdTransacaoPosto,
                        principalTable: "TransacoesPosto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransacoesPosto_IdPosto",
                table: "TransacoesPosto",
                column: "IdPosto");

            migrationBuilder.CreateIndex(
                name: "IX_TransacaoItens_IdLiquido",
                table: "TransacaoItens",
                column: "IdLiquido");

            migrationBuilder.CreateIndex(
                name: "IX_TransacaoItens_IdTransacaoPosto",
                table: "TransacaoItens",
                column: "IdTransacaoPosto");

            migrationBuilder.AddForeignKey(
                name: "FK_TransacoesPosto_Postos_IdPosto",
                table: "TransacoesPosto",
                column: "IdPosto",
                principalTable: "Postos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransacoesPosto_Postos_IdPosto",
                table: "TransacoesPosto");

            migrationBuilder.DropTable(
                name: "TransacaoItens");

            migrationBuilder.DropIndex(
                name: "IX_TransacoesPosto_IdPosto",
                table: "TransacoesPosto");

            migrationBuilder.AddColumn<int>(
                name: "IdLiquido",
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

            migrationBuilder.AddColumn<int>(
                name: "QtdAgendada",
                table: "TransacoesPosto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QtdConfirmada",
                table: "TransacoesPosto",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransacoesPosto_IdLiquido",
                table: "TransacoesPosto",
                column: "IdLiquido");

            migrationBuilder.CreateIndex(
                name: "IX_TransacoesPosto_PostoId",
                table: "TransacoesPosto",
                column: "PostoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransacoesPosto_Liquidos_IdLiquido",
                table: "TransacoesPosto",
                column: "IdLiquido",
                principalTable: "Liquidos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TransacoesPosto_Postos_PostoId",
                table: "TransacoesPosto",
                column: "PostoId",
                principalTable: "Postos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
