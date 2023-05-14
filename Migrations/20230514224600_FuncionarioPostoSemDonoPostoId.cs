using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoMobileSustentabilidade.Migrations
{
    /// <inheritdoc />
    public partial class FuncionarioPostoSemDonoPostoId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FuncionariosPosto_DonosPosto_IdDonoPosto",
                table: "FuncionariosPosto");

            migrationBuilder.DropIndex(
                name: "IX_FuncionariosPosto_IdDonoPosto",
                table: "FuncionariosPosto");

            migrationBuilder.DropColumn(
                name: "IdDonoPosto",
                table: "FuncionariosPosto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdDonoPosto",
                table: "FuncionariosPosto",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FuncionariosPosto_IdDonoPosto",
                table: "FuncionariosPosto",
                column: "IdDonoPosto");

            migrationBuilder.AddForeignKey(
                name: "FK_FuncionariosPosto_DonosPosto_IdDonoPosto",
                table: "FuncionariosPosto",
                column: "IdDonoPosto",
                principalTable: "DonosPosto",
                principalColumn: "Id");
        }
    }
}
