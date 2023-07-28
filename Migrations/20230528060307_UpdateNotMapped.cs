using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiprueba.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNotMapped : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluacion_Colaborador_ColaboradorModelId_Colaborador",
                table: "Evaluacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Evaluacion_PreguntasByEvaluacion_PreguntasByEvaluacionModelId_Preguntas_Tipo",
                table: "Evaluacion");

            migrationBuilder.DropForeignKey(
                name: "FK_PreguntasByEvaluacion_ModuloEvaluacion_ModuloEvaluacionModelId_Modulo_Evaluacion",
                table: "PreguntasByEvaluacion");

            migrationBuilder.DropForeignKey(
                name: "FK_PreguntasByEvaluacion_Tipo_Evaluacion_TipoEvaluacionModelId_Tipo_Evaluacion",
                table: "PreguntasByEvaluacion");

            migrationBuilder.DropIndex(
                name: "IX_Evaluacion_ColaboradorModelId_Colaborador",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "ColaboradorModelId_Colaborador",
                table: "Evaluacion");

            migrationBuilder.AlterColumn<int>(
                name: "TipoEvaluacionModelId_Tipo_Evaluacion",
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

            migrationBuilder.AddForeignKey(
                name: "FK_PreguntasByEvaluacion_ModuloEvaluacion_ModuloEvaluacionModelId_Modulo_Evaluacion",
                table: "PreguntasByEvaluacion",
                column: "ModuloEvaluacionModelId_Modulo_Evaluacion",
                principalTable: "ModuloEvaluacion",
                principalColumn: "Id_Modulo_Evaluacion");

            migrationBuilder.AddForeignKey(
                name: "FK_PreguntasByEvaluacion_Tipo_Evaluacion_TipoEvaluacionModelId_Tipo_Evaluacion",
                table: "PreguntasByEvaluacion",
                column: "TipoEvaluacionModelId_Tipo_Evaluacion",
                principalTable: "Tipo_Evaluacion",
                principalColumn: "Id_Tipo_Evaluacion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "ModuloEvaluacionModelId_Modulo_Evaluacion",
                table: "PreguntasByEvaluacion",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Evaluacion_ColaboradorModelId_Colaborador",
                table: "Evaluacion",
                column: "ColaboradorModelId_Colaborador");

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
