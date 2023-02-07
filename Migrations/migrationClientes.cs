using Microsoft.EntityFrameworkCore.Migrations;

namespace api_librerias_paco.Migrations
{

    public partial class Initial : Migration
    {

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false).
                    Annotation("SqlServer:Identity", "1,1"),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    saldo = table.Column<int>(type: "int", nullable: false),
                    fechaCreacion = table.Column<DateTime>(type: "DateTime", nullable: false),
                    
                    //Controlar unidades 0 y negativo
                    
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Id", x => x.Id);
                }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }}
