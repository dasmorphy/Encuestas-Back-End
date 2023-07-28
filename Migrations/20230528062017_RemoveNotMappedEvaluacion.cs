using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiprueba.Migrations
{
    /// <inheritdoc />
    public partial class RemoveNotMappedEvaluacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluacion_PreguntasByEvaluacion_PreguntasByEvaluacionModelId_Preguntas_Tipo",
                table: "Evaluacion");

            migrationBuilder.AlterColumn<int>(
                name: "PreguntasByEvaluacionModelId_Preguntas_Tipo",
                table: "Evaluacion",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColaboradorModelId_Colaborador",
                table: "Evaluacion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuariosModelId_Usuario",
                table: "Evaluacion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Evaluacion_ColaboradorModelId_Colaborador",
                table: "Evaluacion",
                column: "ColaboradorModelId_Colaborador");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluacion_UsuariosModelId_Usuario",
                table: "Evaluacion",
                column: "UsuariosModelId_Usuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluacion_Colaborador_ColaboradorModelId_Colaborador",
                table: "Evaluacion",
                column: "ColaboradorModelId_Colaborador",
                principalTable: "Colaborador",
                principalColumn: "Id_Colaborador",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluacion_PreguntasByEvaluacion_PreguntasByEvaluacionModelId_Preguntas_Tipo",
                table: "Evaluacion",
                column: "PreguntasByEvaluacionModelId_Preguntas_Tipo",
                principalTable: "PreguntasByEvaluacion",
                principalColumn: "Id_Preguntas_Tipo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluacion_Usuarios_UsuariosModelId_Usuario",
                table: "Evaluacion",
                column: "UsuariosModelId_Usuario",
                principalTable: "Usuarios",
                principalColumn: "Id_Usuario",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluacion_Colaborador_ColaboradorModelId_Colaborador",
                table: "Evaluacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Evaluacion_PreguntasByEvaluacion_PreguntasByEvaluacionModelId_Preguntas_Tipo",
                table: "Evaluacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Evaluacion_Usuarios_UsuariosModelId_Usuario",
                table: "Evaluacion");

            migrationBuilder.DropIndex(
                name: "IX_Evaluacion_ColaboradorModelId_Colaborador",
                table: "Evaluacion");

            migrationBuilder.DropIndex(
                name: "IX_Evaluacion_UsuariosModelId_Usuario",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "ColaboradorModelId_Colaborador",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "UsuariosModelId_Usuario",
                table: "Evaluacion");

            migrationBuilder.AlterColumn<int>(
                name: "PreguntasByEvaluacionModelId_Preguntas_Tipo",
                table: "Evaluacion",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluacion_PreguntasByEvaluacion_PreguntasByEvaluacionModelId_Preguntas_Tipo",
                table: "Evaluacion",
                column: "PreguntasByEvaluacionModelId_Preguntas_Tipo",
                principalTable: "PreguntasByEvaluacion",
                principalColumn: "Id_Preguntas_Tipo");
        }
    }
}
