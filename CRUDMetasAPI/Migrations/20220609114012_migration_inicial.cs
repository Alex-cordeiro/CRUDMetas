using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUDMetasAPI.Migrations
{
    public partial class migration_inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmpresasFiliais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    FilialId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresasFiliais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PecasEServicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Empresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Filial = table.Column<int>(type: "int", nullable: false),
                    Setor = table.Column<int>(type: "int", nullable: false),
                    Vendedor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valor = table.Column<float>(type: "real", nullable: false),
                    DataValidade = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PecasEServicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Empresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                });

            migrationBuilder.CreateTable(
                name: "Filial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeFilial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpresaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filial", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilialId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empresas_Filial_FilialId",
                        column: x => x.FilialId,
                        principalTable: "Filial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_FilialId",
                table: "Empresas",
                column: "FilialId");

            migrationBuilder.CreateIndex(
                name: "IX_Filial_EmpresaId",
                table: "Filial",
                column: "EmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Filial_Empresas_EmpresaId",
                table: "Filial",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_Filial_FilialId",
                table: "Empresas");

            migrationBuilder.DropTable(
                name: "EmpresasFiliais");

            migrationBuilder.DropTable(
                name: "PecasEServicos");

            migrationBuilder.DropTable(
                name: "Veiculos");

            migrationBuilder.DropTable(
                name: "Filial");

            migrationBuilder.DropTable(
                name: "Empresas");
        }
    }
}
