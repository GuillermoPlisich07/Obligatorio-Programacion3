using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaDatos.Migrations
{
    /// <inheritdoc />
    public partial class PedidosModificacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lineas_Pedido_Pedidoid",
                table: "Lineas");

            migrationBuilder.DropIndex(
                name: "IX_Lineas_Pedidoid",
                table: "Lineas");

            migrationBuilder.DropColumn(
                name: "Pedidoid",
                table: "Lineas");

            migrationBuilder.CreateTable(
                name: "LineaPedido",
                columns: table => new
                {
                    Pedidoid = table.Column<int>(type: "int", nullable: false),
                    lineasid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineaPedido", x => new { x.Pedidoid, x.lineasid });
                    table.ForeignKey(
                        name: "FK_LineaPedido_Lineas_lineasid",
                        column: x => x.lineasid,
                        principalTable: "Lineas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LineaPedido_Pedido_Pedidoid",
                        column: x => x.Pedidoid,
                        principalTable: "Pedido",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LineaPedido_lineasid",
                table: "LineaPedido",
                column: "lineasid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LineaPedido");

            migrationBuilder.AddColumn<int>(
                name: "Pedidoid",
                table: "Lineas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Lineas_Pedidoid",
                table: "Lineas",
                column: "Pedidoid");

            migrationBuilder.AddForeignKey(
                name: "FK_Lineas_Pedido_Pedidoid",
                table: "Lineas",
                column: "Pedidoid",
                principalTable: "Pedido",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
