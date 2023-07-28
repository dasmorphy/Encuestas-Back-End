using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiprueba.Migrations
{
    /// <inheritdoc />
    public partial class CargosModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cargo_Id",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CargosModelId_Cargo",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    Id_Cargo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Cargo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.Id_Cargo);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_CargosModelId_Cargo",
                table: "Usuarios",
                column: "CargosModelId_Cargo");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Cargos_CargosModelId_Cargo",
                table: "Usuarios",
                column: "CargosModelId_Cargo",
                principalTable: "Cargos",
                principalColumn: "Id_Cargo",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Cargos_CargosModelId_Cargo",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "Cargos");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_CargosModelId_Cargo",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Cargo_Id",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "CargosModelId_Cargo",
                table: "Usuarios");
        }
    }
}
