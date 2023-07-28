using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiprueba.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePreguntas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PreguntasByEvaluacion_PreguntasEvaluacion_PreguntasEvaluacionModelId_Pregunta",
                table: "PreguntasByEvaluacion");

            migrationBuilder.DropTable(
                name: "PreguntasEvaluacion");

            migrationBuilder.DropIndex(
                name: "IX_PreguntasByEvaluacion_PreguntasEvaluacionModelId_Pregunta",
                table: "PreguntasByEvaluacion");

            migrationBuilder.DropColumn(
                name: "PreguntasEvaluacionModelId_Pregunta",
                table: "PreguntasByEvaluacion");

            migrationBuilder.AlterColumn<int>(
                name: "Tipo_Evaluacion_Id",
                table: "PreguntasByEvaluacion",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<int>(
                name: "Pregunta_Id",
                table: "PreguntasByEvaluacion",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<int>(
                name: "Modulo_Id",
                table: "PreguntasByEvaluacion",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 4);

            migrationBuilder.AddColumn<string>(
                name: "Pregunta1",
                table: "PreguntasByEvaluacion",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 5);

            migrationBuilder.AddColumn<string>(
                name: "Pregunta10",
                table: "PreguntasByEvaluacion",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true)
                .Annotation("Relational:ColumnOrder", 14);

            migrationBuilder.AddColumn<string>(
                name: "Pregunta11",
                table: "PreguntasByEvaluacion",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true)
                .Annotation("Relational:ColumnOrder", 15);

            migrationBuilder.AddColumn<string>(
                name: "Pregunta12",
                table: "PreguntasByEvaluacion",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true)
                .Annotation("Relational:ColumnOrder", 16);

            migrationBuilder.AddColumn<string>(
                name: "Pregunta13",
                table: "PreguntasByEvaluacion",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true)
                .Annotation("Relational:ColumnOrder", 17);

            migrationBuilder.AddColumn<string>(
                name: "Pregunta14",
                table: "PreguntasByEvaluacion",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true)
                .Annotation("Relational:ColumnOrder", 18);

            migrationBuilder.AddColumn<string>(
                name: "Pregunta15",
                table: "PreguntasByEvaluacion",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true)
                .Annotation("Relational:ColumnOrder", 19);

            migrationBuilder.AddColumn<string>(
                name: "Pregunta16",
                table: "PreguntasByEvaluacion",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true)
                .Annotation("Relational:ColumnOrder", 20);

            migrationBuilder.AddColumn<string>(
                name: "Pregunta17",
                table: "PreguntasByEvaluacion",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true)
                .Annotation("Relational:ColumnOrder", 21);

            migrationBuilder.AddColumn<string>(
                name: "Pregunta18",
                table: "PreguntasByEvaluacion",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true)
                .Annotation("Relational:ColumnOrder", 22);

            migrationBuilder.AddColumn<string>(
                name: "Pregunta19",
                table: "PreguntasByEvaluacion",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true)
                .Annotation("Relational:ColumnOrder", 23);

            migrationBuilder.AddColumn<string>(
                name: "Pregunta2",
                table: "PreguntasByEvaluacion",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true)
                .Annotation("Relational:ColumnOrder", 6);

            migrationBuilder.AddColumn<string>(
                name: "Pregunta20",
                table: "PreguntasByEvaluacion",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true)
                .Annotation("Relational:ColumnOrder", 24);

            migrationBuilder.AddColumn<string>(
                name: "Pregunta21",
                table: "PreguntasByEvaluacion",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true)
                .Annotation("Relational:ColumnOrder", 25);

            migrationBuilder.AddColumn<string>(
                name: "Pregunta22",
                table: "PreguntasByEvaluacion",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true)
                .Annotation("Relational:ColumnOrder", 26);

            migrationBuilder.AddColumn<string>(
                name: "Pregunta23",
                table: "PreguntasByEvaluacion",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true)
                .Annotation("Relational:ColumnOrder", 27);

            migrationBuilder.AddColumn<string>(
                name: "Pregunta24",
                table: "PreguntasByEvaluacion",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true)
                .Annotation("Relational:ColumnOrder", 28);

            migrationBuilder.AddColumn<string>(
                name: "Pregunta25",
                table: "PreguntasByEvaluacion",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true)
                .Annotation("Relational:ColumnOrder", 29);

            migrationBuilder.AddColumn<string>(
                name: "Pregunta26",
                table: "PreguntasByEvaluacion",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true)
                .Annotation("Relational:ColumnOrder", 30);

            migrationBuilder.AddColumn<string>(
                name: "Pregunta27",
                table: "PreguntasByEvaluacion",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true)
                .Annotation("Relational:ColumnOrder", 31);

            migrationBuilder.AddColumn<string>(
                name: "Pregunta28",
                table: "PreguntasByEvaluacion",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true)
                .Annotation("Relational:ColumnOrder", 32);

            migrationBuilder.AddColumn<string>(
                name: "Pregunta29",
                table: "PreguntasByEvaluacion",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true)
                .Annotation("Relational:ColumnOrder", 33);

            migrationBuilder.AddColumn<string>(
                name: "Pregunta3",
                table: "PreguntasByEvaluacion",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true)
                .Annotation("Relational:ColumnOrder", 7);

            migrationBuilder.AddColumn<string>(
                name: "Pregunta30",
                table: "PreguntasByEvaluacion",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true)
                .Annotation("Relational:ColumnOrder", 34);

            migrationBuilder.AddColumn<string>(
                name: "Pregunta4",
                table: "PreguntasByEvaluacion",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true)
                .Annotation("Relational:ColumnOrder", 8);

            migrationBuilder.AddColumn<string>(
                name: "Pregunta5",
                table: "PreguntasByEvaluacion",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true)
                .Annotation("Relational:ColumnOrder", 9);

            migrationBuilder.AddColumn<string>(
                name: "Pregunta6",
                table: "PreguntasByEvaluacion",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true)
                .Annotation("Relational:ColumnOrder", 10);

            migrationBuilder.AddColumn<string>(
                name: "Pregunta7",
                table: "PreguntasByEvaluacion",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true)
                .Annotation("Relational:ColumnOrder", 11);

            migrationBuilder.AddColumn<string>(
                name: "Pregunta8",
                table: "PreguntasByEvaluacion",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true)
                .Annotation("Relational:ColumnOrder", 12);

            migrationBuilder.AddColumn<string>(
                name: "Pregunta9",
                table: "PreguntasByEvaluacion",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true)
                .Annotation("Relational:ColumnOrder", 13);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pregunta1",
                table: "PreguntasByEvaluacion");

            migrationBuilder.DropColumn(
                name: "Pregunta10",
                table: "PreguntasByEvaluacion");

            migrationBuilder.DropColumn(
                name: "Pregunta11",
                table: "PreguntasByEvaluacion");

            migrationBuilder.DropColumn(
                name: "Pregunta12",
                table: "PreguntasByEvaluacion");

            migrationBuilder.DropColumn(
                name: "Pregunta13",
                table: "PreguntasByEvaluacion");

            migrationBuilder.DropColumn(
                name: "Pregunta14",
                table: "PreguntasByEvaluacion");

            migrationBuilder.DropColumn(
                name: "Pregunta15",
                table: "PreguntasByEvaluacion");

            migrationBuilder.DropColumn(
                name: "Pregunta16",
                table: "PreguntasByEvaluacion");

            migrationBuilder.DropColumn(
                name: "Pregunta17",
                table: "PreguntasByEvaluacion");

            migrationBuilder.DropColumn(
                name: "Pregunta18",
                table: "PreguntasByEvaluacion");

            migrationBuilder.DropColumn(
                name: "Pregunta19",
                table: "PreguntasByEvaluacion");

            migrationBuilder.DropColumn(
                name: "Pregunta2",
                table: "PreguntasByEvaluacion");

            migrationBuilder.DropColumn(
                name: "Pregunta20",
                table: "PreguntasByEvaluacion");

            migrationBuilder.DropColumn(
                name: "Pregunta21",
                table: "PreguntasByEvaluacion");

            migrationBuilder.DropColumn(
                name: "Pregunta22",
                table: "PreguntasByEvaluacion");

            migrationBuilder.DropColumn(
                name: "Pregunta23",
                table: "PreguntasByEvaluacion");

            migrationBuilder.DropColumn(
                name: "Pregunta24",
                table: "PreguntasByEvaluacion");

            migrationBuilder.DropColumn(
                name: "Pregunta25",
                table: "PreguntasByEvaluacion");

            migrationBuilder.DropColumn(
                name: "Pregunta26",
                table: "PreguntasByEvaluacion");

            migrationBuilder.DropColumn(
                name: "Pregunta27",
                table: "PreguntasByEvaluacion");

            migrationBuilder.DropColumn(
                name: "Pregunta28",
                table: "PreguntasByEvaluacion");

            migrationBuilder.DropColumn(
                name: "Pregunta29",
                table: "PreguntasByEvaluacion");

            migrationBuilder.DropColumn(
                name: "Pregunta3",
                table: "PreguntasByEvaluacion");

            migrationBuilder.DropColumn(
                name: "Pregunta30",
                table: "PreguntasByEvaluacion");

            migrationBuilder.DropColumn(
                name: "Pregunta4",
                table: "PreguntasByEvaluacion");

            migrationBuilder.DropColumn(
                name: "Pregunta5",
                table: "PreguntasByEvaluacion");

            migrationBuilder.DropColumn(
                name: "Pregunta6",
                table: "PreguntasByEvaluacion");

            migrationBuilder.DropColumn(
                name: "Pregunta7",
                table: "PreguntasByEvaluacion");

            migrationBuilder.DropColumn(
                name: "Pregunta8",
                table: "PreguntasByEvaluacion");

            migrationBuilder.DropColumn(
                name: "Pregunta9",
                table: "PreguntasByEvaluacion");

            migrationBuilder.AlterColumn<int>(
                name: "Tipo_Evaluacion_Id",
                table: "PreguntasByEvaluacion",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<int>(
                name: "Pregunta_Id",
                table: "PreguntasByEvaluacion",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<int>(
                name: "Modulo_Id",
                table: "PreguntasByEvaluacion",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 4);

            migrationBuilder.AddColumn<int>(
                name: "PreguntasEvaluacionModelId_Pregunta",
                table: "PreguntasByEvaluacion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PreguntasEvaluacion",
                columns: table => new
                {
                    Id_Pregunta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha_Creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pregunta = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreguntasEvaluacion", x => x.Id_Pregunta);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PreguntasByEvaluacion_PreguntasEvaluacionModelId_Pregunta",
                table: "PreguntasByEvaluacion",
                column: "PreguntasEvaluacionModelId_Pregunta");

            migrationBuilder.AddForeignKey(
                name: "FK_PreguntasByEvaluacion_PreguntasEvaluacion_PreguntasEvaluacionModelId_Pregunta",
                table: "PreguntasByEvaluacion",
                column: "PreguntasEvaluacionModelId_Pregunta",
                principalTable: "PreguntasEvaluacion",
                principalColumn: "Id_Pregunta",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
