using Microsoft.EntityFrameworkCore.Migrations;

namespace Telemetrix.API.Migrations
{
    public partial class alteracao_tabela_veiculo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Veiculos_Empresas_EmpresaId",
                table: "Veiculos");

            migrationBuilder.DropForeignKey(
                name: "FK_Veiculos_Filial_FilialId",
                table: "Veiculos");

            migrationBuilder.DropIndex(
                name: "IX_Veiculos_EmpresaId",
                table: "Veiculos");

            migrationBuilder.DropIndex(
                name: "IX_Veiculos_FilialId",
                table: "Veiculos");

            migrationBuilder.DropColumn(
                name: "Vendedor",
                table: "Veiculos");

            migrationBuilder.RenameColumn(
                name: "Setor",
                table: "Veiculos",
                newName: "VendedorId");

            migrationBuilder.AlterColumn<int>(
                name: "Quantidade",
                table: "Veiculos",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<int>(
                name: "SetorId",
                table: "Veiculos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SetorId",
                table: "Veiculos");

            migrationBuilder.RenameColumn(
                name: "VendedorId",
                table: "Veiculos",
                newName: "Setor");

            migrationBuilder.AlterColumn<float>(
                name: "Quantidade",
                table: "Veiculos",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Vendedor",
                table: "Veiculos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_EmpresaId",
                table: "Veiculos",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_FilialId",
                table: "Veiculos",
                column: "FilialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculos_Empresas_EmpresaId",
                table: "Veiculos",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculos_Filial_FilialId",
                table: "Veiculos",
                column: "FilialId",
                principalTable: "Filial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
