using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Persistencia.Migrations
{
    public partial class AdicionEstado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "Productos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "Marcas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "Categorias",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Marcas");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Categorias");
        }
    }
}
