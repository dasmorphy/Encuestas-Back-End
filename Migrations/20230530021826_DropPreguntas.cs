using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiprueba.Migrations
{
    /// <inheritdoc />
    public partial class DropPreguntas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluacion_PreguntasByEvaluacion_PreguntasByEvaluacionModelId_Preguntas_Tipo",
                table: "Evaluacion");

            migrationBuilder.DropForeignKey(
                name: "FK_PreguntasByEvaluacion_ModuloEvaluacion_ModuloEvaluacionModelId_Modulo_Evaluacion",
                table: "PreguntasByEvaluacion");

            migrationBuilder.DropForeignKey(
                name: "FK_PreguntasByEvaluacion_Tipo_Evaluacion_TipoEvaluacionModelId_Tipo_Evaluacion",
                table: "PreguntasByEvaluacion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PreguntasByEvaluacion",
                table: "PreguntasByEvaluacion");

            migrationBuilder.RenameTable(
                name: "PreguntasByEvaluacion",
                newName: "PreguntasByEvaluacionModel");

            migrationBuilder.RenameIndex(
                name: "IX_PreguntasByEvaluacion_TipoEvaluacionModelId_Tipo_Evaluacion",
                table: "PreguntasByEvaluacionModel",
                newName: "IX_PreguntasByEvaluacionModel_TipoEvaluacionModelId_Tipo_Evaluacion");

            migrationBuilder.RenameIndex(
                name: "IX_PreguntasByEvaluacion_ModuloEvaluacionModelId_Modulo_Evaluacion",
                table: "PreguntasByEvaluacionModel",
                newName: "IX_PreguntasByEvaluacionModel_ModuloEvaluacionModelId_Modulo_Evaluacion");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PreguntasByEvaluacionModel",
                table: "PreguntasByEvaluacionModel",
                column: "Id_Preguntas_Tipo");

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluacion_PreguntasByEvaluacionModel_PreguntasByEvaluacionModelId_Preguntas_Tipo",
                table: "Evaluacion",
                column: "PreguntasByEvaluacionModelId_Preguntas_Tipo",
                principalTable: "PreguntasByEvaluacionModel",
                principalColumn: "Id_Preguntas_Tipo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PreguntasByEvaluacionModel_ModuloEvaluacion_ModuloEvaluacionModelId_Modulo_Evaluacion",
                table: "PreguntasByEvaluacionModel",
                column: "ModuloEvaluacionModelId_Modulo_Evaluacion",
                principalTable: "ModuloEvaluacion",
                principalColumn: "Id_Modulo_Evaluacion",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PreguntasByEvaluacionModel_Tipo_Evaluacion_TipoEvaluacionModelId_Tipo_Evaluacion",
                table: "PreguntasByEvaluacionModel",
                column: "TipoEvaluacionModelId_Tipo_Evaluacion",
                principalTable: "Tipo_Evaluacion",
                principalColumn: "Id_Tipo_Evaluacion",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluacion_PreguntasByEvaluacionModel_PreguntasByEvaluacionModelId_Preguntas_Tipo",
                table: "Evaluacion");

            migrationBuilder.DropForeignKey(
                name: "FK_PreguntasByEvaluacionModel_ModuloEvaluacion_ModuloEvaluacionModelId_Modulo_Evaluacion",
                table: "PreguntasByEvaluacionModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PreguntasByEvaluacionModel_Tipo_Evaluacion_TipoEvaluacionModelId_Tipo_Evaluacion",
                table: "PreguntasByEvaluacionModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PreguntasByEvaluacionModel",
                table: "PreguntasByEvaluacionModel");

            migrationBuilder.RenameTable(
                name: "PreguntasByEvaluacionModel",
                newName: "PreguntasByEvaluacion");

            migrationBuilder.RenameIndex(
                name: "IX_PreguntasByEvaluacionModel_TipoEvaluacionModelId_Tipo_Evaluacion",
                table: "PreguntasByEvaluacion",
                newName: "IX_PreguntasByEvaluacion_TipoEvaluacionModelId_Tipo_Evaluacion");

            migrationBuilder.RenameIndex(
                name: "IX_PreguntasByEvaluacionModel_ModuloEvaluacionModelId_Modulo_Evaluacion",
                table: "PreguntasByEvaluacion",
                newName: "IX_PreguntasByEvaluacion_ModuloEvaluacionModelId_Modulo_Evaluacion");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PreguntasByEvaluacion",
                table: "PreguntasByEvaluacion",
                column: "Id_Preguntas_Tipo");

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluacion_PreguntasByEvaluacion_PreguntasByEvaluacionModelId_Preguntas_Tipo",
                table: "Evaluacion",
                column: "PreguntasByEvaluacionModelId_Preguntas_Tipo",
                principalTable: "PreguntasByEvaluacion",
                principalColumn: "Id_Preguntas_Tipo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PreguntasByEvaluacion_ModuloEvaluacion_ModuloEvaluacionModelId_Modulo_Evaluacion",
                table: "PreguntasByEvaluacion",
                column: "ModuloEvaluacionModelId_Modulo_Evaluacion",
                principalTable: "ModuloEvaluacion",
                principalColumn: "Id_Modulo_Evaluacion",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PreguntasByEvaluacion_Tipo_Evaluacion_TipoEvaluacionModelId_Tipo_Evaluacion",
                table: "PreguntasByEvaluacion",
                column: "TipoEvaluacionModelId_Tipo_Evaluacion",
                principalTable: "Tipo_Evaluacion",
                principalColumn: "Id_Tipo_Evaluacion",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
