using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiprueba.Migrations
{
    /// <inheritdoc />
    public partial class Reverse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colaborador_Evaluacion_EvaluacionModelId_Evaluacion",
                table: "Colaborador");

            migrationBuilder.DropForeignKey(
                name: "FK_Evaluacion_PreguntasByEvaluacion_PreguntasByEvaluacionModelId_Preguntas_Tipo",
                table: "Evaluacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Evaluacion_Usuarios_UsuariosModelId_Usuario",
                table: "Evaluacion");

            migrationBuilder.DropIndex(
                name: "IX_Evaluacion_UsuariosModelId_Usuario",
                table: "Evaluacion");

            migrationBuilder.DropIndex(
                name: "IX_Colaborador_EvaluacionModelId_Evaluacion",
                table: "Colaborador");

            migrationBuilder.DropColumn(
                name: "UsuariosModelId_Usuario",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "EvaluacionModelId_Evaluacion",
                table: "Colaborador");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "UsuariosModelId_Usuario",
                table: "Evaluacion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EvaluacionModelId_Evaluacion",
                table: "Colaborador",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Evaluacion_UsuariosModelId_Usuario",
                table: "Evaluacion",
                column: "UsuariosModelId_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_EvaluacionModelId_Evaluacion",
                table: "Colaborador",
                column: "EvaluacionModelId_Evaluacion");

            migrationBuilder.AddForeignKey(
                name: "FK_Colaborador_Evaluacion_EvaluacionModelId_Evaluacion",
                table: "Colaborador",
                column: "EvaluacionModelId_Evaluacion",
                principalTable: "Evaluacion",
                principalColumn: "Id_Evaluacion");

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
    }
}
