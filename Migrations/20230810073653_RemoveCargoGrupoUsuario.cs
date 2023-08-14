using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiprueba.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCargoGrupoUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Cargos_CargosModelId_Cargo",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Cargo_Id",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Grupo",
                table: "Usuarios");

            migrationBuilder.AlterColumn<int>(
                name: "CargosModelId_Cargo",
                table: "Usuarios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Cargos_CargosModelId_Cargo",
                table: "Usuarios",
                column: "CargosModelId_Cargo",
                principalTable: "Cargos",
                principalColumn: "Id_Cargo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Cargos_CargosModelId_Cargo",
                table: "Usuarios");

            migrationBuilder.AlterColumn<int>(
                name: "CargosModelId_Cargo",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Cargo_Id",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Grupo",
                table: "Usuarios",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Cargos_CargosModelId_Cargo",
                table: "Usuarios",
                column: "CargosModelId_Cargo",
                principalTable: "Cargos",
                principalColumn: "Id_Cargo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
