using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiprueba.Migrations
{
    /// <inheritdoc />
    public partial class RelacionUsuarioToEvaluacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuariosModelId_Usuario",
                table: "Evaluacion",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Evaluacion_UsuariosModelId_Usuario",
                table: "Evaluacion",
                column: "UsuariosModelId_Usuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluacion_Usuarios_UsuariosModelId_Usuario",
                table: "Evaluacion",
                column: "UsuariosModelId_Usuario",
                principalTable: "Usuarios",
                principalColumn: "Id_Usuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluacion_Usuarios_UsuariosModelId_Usuario",
                table: "Evaluacion");

            migrationBuilder.DropIndex(
                name: "IX_Evaluacion_UsuariosModelId_Usuario",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "UsuariosModelId_Usuario",
                table: "Evaluacion");
        }
    }
}
