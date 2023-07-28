using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiprueba.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEvaluacionModel : Migration
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
                name: "FK_Evaluacion_Usuarios_UsuariosModelId_Usuario",
                table: "Evaluacion");

            migrationBuilder.AlterColumn<int>(
                name: "UsuariosModelId_Usuario",
                table: "Evaluacion",
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

            migrationBuilder.AlterColumn<int>(
                name: "ColaboradorModelId_Colaborador",
                table: "Evaluacion",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<int>(
                name: "UsuariosModelId_Usuario",
                table: "Evaluacion",
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

            migrationBuilder.AlterColumn<int>(
                name: "ColaboradorModelId_Colaborador",
                table: "Evaluacion",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluacion_Colaborador_ColaboradorModelId_Colaborador",
                table: "Evaluacion",
                column: "ColaboradorModelId_Colaborador",
                principalTable: "Colaborador",
                principalColumn: "Id_Colaborador");

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluacion_PreguntasByEvaluacion_PreguntasByEvaluacionModelId_Preguntas_Tipo",
                table: "Evaluacion",
                column: "PreguntasByEvaluacionModelId_Preguntas_Tipo",
                principalTable: "PreguntasByEvaluacion",
                principalColumn: "Id_Preguntas_Tipo");

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluacion_Usuarios_UsuariosModelId_Usuario",
                table: "Evaluacion",
                column: "UsuariosModelId_Usuario",
                principalTable: "Usuarios",
                principalColumn: "Id_Usuario");
        }
    }
}
