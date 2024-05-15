using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaDatos.Migrations
{
    /// <inheritdoc />
    public partial class Pedidosfluentapi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lineas_Pedido_Pedidoid",
                table: "Lineas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Clientes_idCliente",
                table: "Pedido");

            migrationBuilder.RenameColumn(
                name: "recargo",
                table: "Pedido",
                newName: "recarga");

            migrationBuilder.AddColumn<bool>(
                name: "activo",
                table: "Pedido",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "Pedidoid",
                table: "Lineas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddCheckConstraint(
                name: "CHK_PedidoExpress_plazoDias",
                table: "PedidoExpress",
                sql: "plazoDias BETWEEN 1 AND 5");

            migrationBuilder.AddForeignKey(
                name: "FK_Lineas_Pedido_Pedidoid",
                table: "Lineas",
                column: "Pedidoid",
                principalTable: "Pedido",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Cliente",
                table: "Pedido",
                column: "idCliente",
                principalTable: "Clientes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lineas_Pedido_Pedidoid",
                table: "Lineas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Cliente",
                table: "Pedido");

            migrationBuilder.DropCheckConstraint(
                name: "CHK_PedidoExpress_plazoDias",
                table: "PedidoExpress");

            migrationBuilder.DropColumn(
                name: "activo",
                table: "Pedido");

            migrationBuilder.RenameColumn(
                name: "recarga",
                table: "Pedido",
                newName: "recargo");

            migrationBuilder.AlterColumn<int>(
                name: "Pedidoid",
                table: "Lineas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Lineas_Pedido_Pedidoid",
                table: "Lineas",
                column: "Pedidoid",
                principalTable: "Pedido",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Clientes_idCliente",
                table: "Pedido",
                column: "idCliente",
                principalTable: "Clientes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
