using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoMobileSustentabilidade.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPFouCNPJ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PerfilEnum = table.Column<int>(type: "int", nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rua = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    UF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusEnum = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Administradores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administradores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Administradores_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DonosPosto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonosPosto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonosPosto_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    Saldo = table.Column<double>(type: "float", nullable: false),
                    IdAdministrador = table.Column<int>(type: "int", nullable: true),
                    AdministradorId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clientes_Administradores_AdministradorId",
                        column: x => x.AdministradorId,
                        principalTable: "Administradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clientes_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Liquidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorUnitario = table.Column<double>(type: "float", nullable: false),
                    IdAdministrador = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Liquidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Liquidos_Administradores_IdAdministrador",
                        column: x => x.IdAdministrador,
                        principalTable: "Administradores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Usinas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdAdministrador = table.Column<int>(type: "int", nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rua = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    UF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usinas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usinas_Administradores_IdAdministrador",
                        column: x => x.IdAdministrador,
                        principalTable: "Administradores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Postos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAdministrador = table.Column<int>(type: "int", nullable: true),
                    IdDonoPosto = table.Column<int>(type: "int", nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rua = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    UF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Postos_Administradores_IdAdministrador",
                        column: x => x.IdAdministrador,
                        principalTable: "Administradores",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Postos_DonosPosto_IdDonoPosto",
                        column: x => x.IdDonoPosto,
                        principalTable: "DonosPosto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FuncionariosPosto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdPosto = table.Column<int>(type: "int", nullable: false),
                    IdDonoPosto = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncionariosPosto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FuncionariosPosto_DonosPosto_IdDonoPosto",
                        column: x => x.IdDonoPosto,
                        principalTable: "DonosPosto",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FuncionariosPosto_Postos_IdPosto",
                        column: x => x.IdPosto,
                        principalTable: "Postos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FuncionariosPosto_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PostosAceitamLiquido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPosto = table.Column<int>(type: "int", nullable: false),
                    IdLiquido = table.Column<int>(type: "int", nullable: false),
                    CapacidadeTotal = table.Column<int>(type: "int", nullable: false),
                    CapacidadeOcupada = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostosAceitamLiquido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostosAceitamLiquido_Liquidos_IdLiquido",
                        column: x => x.IdLiquido,
                        principalTable: "Liquidos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PostosAceitamLiquido_Postos_IdPosto",
                        column: x => x.IdPosto,
                        principalTable: "Postos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TransacoesPosto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QtdAgendada = table.Column<int>(type: "int", nullable: false),
                    QtdConfirmada = table.Column<int>(type: "int", nullable: true),
                    DataAgendada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IdFuncionarioPosto = table.Column<int>(type: "int", nullable: true),
                    IdLiquido = table.Column<int>(type: "int", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransacoesPosto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransacoesPosto_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TransacoesPosto_FuncionariosPosto_IdFuncionarioPosto",
                        column: x => x.IdFuncionarioPosto,
                        principalTable: "FuncionariosPosto",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TransacoesPosto_Liquidos_IdLiquido",
                        column: x => x.IdLiquido,
                        principalTable: "Liquidos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TransacoesUsina",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Qtd = table.Column<int>(type: "int", nullable: false),
                    IdUsina = table.Column<int>(type: "int", nullable: false),
                    IdFuncionarioPosto = table.Column<int>(type: "int", nullable: false),
                    IdLiquido = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransacoesUsina", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransacoesUsina_FuncionariosPosto_IdFuncionarioPosto",
                        column: x => x.IdFuncionarioPosto,
                        principalTable: "FuncionariosPosto",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TransacoesUsina_Liquidos_IdLiquido",
                        column: x => x.IdLiquido,
                        principalTable: "Liquidos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TransacoesUsina_Usinas_IdUsina",
                        column: x => x.IdUsina,
                        principalTable: "Usinas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Administradores_IdUsuario",
                table: "Administradores",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_AdministradorId",
                table: "Clientes",
                column: "AdministradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_IdUsuario",
                table: "Clientes",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_DonosPosto_IdUsuario",
                table: "DonosPosto",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_FuncionariosPosto_IdDonoPosto",
                table: "FuncionariosPosto",
                column: "IdDonoPosto");

            migrationBuilder.CreateIndex(
                name: "IX_FuncionariosPosto_IdPosto",
                table: "FuncionariosPosto",
                column: "IdPosto");

            migrationBuilder.CreateIndex(
                name: "IX_FuncionariosPosto_IdUsuario",
                table: "FuncionariosPosto",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Liquidos_IdAdministrador",
                table: "Liquidos",
                column: "IdAdministrador");

            migrationBuilder.CreateIndex(
                name: "IX_Postos_IdAdministrador",
                table: "Postos",
                column: "IdAdministrador");

            migrationBuilder.CreateIndex(
                name: "IX_Postos_IdDonoPosto",
                table: "Postos",
                column: "IdDonoPosto");

            migrationBuilder.CreateIndex(
                name: "IX_PostosAceitamLiquido_IdLiquido",
                table: "PostosAceitamLiquido",
                column: "IdLiquido");

            migrationBuilder.CreateIndex(
                name: "IX_PostosAceitamLiquido_IdPosto",
                table: "PostosAceitamLiquido",
                column: "IdPosto");

            migrationBuilder.CreateIndex(
                name: "IX_TransacoesPosto_IdCliente",
                table: "TransacoesPosto",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_TransacoesPosto_IdFuncionarioPosto",
                table: "TransacoesPosto",
                column: "IdFuncionarioPosto");

            migrationBuilder.CreateIndex(
                name: "IX_TransacoesPosto_IdLiquido",
                table: "TransacoesPosto",
                column: "IdLiquido");

            migrationBuilder.CreateIndex(
                name: "IX_TransacoesUsina_IdFuncionarioPosto",
                table: "TransacoesUsina",
                column: "IdFuncionarioPosto");

            migrationBuilder.CreateIndex(
                name: "IX_TransacoesUsina_IdLiquido",
                table: "TransacoesUsina",
                column: "IdLiquido");

            migrationBuilder.CreateIndex(
                name: "IX_TransacoesUsina_IdUsina",
                table: "TransacoesUsina",
                column: "IdUsina");

            migrationBuilder.CreateIndex(
                name: "IX_Usinas_IdAdministrador",
                table: "Usinas",
                column: "IdAdministrador");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostosAceitamLiquido");

            migrationBuilder.DropTable(
                name: "TransacoesPosto");

            migrationBuilder.DropTable(
                name: "TransacoesUsina");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "FuncionariosPosto");

            migrationBuilder.DropTable(
                name: "Liquidos");

            migrationBuilder.DropTable(
                name: "Usinas");

            migrationBuilder.DropTable(
                name: "Postos");

            migrationBuilder.DropTable(
                name: "Administradores");

            migrationBuilder.DropTable(
                name: "DonosPosto");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
