using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaDatos.Migrations
{
    /// <inheritdoc />
    public partial class Impuestos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Impuesto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IVA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    entregaExpressComun = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    entregaExpressMismoDia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    entregaComunMayorCien = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Impuesto", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Impuesto");
        }
    }
}
