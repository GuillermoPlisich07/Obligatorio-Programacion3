using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaDatos.Migrations
{
    /// <inheritdoc />
    public partial class VOs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                newName: "codigoProveedor_Valor");

            migrationBuilder.AddColumn<string>(
                name: "descripcion_Valor",
                table: "Articulos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "nombre_Valor",
                table: "Articulos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "descripcion_Valor",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "nombre_Valor",
                table: "Articulos");

            migrationBuilder.RenameColumn(
                name: "codigoProveedor_Valor",
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
    }
}
