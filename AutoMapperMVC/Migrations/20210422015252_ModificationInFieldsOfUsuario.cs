using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoMapperMVC.Migrations
{
    public partial class ModificationInFieldsOfUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuarioModelView");

            migrationBuilder.AddColumn<int>(
                name: "EnderecoId",
                table: "Usuario",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UsuarioEndereco",
                columns: table => new
                {
                    Id_Endereco = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioEndereco", x => x.Id_Endereco);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_EnderecoId",
                table: "Usuario",
                column: "EnderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_UsuarioEndereco_EnderecoId",
                table: "Usuario",
                column: "EnderecoId",
                principalTable: "UsuarioEndereco",
                principalColumn: "Id_Endereco",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_UsuarioEndereco_EnderecoId",
                table: "Usuario");

            migrationBuilder.DropTable(
                name: "UsuarioEndereco");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_EnderecoId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Usuario");

            migrationBuilder.CreateTable(
                name: "UsuarioModelView",
                columns: table => new
                {
                    Id_Usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioModelView", x => x.Id_Usuario);
                });
        }
    }
}
