using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiprueba.Migrations
{
    /// <inheritdoc />
    public partial class RemoveListUsuarioTableCargos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Cargos_CargosModelId_Cargo",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_CargosModelId_Cargo",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "CargosModelId_Cargo",
                table: "Usuarios");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CargosModelId_Cargo",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_CargosModelId_Cargo",
                table: "Usuarios",
                column: "CargosModelId_Cargo");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Cargos_CargosModelId_Cargo",
                table: "Usuarios",
                column: "CargosModelId_Cargo",
                principalTable: "Cargos",
                principalColumn: "Id_Cargo");
        }
    }
}
