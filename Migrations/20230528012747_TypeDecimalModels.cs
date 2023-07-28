using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiprueba.Migrations
{
    /// <inheritdoc />
    public partial class TypeDecimalModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pregunta1",
                table: "CalificacionByPreguntas");

            migrationBuilder.DropColumn(
                name: "Pregunta10",
                table: "CalificacionByPreguntas");

            migrationBuilder.DropColumn(
                name: "Pregunta11",
                table: "CalificacionByPreguntas");

            migrationBuilder.DropColumn(
                name: "Pregunta12",
                table: "CalificacionByPreguntas");

            migrationBuilder.DropColumn(
                name: "Pregunta13",
                table: "CalificacionByPreguntas");

            migrationBuilder.DropColumn(
                name: "Pregunta14",
                table: "CalificacionByPreguntas");

            migrationBuilder.DropColumn(
                name: "Pregunta15",
                table: "CalificacionByPreguntas");

            migrationBuilder.DropColumn(
                name: "Pregunta16",
                table: "CalificacionByPreguntas");

            migrationBuilder.DropColumn(
                name: "Pregunta17",
                table: "CalificacionByPreguntas");

            migrationBuilder.DropColumn(
                name: "Pregunta18",
                table: "CalificacionByPreguntas");

            migrationBuilder.DropColumn(
                name: "Pregunta19",
                table: "CalificacionByPreguntas");

            migrationBuilder.DropColumn(
                name: "Pregunta2",
                table: "CalificacionByPreguntas");

            migrationBuilder.DropColumn(
                name: "Pregunta20",
                table: "CalificacionByPreguntas");

            migrationBuilder.DropColumn(
                name: "Pregunta21",
                table: "CalificacionByPreguntas");

            migrationBuilder.DropColumn(
                name: "Pregunta22",
                table: "CalificacionByPreguntas");

            migrationBuilder.DropColumn(
                name: "Pregunta23",
                table: "CalificacionByPreguntas");

            migrationBuilder.DropColumn(
                name: "Pregunta24",
                table: "CalificacionByPreguntas");

            migrationBuilder.DropColumn(
                name: "Pregunta25",
                table: "CalificacionByPreguntas");

            migrationBuilder.DropColumn(
                name: "Pregunta26",
                table: "CalificacionByPreguntas");

            migrationBuilder.DropColumn(
                name: "Pregunta27",
                table: "CalificacionByPreguntas");

            migrationBuilder.DropColumn(
                name: "Pregunta28",
                table: "CalificacionByPreguntas");

            migrationBuilder.DropColumn(
                name: "Pregunta29",
                table: "CalificacionByPreguntas");

            migrationBuilder.DropColumn(
                name: "Pregunta3",
                table: "CalificacionByPreguntas");

            migrationBuilder.DropColumn(
                name: "Pregunta30",
                table: "CalificacionByPreguntas");

            migrationBuilder.DropColumn(
                name: "Pregunta4",
                table: "CalificacionByPreguntas");

            migrationBuilder.DropColumn(
                name: "Pregunta5",
                table: "CalificacionByPreguntas");

            migrationBuilder.DropColumn(
                name: "Pregunta6",
                table: "CalificacionByPreguntas");

            migrationBuilder.DropColumn(
                name: "Pregunta7",
                table: "CalificacionByPreguntas");

            migrationBuilder.DropColumn(
                name: "Pregunta8",
                table: "CalificacionByPreguntas");

            migrationBuilder.DropColumn(
                name: "Pregunta9",
                table: "CalificacionByPreguntas");

            migrationBuilder.AddColumn<decimal>(
                name: "CalificacionFinal",
                table: "Evaluacion",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta1",
                table: "CalificacionByPreguntas",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta10",
                table: "CalificacionByPreguntas",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta11",
                table: "CalificacionByPreguntas",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta12",
                table: "CalificacionByPreguntas",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta13",
                table: "CalificacionByPreguntas",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta14",
                table: "CalificacionByPreguntas",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta15",
                table: "CalificacionByPreguntas",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta16",
                table: "CalificacionByPreguntas",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta17",
                table: "CalificacionByPreguntas",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta18",
                table: "CalificacionByPreguntas",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta19",
                table: "CalificacionByPreguntas",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta2",
                table: "CalificacionByPreguntas",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta20",
                table: "CalificacionByPreguntas",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta21",
                table: "CalificacionByPreguntas",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta22",
                table: "CalificacionByPreguntas",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta23",
                table: "CalificacionByPreguntas",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta24",
                table: "CalificacionByPreguntas",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta25",
                table: "CalificacionByPreguntas",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta26",
                table: "CalificacionByPreguntas",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta27",
                table: "CalificacionByPreguntas",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta28",
                table: "CalificacionByPreguntas",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta29",
                table: "CalificacionByPreguntas",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta3",
                table: "CalificacionByPreguntas",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta30",
                table: "CalificacionByPreguntas",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta4",
                table: "CalificacionByPreguntas",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta5",
                table: "CalificacionByPreguntas",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta6",
                table: "CalificacionByPreguntas",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta7",
                table: "CalificacionByPreguntas",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta8",
                table: "CalificacionByPreguntas",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta9",
                table: "CalificacionByPreguntas",
                type: "decimal(18,2)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CalificacionFinal",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta1",
                table: "CalificacionByPreguntas");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta10",
                table: "CalificacionByPreguntas");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta11",
                table: "CalificacionByPreguntas");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta12",
                table: "CalificacionByPreguntas");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta13",
                table: "CalificacionByPreguntas");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta14",
                table: "CalificacionByPreguntas");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta15",
                table: "CalificacionByPreguntas");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta16",
                table: "CalificacionByPreguntas");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta17",
                table: "CalificacionByPreguntas");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta18",
                table: "CalificacionByPreguntas");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta19",
                table: "CalificacionByPreguntas");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta2",
                table: "CalificacionByPreguntas");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta20",
                table: "CalificacionByPreguntas");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta21",
                table: "CalificacionByPreguntas");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta22",
                table: "CalificacionByPreguntas");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta23",
                table: "CalificacionByPreguntas");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta24",
                table: "CalificacionByPreguntas");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta25",
                table: "CalificacionByPreguntas");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta26",
                table: "CalificacionByPreguntas");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta27",
                table: "CalificacionByPreguntas");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta28",
                table: "CalificacionByPreguntas");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta29",
                table: "CalificacionByPreguntas");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta3",
                table: "CalificacionByPreguntas");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta30",
                table: "CalificacionByPreguntas");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta4",
                table: "CalificacionByPreguntas");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta5",
                table: "CalificacionByPreguntas");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta6",
                table: "CalificacionByPreguntas");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta7",
                table: "CalificacionByPreguntas");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta8",
                table: "CalificacionByPreguntas");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta9",
                table: "CalificacionByPreguntas");

            migrationBuilder.AddColumn<int>(
                name: "Pregunta1",
                table: "CalificacionByPreguntas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Pregunta10",
                table: "CalificacionByPreguntas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Pregunta11",
                table: "CalificacionByPreguntas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Pregunta12",
                table: "CalificacionByPreguntas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Pregunta13",
                table: "CalificacionByPreguntas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Pregunta14",
                table: "CalificacionByPreguntas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Pregunta15",
                table: "CalificacionByPreguntas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Pregunta16",
                table: "CalificacionByPreguntas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Pregunta17",
                table: "CalificacionByPreguntas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Pregunta18",
                table: "CalificacionByPreguntas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Pregunta19",
                table: "CalificacionByPreguntas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Pregunta2",
                table: "CalificacionByPreguntas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Pregunta20",
                table: "CalificacionByPreguntas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Pregunta21",
                table: "CalificacionByPreguntas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Pregunta22",
                table: "CalificacionByPreguntas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Pregunta23",
                table: "CalificacionByPreguntas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Pregunta24",
                table: "CalificacionByPreguntas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Pregunta25",
                table: "CalificacionByPreguntas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Pregunta26",
                table: "CalificacionByPreguntas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Pregunta27",
                table: "CalificacionByPreguntas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Pregunta28",
                table: "CalificacionByPreguntas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Pregunta29",
                table: "CalificacionByPreguntas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Pregunta3",
                table: "CalificacionByPreguntas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Pregunta30",
                table: "CalificacionByPreguntas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Pregunta4",
                table: "CalificacionByPreguntas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Pregunta5",
                table: "CalificacionByPreguntas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Pregunta6",
                table: "CalificacionByPreguntas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Pregunta7",
                table: "CalificacionByPreguntas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Pregunta8",
                table: "CalificacionByPreguntas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Pregunta9",
                table: "CalificacionByPreguntas",
                type: "int",
                nullable: true);
        }
    }
}
