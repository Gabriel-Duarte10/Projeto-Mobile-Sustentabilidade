using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoMobileSustentabilidade.Migrations
{
    /// <inheritdoc />
    public partial class ValorTransacaoItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Valor",
                table: "TransacaoItens",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Valor",
                table: "TransacaoItens");
        }
    }
}
