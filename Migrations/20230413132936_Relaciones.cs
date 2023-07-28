using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiprueba.Migrations
{
    /// <inheritdoc />
    public partial class Relaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ColaboradorId_Colaborador",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id_Colaborador",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Colaborador",
                columns: table => new
                {
                    Id_Colaborador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaborador", x => x.Id_Colaborador);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_ColaboradorId_Colaborador",
                table: "Usuarios",
                column: "ColaboradorId_Colaborador");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Colaborador_ColaboradorId_Colaborador",
                table: "Usuarios",
                column: "ColaboradorId_Colaborador",
                principalTable: "Colaborador",
                principalColumn: "Id_Colaborador");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Colaborador_ColaboradorId_Colaborador",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "Colaborador");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_ColaboradorId_Colaborador",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "ColaboradorId_Colaborador",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Id_Colaborador",
                table: "Usuarios");
        }
    }
}
