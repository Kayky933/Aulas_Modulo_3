using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API_2._0.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conta",
                columns: table => new
                {
                    Id_Conta = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeDoCredor = table.Column<string>(maxLength: 100, nullable: true),
                    DataDoVencimento = table.Column<DateTime>(nullable: false),
                    ValorAPagar = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DataDoPagamento = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conta", x => x.Id_Conta);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conta");
        }
    }
}
