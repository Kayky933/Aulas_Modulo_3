using Microsoft.EntityFrameworkCore.Migrations;

namespace API_01.Migrations
{
    public partial class AjustesNosModelsEInterfaces : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Conta",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Conta");
        }
    }
}
