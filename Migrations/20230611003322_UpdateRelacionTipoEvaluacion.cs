using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiprueba.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelacionTipoEvaluacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Tipo_Evaluacion_Id",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Tipo_Evaluacion_Id",
                table: "Usuarios",
                column: "Tipo_Evaluacion_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Tipo_Evaluacion_Tipo_Evaluacion_Id",
                table: "Usuarios",
                column: "Tipo_Evaluacion_Id",
                principalTable: "Tipo_Evaluacion",
                principalColumn: "Id_Tipo_Evaluacion",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Tipo_Evaluacion_Tipo_Evaluacion_Id",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_Tipo_Evaluacion_Id",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Tipo_Evaluacion_Id",
                table: "Usuarios");
        }
    }
}
