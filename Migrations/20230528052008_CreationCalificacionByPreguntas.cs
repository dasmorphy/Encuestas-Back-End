using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiprueba.Migrations
{
    /// <inheritdoc />
    public partial class CreationCalificacionByPreguntas : Migration
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
                    Clfc_Pregunta1 = table.Column<decimal>(type: "decimal(3,2)", nullable: true),
                    Clfc_Pregunta2 = table.Column<decimal>(type: "decimal(3,2)", nullable: true),
                    Clfc_Pregunta3 = table.Column<decimal>(type: "decimal(3,2)", nullable: true),
                    Clfc_Pregunta4 = table.Column<decimal>(type: "decimal(3,2)", nullable: true),
                    Clfc_Pregunta5 = table.Column<decimal>(type: "decimal(3,2)", nullable: true),
                    Clfc_Pregunta6 = table.Column<decimal>(type: "decimal(3,2)", nullable: true),
                    Clfc_Pregunta7 = table.Column<decimal>(type: "decimal(3,2)", nullable: true),
                    Clfc_Pregunta8 = table.Column<decimal>(type: "decimal(3,2)", nullable: true),
                    Clfc_Pregunta9 = table.Column<decimal>(type: "decimal(3,2)", nullable: true),
                    Clfc_Pregunta10 = table.Column<decimal>(type: "decimal(3,2)", nullable: true),
                    Clfc_Pregunta11 = table.Column<decimal>(type: "decimal(3,2)", nullable: true),
                    Clfc_Pregunta12 = table.Column<decimal>(type: "decimal(3,2)", nullable: true),
                    Clfc_Pregunta13 = table.Column<decimal>(type: "decimal(3,2)", nullable: true),
                    Clfc_Pregunta14 = table.Column<decimal>(type: "decimal(3,2)", nullable: true),
                    Clfc_Pregunta15 = table.Column<decimal>(type: "decimal(3,2)", nullable: true),
                    Clfc_Pregunta16 = table.Column<decimal>(type: "decimal(3,2)", nullable: true),
                    Clfc_Pregunta17 = table.Column<decimal>(type: "decimal(3,2)", nullable: true),
                    Clfc_Pregunta18 = table.Column<decimal>(type: "decimal(3,2)", nullable: true),
                    Clfc_Pregunta19 = table.Column<decimal>(type: "decimal(3,2)", nullable: true),
                    Clfc_Pregunta20 = table.Column<decimal>(type: "decimal(3,2)", nullable: true),
                    Clfc_Pregunta21 = table.Column<decimal>(type: "decimal(3,2)", nullable: true),
                    Clfc_Pregunta22 = table.Column<decimal>(type: "decimal(3,2)", nullable: true),
                    Clfc_Pregunta23 = table.Column<decimal>(type: "decimal(3,2)", nullable: true),
                    Clfc_Pregunta24 = table.Column<decimal>(type: "decimal(3,2)", nullable: true),
                    Clfc_Pregunta25 = table.Column<decimal>(type: "decimal(3,2)", nullable: true),
                    Clfc_Pregunta26 = table.Column<decimal>(type: "decimal(3,2)", nullable: true),
                    Clfc_Pregunta27 = table.Column<decimal>(type: "decimal(3,2)", nullable: true),
                    Clfc_Pregunta28 = table.Column<decimal>(type: "decimal(3,2)", nullable: true),
                    Clfc_Pregunta29 = table.Column<decimal>(type: "decimal(3,2)", nullable: true),
                    Clfc_Pregunta30 = table.Column<decimal>(type: "decimal(3,2)", nullable: true),
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
