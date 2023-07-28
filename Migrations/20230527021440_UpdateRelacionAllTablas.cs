using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiprueba.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelacionAllTablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Usuarios_Id_Colaborador",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Id_Colaborador",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Competencia",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "Definicion",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "Pregunta",
                table: "Evaluacion");

            migrationBuilder.RenameColumn(
                name: "Tipo_Evaluacion_Id",
                table: "Evaluacion",
                newName: "Usuarios_id");

            migrationBuilder.AddColumn<int>(
                name: "ColaboradorModelId_Colaborador",
                table: "Evaluacion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Colaborador_id",
                table: "Evaluacion",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Evaluacion_ColaboradorModelId_Colaborador",
                table: "Evaluacion",
                column: "ColaboradorModelId_Colaborador");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluacion_PreguntasByEvaluacionModelId_Preguntas_Tipo",
                table: "Evaluacion",
                column: "PreguntasByEvaluacionModelId_Preguntas_Tipo");

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

            migrationBuilder.DropIndex(
                name: "IX_Evaluacion_ColaboradorModelId_Colaborador",
                table: "Evaluacion");

            migrationBuilder.DropIndex(
                name: "IX_Evaluacion_PreguntasByEvaluacionModelId_Preguntas_Tipo",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "ColaboradorModelId_Colaborador",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "Colaborador_id",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "PreguntasByEvaluacionModelId_Preguntas_Tipo",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "Preguntas_Tipo_id",
                table: "Evaluacion");

            migrationBuilder.RenameColumn(
                name: "Usuarios_id",
                table: "Evaluacion",
                newName: "Tipo_Evaluacion_Id");

            migrationBuilder.AddColumn<int>(
                name: "Id_Colaborador",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Competencia",
                table: "Evaluacion",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Definicion",
                table: "Evaluacion",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Pregunta",
                table: "Evaluacion",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Id_Colaborador",
                table: "Usuarios",
                column: "Id_Colaborador",
                unique: true);
        }
    }
}
