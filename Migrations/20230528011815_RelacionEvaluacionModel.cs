using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiprueba.Migrations
{
    /// <inheritdoc />
    public partial class RelacionEvaluacionModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CalificacionByPreguntas",
                columns: table => new
                {
                    Id_Calificacion_Pregunta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Evaluacion_Id = table.Column<int>(type: "int", nullable: false),
                    Pregunta1 = table.Column<int>(type: "int", nullable: true),
                    Pregunta2 = table.Column<int>(type: "int", nullable: true),
                    Pregunta3 = table.Column<int>(type: "int", nullable: true),
                    Pregunta4 = table.Column<int>(type: "int", nullable: true),
                    Pregunta5 = table.Column<int>(type: "int", nullable: true),
                    Pregunta6 = table.Column<int>(type: "int", nullable: true),
                    Pregunta7 = table.Column<int>(type: "int", nullable: true),
                    Pregunta8 = table.Column<int>(type: "int", nullable: true),
                    Pregunta9 = table.Column<int>(type: "int", nullable: true),
                    Pregunta10 = table.Column<int>(type: "int", nullable: true),
                    Pregunta11 = table.Column<int>(type: "int", nullable: true),
                    Pregunta12 = table.Column<int>(type: "int", nullable: true),
                    Pregunta13 = table.Column<int>(type: "int", nullable: true),
                    Pregunta14 = table.Column<int>(type: "int", nullable: true),
                    Pregunta15 = table.Column<int>(type: "int", nullable: true),
                    Pregunta16 = table.Column<int>(type: "int", nullable: true),
                    Pregunta17 = table.Column<int>(type: "int", nullable: true),
                    Pregunta18 = table.Column<int>(type: "int", nullable: true),
                    Pregunta19 = table.Column<int>(type: "int", nullable: true),
                    Pregunta20 = table.Column<int>(type: "int", nullable: true),
                    Pregunta21 = table.Column<int>(type: "int", nullable: true),
                    Pregunta22 = table.Column<int>(type: "int", nullable: true),
                    Pregunta23 = table.Column<int>(type: "int", nullable: true),
                    Pregunta24 = table.Column<int>(type: "int", nullable: true),
                    Pregunta25 = table.Column<int>(type: "int", nullable: true),
                    Pregunta26 = table.Column<int>(type: "int", nullable: true),
                    Pregunta27 = table.Column<int>(type: "int", nullable: true),
                    Pregunta28 = table.Column<int>(type: "int", nullable: true),
                    Pregunta29 = table.Column<int>(type: "int", nullable: true),
                    Pregunta30 = table.Column<int>(type: "int", nullable: true),
                    EvaluacionModelId_Evaluacion = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalificacionByPreguntas", x => x.Id_Calificacion_Pregunta);
                    table.ForeignKey(
                        name: "FK_CalificacionByPreguntas_Evaluacion_EvaluacionModelId_Evaluacion",
                        column: x => x.EvaluacionModelId_Evaluacion,
                        principalTable: "Evaluacion",
                        principalColumn: "Id_Evaluacion");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CalificacionByPreguntas_EvaluacionModelId_Evaluacion",
                table: "CalificacionByPreguntas",
                column: "EvaluacionModelId_Evaluacion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalificacionByPreguntas");
        }
    }
}
