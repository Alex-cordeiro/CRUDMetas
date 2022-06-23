using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Telemetrix.API.Migrations
{
    public partial class migration_inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Setores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Filial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeFilial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpresaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Filial_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vendedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpresaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendedores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendedores_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PecasEServicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    FilialId = table.Column<int>(type: "int", nullable: false),
                    Setor = table.Column<int>(type: "int", nullable: false),
                    Vendedor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valor = table.Column<float>(type: "real", nullable: false),
                    DataValidade = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PecasEServicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PecasEServicos_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PecasEServicos_Filial_FilialId",
                        column: x => x.FilialId,
                        principalTable: "Filial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    FilialId = table.Column<int>(type: "int", nullable: false),
                    Setor = table.Column<int>(type: "int", nullable: false),
                    Vendedor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Familia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantidade = table.Column<float>(type: "real", nullable: false),
                    Valor = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Veiculos_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Veiculos_Filial_FilialId",
                        column: x => x.FilialId,
                        principalTable: "Filial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Filial_EmpresaId",
                table: "Filial",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_PecasEServicos_EmpresaId",
                table: "PecasEServicos",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_PecasEServicos_FilialId",
                table: "PecasEServicos",
                column: "FilialId");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_EmpresaId",
                table: "Veiculos",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_FilialId",
                table: "Veiculos",
                column: "FilialId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendedores_EmpresaId",
                table: "Vendedores",
                column: "EmpresaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PecasEServicos");

            migrationBuilder.DropTable(
                name: "Setores");

            migrationBuilder.DropTable(
                name: "Veiculos");

            migrationBuilder.DropTable(
                name: "Vendedores");

            migrationBuilder.DropTable(
                name: "Filial");

            migrationBuilder.DropTable(
                name: "Empresas");
        }
    }
}
