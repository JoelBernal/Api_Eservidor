using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_librerias_paco.Migrations
{
    public partial class nombreMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    saldo = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Libro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Autor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Paginas = table.Column<int>(type: "int", nullable: true),
                    enVenta = table.Column<bool>(type: "bit", nullable: true),
                    FechaPublicacion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LibrosClientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(type: "int", nullable: true),
                    Idlibro = table.Column<int>(type: "int", nullable: true),
                    NombreLibro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    LibroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibrosClientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LibrosClientes_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LibrosClientes_Libro_LibroId",
                        column: x => x.LibroId,
                        principalTable: "Libro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tiendas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    comunidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    localidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    calle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codigopostal = table.Column<int>(type: "int", nullable: true),
                    trabajadores = table.Column<int>(type: "int", nullable: true),
                    libroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tiendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tiendas_Libro_libroId",
                        column: x => x.libroId,
                        principalTable: "Libro",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LibrosClientes_ClienteId",
                table: "LibrosClientes",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_LibrosClientes_LibroId",
                table: "LibrosClientes",
                column: "LibroId");

            migrationBuilder.CreateIndex(
                name: "IX_Tiendas_libroId",
                table: "Tiendas",
                column: "libroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LibrosClientes");

            migrationBuilder.DropTable(
                name: "Tiendas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Libro");
        }
    }
}
