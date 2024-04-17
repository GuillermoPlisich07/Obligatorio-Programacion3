using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaDatos.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articulos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    codigoProveedor = table.Column<int>(type: "int", maxLength: 13, nullable: false),
                    precioPublico = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    razonSocial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RUT = table.Column<int>(type: "int", nullable: false),
                    ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numPuerta = table.Column<int>(type: "int", nullable: false),
                    calle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    distancia = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    passwordHash = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaPedido = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idCliente = table.Column<int>(type: "int", nullable: false),
                    total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IVA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    recargo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    fechaPrometida = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.id);
                    table.ForeignKey(
                        name: "FK_Pedido_Cliente_idCliente",
                        column: x => x.idCliente,
                        principalTable: "Cliente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lineas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    articuloid = table.Column<int>(type: "int", nullable: false),
                    cantUnidades = table.Column<int>(type: "int", nullable: false),
                    preUnitarioVigente = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Pedidoid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lineas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Lineas_Articulos_articuloid",
                        column: x => x.articuloid,
                        principalTable: "Articulos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lineas_Pedido_Pedidoid",
                        column: x => x.Pedidoid,
                        principalTable: "Pedido",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "PedidoComun",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    distancia = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoComun", x => x.id);
                    table.ForeignKey(
                        name: "FK_PedidoComun_Pedido_id",
                        column: x => x.id,
                        principalTable: "Pedido",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PedidoExpress",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    plazoDias = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoExpress", x => x.id);
                    table.ForeignKey(
                        name: "FK_PedidoExpress_Pedido_id",
                        column: x => x.id,
                        principalTable: "Pedido",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lineas_articuloid",
                table: "Lineas",
                column: "articuloid");

            migrationBuilder.CreateIndex(
                name: "IX_Lineas_Pedidoid",
                table: "Lineas",
                column: "Pedidoid");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_idCliente",
                table: "Pedido",
                column: "idCliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lineas");

            migrationBuilder.DropTable(
                name: "PedidoComun");

            migrationBuilder.DropTable(
                name: "PedidoExpress");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Articulos");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
