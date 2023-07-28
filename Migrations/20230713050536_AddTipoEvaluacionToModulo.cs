using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiprueba.Migrations
{
    /// <inheritdoc />
    public partial class AddTipoEvaluacionToModulo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PreguntasByEvaluacion_Tipo_Evaluacion_TipoEvaluacionModelId_Tipo_Evaluacion",
                table: "PreguntasByEvaluacion");

            migrationBuilder.DropIndex(
                name: "IX_PreguntasByEvaluacion_TipoEvaluacionModelId_Tipo_Evaluacion",
                table: "PreguntasByEvaluacion");

            migrationBuilder.DropColumn(
                name: "TipoEvaluacionModelId_Tipo_Evaluacion",
                table: "PreguntasByEvaluacion");

            migrationBuilder.AddColumn<int>(
                name: "TipoEvaluacionModelId_Tipo_Evaluacion",
                table: "ModuloEvaluacion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Tipo_Evaluacion_Id",
                table: "ModuloEvaluacion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ModuloEvaluacion_TipoEvaluacionModelId_Tipo_Evaluacion",
                table: "ModuloEvaluacion",
                column: "TipoEvaluacionModelId_Tipo_Evaluacion");

            migrationBuilder.AddForeignKey(
                name: "FK_ModuloEvaluacion_Tipo_Evaluacion_TipoEvaluacionModelId_Tipo_Evaluacion",
                table: "ModuloEvaluacion",
                column: "TipoEvaluacionModelId_Tipo_Evaluacion",
                principalTable: "Tipo_Evaluacion",
                principalColumn: "Id_Tipo_Evaluacion",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModuloEvaluacion_Tipo_Evaluacion_TipoEvaluacionModelId_Tipo_Evaluacion",
                table: "ModuloEvaluacion");

            migrationBuilder.DropIndex(
                name: "IX_ModuloEvaluacion_TipoEvaluacionModelId_Tipo_Evaluacion",
                table: "ModuloEvaluacion");

            migrationBuilder.DropColumn(
                name: "TipoEvaluacionModelId_Tipo_Evaluacion",
                table: "ModuloEvaluacion");

            migrationBuilder.DropColumn(
                name: "Tipo_Evaluacion_Id",
                table: "ModuloEvaluacion");

            migrationBuilder.AddColumn<int>(
                name: "TipoEvaluacionModelId_Tipo_Evaluacion",
                table: "PreguntasByEvaluacion",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PreguntasByEvaluacion_TipoEvaluacionModelId_Tipo_Evaluacion",
                table: "PreguntasByEvaluacion",
                column: "TipoEvaluacionModelId_Tipo_Evaluacion");

            migrationBuilder.AddForeignKey(
                name: "FK_PreguntasByEvaluacion_Tipo_Evaluacion_TipoEvaluacionModelId_Tipo_Evaluacion",
                table: "PreguntasByEvaluacion",
                column: "TipoEvaluacionModelId_Tipo_Evaluacion",
                principalTable: "Tipo_Evaluacion",
                principalColumn: "Id_Tipo_Evaluacion");
        }
    }
}
