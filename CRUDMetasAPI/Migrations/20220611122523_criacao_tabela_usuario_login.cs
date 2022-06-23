using Microsoft.EntityFrameworkCore.Migrations;

namespace Telemetrix.API.Migrations
{
    public partial class criacao_tabela_usuario_login : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Setores_Empresas_EmpresaId",
                table: "Setores");

            migrationBuilder.DropIndex(
                name: "IX_Setores_EmpresaId",
                table: "Setores");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
