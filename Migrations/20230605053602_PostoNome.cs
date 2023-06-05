﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoMobileSustentabilidade.Migrations
{
    /// <inheritdoc />
    public partial class PostoNome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Postos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Postos");
        }
    }
}
