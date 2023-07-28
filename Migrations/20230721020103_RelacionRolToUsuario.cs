using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiprueba.Migrations
{
    /// <inheritdoc />
    public partial class RelacionRolToUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Roles_Id_Usuario",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Id_Usuario",
                table: "Roles");

            migrationBuilder.AddColumn<int>(
                name: "Rol_Id",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RolesModelId_Rol",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RolesModelId_Rol",
                table: "Usuarios",
                column: "RolesModelId_Rol");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Roles_RolesModelId_Rol",
                table: "Usuarios",
                column: "RolesModelId_Rol",
                principalTable: "Roles",
                principalColumn: "Id_Rol",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Roles_RolesModelId_Rol",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_RolesModelId_Rol",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Rol_Id",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "RolesModelId_Rol",
                table: "Usuarios");

            migrationBuilder.AddColumn<int>(
                name: "Id_Usuario",
                table: "Roles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Id_Usuario",
                table: "Roles",
                column: "Id_Usuario",
                unique: true);
        }
    }
}
