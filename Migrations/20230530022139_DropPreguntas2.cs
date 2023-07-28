using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiprueba.Migrations
{
    /// <inheritdoc />
    public partial class DropPreguntas2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluacion_PreguntasByEvaluacionModel_PreguntasByEvaluacionModelId_Preguntas_Tipo",
                table: "Evaluacion");

            migrationBuilder.DropTable(
                name: "PreguntasByEvaluacionModel");

            migrationBuilder.DropIndex(
                name: "IX_Evaluacion_PreguntasByEvaluacionModelId_Preguntas_Tipo",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "PreguntasByEvaluacionModelId_Preguntas_Tipo",
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

            migrationBuilder.CreateTable(
                name: "PreguntasByEvaluacionModel",
                columns: table => new
                {
                    Pregunta_Id = table.Column<int>(type: "int", nullable: false),
                    Tipo_Evaluacion_Id = table.Column<int>(type: "int", nullable: false),
                    Modulo_Id = table.Column<int>(type: "int", nullable: false),
                    Pregunta1 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Pregunta2 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Pregunta3 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Pregunta4 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Pregunta5 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Pregunta6 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Pregunta7 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Pregunta8 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Pregunta9 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Pregunta10 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Pregunta11 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Pregunta12 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Pregunta13 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Pregunta14 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Pregunta15 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Pregunta16 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Pregunta17 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Pregunta18 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Pregunta19 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Pregunta20 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Pregunta21 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Pregunta22 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Pregunta23 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Pregunta24 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Pregunta25 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Pregunta26 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Pregunta27 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Pregunta28 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Pregunta29 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Pregunta30 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Id_Preguntas_Tipo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuloEvaluacionModelId_Modulo_Evaluacion = table.Column<int>(type: "int", nullable: false),
                    TipoEvaluacionModelId_Tipo_Evaluacion = table.Column<int>(type: "int", nullable: false),
                    Fecha_Creacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreguntasByEvaluacionModel", x => x.Id_Preguntas_Tipo);
                    table.ForeignKey(
                        name: "FK_PreguntasByEvaluacionModel_ModuloEvaluacion_ModuloEvaluacionModelId_Modulo_Evaluacion",
                        column: x => x.ModuloEvaluacionModelId_Modulo_Evaluacion,
                        principalTable: "ModuloEvaluacion",
                        principalColumn: "Id_Modulo_Evaluacion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PreguntasByEvaluacionModel_Tipo_Evaluacion_TipoEvaluacionModelId_Tipo_Evaluacion",
                        column: x => x.TipoEvaluacionModelId_Tipo_Evaluacion,
                        principalTable: "Tipo_Evaluacion",
                        principalColumn: "Id_Tipo_Evaluacion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Evaluacion_PreguntasByEvaluacionModelId_Preguntas_Tipo",
                table: "Evaluacion",
                column: "PreguntasByEvaluacionModelId_Preguntas_Tipo");

            migrationBuilder.CreateIndex(
                name: "IX_PreguntasByEvaluacionModel_ModuloEvaluacionModelId_Modulo_Evaluacion",
                table: "PreguntasByEvaluacionModel",
                column: "ModuloEvaluacionModelId_Modulo_Evaluacion");

            migrationBuilder.CreateIndex(
                name: "IX_PreguntasByEvaluacionModel_TipoEvaluacionModelId_Tipo_Evaluacion",
                table: "PreguntasByEvaluacionModel",
                column: "TipoEvaluacionModelId_Tipo_Evaluacion");

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluacion_PreguntasByEvaluacionModel_PreguntasByEvaluacionModelId_Preguntas_Tipo",
                table: "Evaluacion",
                column: "PreguntasByEvaluacionModelId_Preguntas_Tipo",
                principalTable: "PreguntasByEvaluacionModel",
                principalColumn: "Id_Preguntas_Tipo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
