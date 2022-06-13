using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUDMetasAPI.Migrations
{
    public partial class alteracao_tabela_usuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "User",
                table: "Usuarios",
                newName: "Username");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Usuarios",
                newName: "User");
        }
    }
}
