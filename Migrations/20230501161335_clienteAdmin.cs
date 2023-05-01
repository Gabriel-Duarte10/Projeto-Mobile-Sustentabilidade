using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoMobileSustentabilidade.Migrations
{
    /// <inheritdoc />
    public partial class clienteAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Administradores_AdministradorId",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_AdministradorId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "AdministradorId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "IdAdministrador",
                table: "Clientes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdministradorId",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdAdministrador",
                table: "Clientes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_AdministradorId",
                table: "Clientes",
                column: "AdministradorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Administradores_AdministradorId",
                table: "Clientes",
                column: "AdministradorId",
                principalTable: "Administradores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
