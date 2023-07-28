using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiprueba.Migrations
{
    /// <inheritdoc />
    public partial class DropCalificacionModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalificacionByPreguntas");

            migrationBuilder.AlterColumn<int>(
                name: "Usuario_id",
                table: "Evaluacion",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<int>(
                name: "Preguntas_Tipo_id",
                table: "Evaluacion",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<int>(
                name: "Colaborador_id",
                table: "Evaluacion",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "CalificacionFinal",
                table: "Evaluacion",
                type: "decimal(4,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)")
                .Annotation("Relational:ColumnOrder", 5);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta1",
                table: "Evaluacion",
                type: "decimal(4,2)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 6);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta10",
                table: "Evaluacion",
                type: "decimal(4,2)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 15);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta11",
                table: "Evaluacion",
                type: "decimal(4,2)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 16);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta12",
                table: "Evaluacion",
                type: "decimal(4,2)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 17);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta13",
                table: "Evaluacion",
                type: "decimal(4,2)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 18);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta14",
                table: "Evaluacion",
                type: "decimal(4,2)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 19);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta15",
                table: "Evaluacion",
                type: "decimal(4,2)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 20);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta16",
                table: "Evaluacion",
                type: "decimal(4,2)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 21);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta17",
                table: "Evaluacion",
                type: "decimal(4,2)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 22);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta18",
                table: "Evaluacion",
                type: "decimal(4,2)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 23);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta19",
                table: "Evaluacion",
                type: "decimal(4,2)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 24);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta2",
                table: "Evaluacion",
                type: "decimal(4,2)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 7);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta20",
                table: "Evaluacion",
                type: "decimal(4,2)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 25);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta21",
                table: "Evaluacion",
                type: "decimal(4,2)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 26);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta22",
                table: "Evaluacion",
                type: "decimal(4,2)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 27);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta23",
                table: "Evaluacion",
                type: "decimal(4,2)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 28);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta24",
                table: "Evaluacion",
                type: "decimal(4,2)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 29);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta25",
                table: "Evaluacion",
                type: "decimal(4,2)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 30);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta26",
                table: "Evaluacion",
                type: "decimal(4,2)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 31);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta27",
                table: "Evaluacion",
                type: "decimal(4,2)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 32);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta28",
                table: "Evaluacion",
                type: "decimal(4,2)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 33);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta29",
                table: "Evaluacion",
                type: "decimal(4,2)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 34);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta3",
                table: "Evaluacion",
                type: "decimal(4,2)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 8);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta30",
                table: "Evaluacion",
                type: "decimal(4,2)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 35);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta4",
                table: "Evaluacion",
                type: "decimal(4,2)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 9);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta5",
                table: "Evaluacion",
                type: "decimal(4,2)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 10);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta6",
                table: "Evaluacion",
                type: "decimal(4,2)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 11);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta7",
                table: "Evaluacion",
                type: "decimal(4,2)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 12);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta8",
                table: "Evaluacion",
                type: "decimal(4,2)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 13);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta9",
                table: "Evaluacion",
                type: "decimal(4,2)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 14);

            migrationBuilder.AddColumn<int>(
                name: "ColaboradorModelId_Colaborador",
                table: "Evaluacion",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Evaluacion_ColaboradorModelId_Colaborador",
                table: "Evaluacion",
                column: "ColaboradorModelId_Colaborador");

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluacion_Colaborador_ColaboradorModelId_Colaborador",
                table: "Evaluacion",
                column: "ColaboradorModelId_Colaborador",
                principalTable: "Colaborador",
                principalColumn: "Id_Colaborador");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluacion_Colaborador_ColaboradorModelId_Colaborador",
                table: "Evaluacion");

            migrationBuilder.DropIndex(
                name: "IX_Evaluacion_ColaboradorModelId_Colaborador",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta1",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta10",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta11",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta12",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta13",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta14",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta15",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta16",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta17",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta18",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta19",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta2",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta20",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta21",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta22",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta23",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta24",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta25",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta26",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta27",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta28",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta29",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta3",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta30",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta4",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta5",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta6",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta7",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta8",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta9",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "ColaboradorModelId_Colaborador",
                table: "Evaluacion");

            migrationBuilder.AlterColumn<int>(
                name: "Usuario_id",
                table: "Evaluacion",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<int>(
                name: "Preguntas_Tipo_id",
                table: "Evaluacion",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<int>(
                name: "Colaborador_id",
                table: "Evaluacion",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "CalificacionFinal",
                table: "Evaluacion",
                type: "decimal(3,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(4,2)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 5);

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
    }
}
