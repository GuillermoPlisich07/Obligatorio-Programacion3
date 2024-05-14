using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaDatos.Migrations
{
    /// <inheritdoc />
    public partial class PruebasGuille : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "codigoProveedor_Valor",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "descripcion_Valor",
                table: "Articulos");

            migrationBuilder.RenameColumn(
                name: "nombre_Valor",
                table: "Articulos",
                newName: "codigoProveedor");

            migrationBuilder.AddColumn<string>(
                name: "descripcion",
                table: "Articulos",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "nombre",
                table: "Articulos",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "descripcion",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "nombre",
                table: "Articulos");

            migrationBuilder.RenameColumn(
                name: "codigoProveedor",
                table: "Articulos",
                newName: "nombre_Valor");

            migrationBuilder.AddColumn<int>(
                name: "codigoProveedor_Valor",
                table: "Articulos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "descripcion_Valor",
                table: "Articulos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
