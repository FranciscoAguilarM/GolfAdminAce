using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace ProyectoFinalI.Migrations
{
    public partial class Tablas1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AsignarCarritos",
                columns: table => new
                {
                    IdAsig = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    MatriculaCarrito = table.Column<string>(type: "text", nullable: false),
                    NombreMiembro = table.Column<string>(type: "text", nullable: false),
                    nombreEmpleado = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsignarCarritos", x => x.IdAsig);
                });

            migrationBuilder.CreateTable(
                name: "Carritos",
                columns: table => new
                {
                    PkMatricula = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Modelo = table.Column<string>(type: "text", nullable: false),
                    Color = table.Column<string>(type: "text", nullable: false),
                    Observaciones = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carritos", x => x.PkMatricula);
                });

            migrationBuilder.CreateTable(
                name: "Miembros",
                columns: table => new
                {
                    PkMiembro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Apellido = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Miembros", x => x.PkMiembro);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    PkRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.PkRol);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    PkEmpleado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Apellido = table.Column<string>(type: "text", nullable: false),
                    Usuario = table.Column<string>(type: "text", nullable: false),
                    Contrasena = table.Column<string>(type: "text", nullable: false),
                    FKRol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.PkEmpleado);
                    table.ForeignKey(
                        name: "FK_Empleados_Roles_FKRol",
                        column: x => x.FKRol,
                        principalTable: "Roles",
                        principalColumn: "PkRol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Carritos",
                columns: new[] { "PkMatricula", "Color", "Modelo", "Observaciones" },
                values: new object[,]
                {
                    { 1, "gris", "Alesso", "Todo en orden" },
                    { 2, "Azul", "Onward", "Todo en orden" },
                    { 3, "Blanco", "Alesso", "En el taller" },
                    { 4, "Rojo", "Onward", "Todo En orden" },
                    { 5, "Amarillo", "rapss", "Fuera de Servicio" }
                });

            migrationBuilder.InsertData(
                table: "Miembros",
                columns: new[] { "PkMiembro", "Apellido", "Nombre" },
                values: new object[,]
                {
                    { 1, "Parker", "Peter" },
                    { 2, "Escamilla", "Franco" },
                    { 3, "Greyrat", "Rudius" },
                    { 4, "BoreasGreyrat", "Eris" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "PkRol", "Nombre" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Empleado" }
                });

            migrationBuilder.InsertData(
                table: "Empleados",
                columns: new[] { "PkEmpleado", "Apellido", "Contrasena", "FKRol", "Nombre", "Usuario" },
                values: new object[,]
                {
                    { 1, "Aguilar", "1234", 1, "Francisco", "Frans" },
                    { 3, "fermin", "123", 2, "Aaron", "afer" },
                    { 4, "jali", "123", 2, "tabata", "tabata" },
                    { 2, "Palomec", "1234", 2, "Angel", "sr.ph" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_FKRol",
                table: "Empleados",
                column: "FKRol");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AsignarCarritos");

            migrationBuilder.DropTable(
                name: "Carritos");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Miembros");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
