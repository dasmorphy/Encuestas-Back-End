using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiprueba.Migrations
{
    /// <inheritdoc />
    public partial class RemoveNoTMappedPreguntas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PreguntasByEvaluacion_ModuloEvaluacion_ModuloEvaluacionModelId_Modulo_Evaluacion",
                table: "PreguntasByEvaluacion");

            migrationBuilder.DropForeignKey(
                name: "FK_PreguntasByEvaluacion_PreguntasEvaluacion_PreguntasEvaluacionModelId_Pregunta",
                table: "PreguntasByEvaluacion");

            migrationBuilder.DropForeignKey(
                name: "FK_PreguntasByEvaluacion_Tipo_Evaluacion_TipoEvaluacionModelId_Tipo_Evaluacion",
                table: "PreguntasByEvaluacion");

            migrationBuilder.AlterColumn<int>(
                name: "TipoEvaluacionModelId_Tipo_Evaluacion",
                table: "PreguntasByEvaluacion",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PreguntasEvaluacionModelId_Pregunta",
                table: "PreguntasByEvaluacion",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ModuloEvaluacionModelId_Modulo_Evaluacion",
                table: "PreguntasByEvaluacion",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PreguntasByEvaluacion_ModuloEvaluacion_ModuloEvaluacionModelId_Modulo_Evaluacion",
                table: "PreguntasByEvaluacion",
                column: "ModuloEvaluacionModelId_Modulo_Evaluacion",
                principalTable: "ModuloEvaluacion",
                principalColumn: "Id_Modulo_Evaluacion",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PreguntasByEvaluacion_PreguntasEvaluacion_PreguntasEvaluacionModelId_Pregunta",
                table: "PreguntasByEvaluacion",
                column: "PreguntasEvaluacionModelId_Pregunta",
                principalTable: "PreguntasEvaluacion",
                principalColumn: "Id_Pregunta",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PreguntasByEvaluacion_Tipo_Evaluacion_TipoEvaluacionModelId_Tipo_Evaluacion",
                table: "PreguntasByEvaluacion",
                column: "TipoEvaluacionModelId_Tipo_Evaluacion",
                principalTable: "Tipo_Evaluacion",
                principalColumn: "Id_Tipo_Evaluacion",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PreguntasByEvaluacion_ModuloEvaluacion_ModuloEvaluacionModelId_Modulo_Evaluacion",
                table: "PreguntasByEvaluacion");

            migrationBuilder.DropForeignKey(
                name: "FK_PreguntasByEvaluacion_PreguntasEvaluacion_PreguntasEvaluacionModelId_Pregunta",
                table: "PreguntasByEvaluacion");

            migrationBuilder.DropForeignKey(
                name: "FK_PreguntasByEvaluacion_Tipo_Evaluacion_TipoEvaluacionModelId_Tipo_Evaluacion",
                table: "PreguntasByEvaluacion");

            migrationBuilder.AlterColumn<int>(
                name: "TipoEvaluacionModelId_Tipo_Evaluacion",
                table: "PreguntasByEvaluacion",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PreguntasEvaluacionModelId_Pregunta",
                table: "PreguntasByEvaluacion",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ModuloEvaluacionModelId_Modulo_Evaluacion",
                table: "PreguntasByEvaluacion",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PreguntasByEvaluacion_ModuloEvaluacion_ModuloEvaluacionModelId_Modulo_Evaluacion",
                table: "PreguntasByEvaluacion",
                column: "ModuloEvaluacionModelId_Modulo_Evaluacion",
                principalTable: "ModuloEvaluacion",
                principalColumn: "Id_Modulo_Evaluacion");

            migrationBuilder.AddForeignKey(
                name: "FK_PreguntasByEvaluacion_PreguntasEvaluacion_PreguntasEvaluacionModelId_Pregunta",
                table: "PreguntasByEvaluacion",
                column: "PreguntasEvaluacionModelId_Pregunta",
                principalTable: "PreguntasEvaluacion",
                principalColumn: "Id_Pregunta");

            migrationBuilder.AddForeignKey(
                name: "FK_PreguntasByEvaluacion_Tipo_Evaluacion_TipoEvaluacionModelId_Tipo_Evaluacion",
                table: "PreguntasByEvaluacion",
                column: "TipoEvaluacionModelId_Tipo_Evaluacion",
                principalTable: "Tipo_Evaluacion",
                principalColumn: "Id_Tipo_Evaluacion");
        }
    }
}
