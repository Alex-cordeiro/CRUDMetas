using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUDMetasAPI.Migrations
{
    public partial class alteracao_pecas_e_servicos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Vendedor",
                table: "PecasEServicos");

            migrationBuilder.RenameColumn(
                name: "Setor",
                table: "PecasEServicos",
                newName: "VendedorId");

            migrationBuilder.AddColumn<int>(
                name: "SetorId",
                table: "PecasEServicos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PecasEServicos_SetorId",
                table: "PecasEServicos",
                column: "SetorId");

            migrationBuilder.CreateIndex(
                name: "IX_PecasEServicos_VendedorId",
                table: "PecasEServicos",
                column: "VendedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_PecasEServicos_Setores_SetorId",
                table: "PecasEServicos",
                column: "SetorId",
                principalTable: "Setores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PecasEServicos_Vendedores_VendedorId",
                table: "PecasEServicos",
                column: "VendedorId",
                principalTable: "Vendedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PecasEServicos_Setores_SetorId",
                table: "PecasEServicos");

            migrationBuilder.DropForeignKey(
                name: "FK_PecasEServicos_Vendedores_VendedorId",
                table: "PecasEServicos");

            migrationBuilder.DropIndex(
                name: "IX_PecasEServicos_SetorId",
                table: "PecasEServicos");

            migrationBuilder.DropIndex(
                name: "IX_PecasEServicos_VendedorId",
                table: "PecasEServicos");

            migrationBuilder.DropColumn(
                name: "SetorId",
                table: "PecasEServicos");

            migrationBuilder.RenameColumn(
                name: "VendedorId",
                table: "PecasEServicos",
                newName: "Setor");

            migrationBuilder.AddColumn<string>(
                name: "Vendedor",
                table: "PecasEServicos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
