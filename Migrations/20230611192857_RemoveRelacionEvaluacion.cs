using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiprueba.Migrations
{
    /// <inheritdoc />
    public partial class RemoveRelacionEvaluacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluacion_PreguntasByEvaluacion_PreguntasByEvaluacionModelId_Preguntas_Tipo",
                table: "Evaluacion");

            migrationBuilder.DropIndex(
                name: "IX_Evaluacion_PreguntasByEvaluacionModelId_Preguntas_Tipo",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "PreguntasByEvaluacionModelId_Preguntas_Tipo",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "Preguntas_Tipo_id",
                table: "Evaluacion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PreguntasByEvaluacionModelId_Preguntas_Tipo",
                table: "Evaluacion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Preguntas_Tipo_id",
                table: "Evaluacion",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("Relational:ColumnOrder", 4);

            migrationBuilder.CreateIndex(
                name: "IX_Evaluacion_PreguntasByEvaluacionModelId_Preguntas_Tipo",
                table: "Evaluacion",
                column: "PreguntasByEvaluacionModelId_Preguntas_Tipo");

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluacion_PreguntasByEvaluacion_PreguntasByEvaluacionModelId_Preguntas_Tipo",
                table: "Evaluacion",
                column: "PreguntasByEvaluacionModelId_Preguntas_Tipo",
                principalTable: "PreguntasByEvaluacion",
                principalColumn: "Id_Preguntas_Tipo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
