using Microsoft.EntityFrameworkCore.Migrations;

namespace Telemetrix.API.Migrations
{
    public partial class alteracao_setor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "Setores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Setores_EmpresaId",
                table: "Setores",
                column: "EmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Setores_Empresas_EmpresaId",
                table: "Setores",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Setores_Empresas_EmpresaId",
                table: "Setores");

            migrationBuilder.DropIndex(
                name: "IX_Setores_EmpresaId",
                table: "Setores");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Setores");
        }
    }
}
