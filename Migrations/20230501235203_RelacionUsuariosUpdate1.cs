using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiprueba.Migrations
{
    /// <inheritdoc />
    public partial class RelacionUsuariosUpdate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id_Colaborador",
                table: "Usuarios",
                newName: "Colaborador_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Usuarios_Id_Colaborador",
                table: "Usuarios",
                newName: "IX_Usuarios_Colaborador_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Colaborador_Id",
                table: "Usuarios",
                newName: "Id_Colaborador");

            migrationBuilder.RenameIndex(
                name: "IX_Usuarios_Colaborador_Id",
                table: "Usuarios",
                newName: "IX_Usuarios_Id_Colaborador");
        }
    }
}
