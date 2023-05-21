using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoMobileSustentabilidade.Migrations
{
    /// <inheritdoc />
    public partial class TransacaoUsina : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransacoesUsina_Liquidos_IdLiquido",
                table: "TransacoesUsina");

            migrationBuilder.DropIndex(
                name: "IX_TransacoesUsina_IdLiquido",
                table: "TransacoesUsina");

            migrationBuilder.DropColumn(
                name: "IdLiquido",
                table: "TransacoesUsina");

            migrationBuilder.DropColumn(
                name: "Qtd",
                table: "TransacoesUsina");

            migrationBuilder.CreateTable(
                name: "TransacoesItensUsina",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTransacaoUsina = table.Column<int>(type: "int", nullable: false),
                    Qtd = table.Column<int>(type: "int", nullable: false),
                    IdLiquido = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransacoesItensUsina", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransacoesItensUsina_Liquidos_IdLiquido",
                        column: x => x.IdLiquido,
                        principalTable: "Liquidos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TransacoesItensUsina_TransacoesUsina_IdTransacaoUsina",
                        column: x => x.IdTransacaoUsina,
                        principalTable: "TransacoesUsina",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransacoesItensUsina_IdLiquido",
                table: "TransacoesItensUsina",
                column: "IdLiquido");

            migrationBuilder.CreateIndex(
                name: "IX_TransacoesItensUsina_IdTransacaoUsina",
                table: "TransacoesItensUsina",
                column: "IdTransacaoUsina");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransacoesItensUsina");

            migrationBuilder.AddColumn<int>(
                name: "IdLiquido",
                table: "TransacoesUsina",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Qtd",
                table: "TransacoesUsina",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TransacoesUsina_IdLiquido",
                table: "TransacoesUsina",
                column: "IdLiquido");

            migrationBuilder.AddForeignKey(
                name: "FK_TransacoesUsina_Liquidos_IdLiquido",
                table: "TransacoesUsina",
                column: "IdLiquido",
                principalTable: "Liquidos",
                principalColumn: "Id");
        }
    }
}
