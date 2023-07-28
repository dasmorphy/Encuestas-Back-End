using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiprueba.Migrations
{
    /// <inheritdoc />
    public partial class OrderColumCalificacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Evaluacion_Id",
                table: "CalificacionByPreguntas",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta9",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 11);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta8",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 10);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta7",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 9);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta6",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 8);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta5",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 7);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta4",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 6);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta30",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 32);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta3",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 5);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta29",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 31);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta28",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 30);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta27",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 29);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta26",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 28);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta25",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 27);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta24",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 26);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta23",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 25);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta22",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 24);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta21",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 23);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta20",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 22);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta2",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta19",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 21);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta18",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 20);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta17",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 19);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta16",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 18);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta15",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 17);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta14",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 16);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta13",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 15);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta12",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 14);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta11",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 13);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta10",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 12);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta1",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<int>(
                name: "Id_Calificacion_Pregunta",
                table: "CalificacionByPreguntas",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 1)
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Evaluacion_Id",
                table: "CalificacionByPreguntas",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta9",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 11);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta8",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 10);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta7",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 9);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta6",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 8);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta5",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 7);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta4",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 6);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta30",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 32);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta3",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 5);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta29",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 31);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta28",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 30);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta27",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 29);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta26",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 28);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta25",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 27);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta24",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 26);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta23",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 25);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta22",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 24);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta21",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 23);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta20",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 22);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta2",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta19",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 21);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta18",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 20);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta17",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 19);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta16",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 18);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta15",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 17);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta14",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 16);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta13",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 15);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta12",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 14);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta11",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 13);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta10",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 12);

            migrationBuilder.AlterColumn<decimal>(
                name: "Clfc_Pregunta1",
                table: "CalificacionByPreguntas",
                type: "decimal(3,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<int>(
                name: "Id_Calificacion_Pregunta",
                table: "CalificacionByPreguntas",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("Relational:ColumnOrder", 1)
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }
    }
}
