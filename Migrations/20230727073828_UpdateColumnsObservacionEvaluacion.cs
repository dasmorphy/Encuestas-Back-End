using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiprueba.Migrations
{
    /// <inheritdoc />
    public partial class UpdateColumnsObservacionEvaluacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha_Creacion",
                table: "ObservacionEvaluacion",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2")
                .Annotation("Relational:ColumnOrder", 55)
                .OldAnnotation("Relational:ColumnOrder", 33);

            migrationBuilder.AddColumn<string>(
                name: "Observacion31",
                table: "ObservacionEvaluacion",
                type: "nvarchar(max)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 33);

            migrationBuilder.AddColumn<string>(
                name: "Observacion32",
                table: "ObservacionEvaluacion",
                type: "nvarchar(max)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 34);

            migrationBuilder.AddColumn<string>(
                name: "Observacion33",
                table: "ObservacionEvaluacion",
                type: "nvarchar(max)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 35);

            migrationBuilder.AddColumn<string>(
                name: "Observacion34",
                table: "ObservacionEvaluacion",
                type: "nvarchar(max)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 36);

            migrationBuilder.AddColumn<string>(
                name: "Observacion35",
                table: "ObservacionEvaluacion",
                type: "nvarchar(max)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 37);

            migrationBuilder.AddColumn<string>(
                name: "Observacion36",
                table: "ObservacionEvaluacion",
                type: "nvarchar(max)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 38);

            migrationBuilder.AddColumn<string>(
                name: "Observacion37",
                table: "ObservacionEvaluacion",
                type: "nvarchar(max)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 39);

            migrationBuilder.AddColumn<string>(
                name: "Observacion38",
                table: "ObservacionEvaluacion",
                type: "nvarchar(max)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 40);

            migrationBuilder.AddColumn<string>(
                name: "Observacion39",
                table: "ObservacionEvaluacion",
                type: "nvarchar(max)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 41);

            migrationBuilder.AddColumn<string>(
                name: "Observacion40",
                table: "ObservacionEvaluacion",
                type: "nvarchar(max)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 42);

            migrationBuilder.AddColumn<string>(
                name: "Observacion41",
                table: "ObservacionEvaluacion",
                type: "nvarchar(max)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 43);

            migrationBuilder.AddColumn<string>(
                name: "Observacion42",
                table: "ObservacionEvaluacion",
                type: "nvarchar(max)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 44);

            migrationBuilder.AddColumn<string>(
                name: "Observacion43",
                table: "ObservacionEvaluacion",
                type: "nvarchar(max)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 45);

            migrationBuilder.AddColumn<string>(
                name: "Observacion44",
                table: "ObservacionEvaluacion",
                type: "nvarchar(max)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 46);

            migrationBuilder.AddColumn<string>(
                name: "Observacion45",
                table: "ObservacionEvaluacion",
                type: "nvarchar(max)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 47);

            migrationBuilder.AddColumn<string>(
                name: "Observacion46",
                table: "ObservacionEvaluacion",
                type: "nvarchar(max)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 48);

            migrationBuilder.AddColumn<string>(
                name: "Observacion47",
                table: "ObservacionEvaluacion",
                type: "nvarchar(max)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 49);

            migrationBuilder.AddColumn<string>(
                name: "Observacion48",
                table: "ObservacionEvaluacion",
                type: "nvarchar(max)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 50);

            migrationBuilder.AddColumn<string>(
                name: "Observacion49",
                table: "ObservacionEvaluacion",
                type: "nvarchar(max)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 51);

            migrationBuilder.AddColumn<string>(
                name: "Observacion50",
                table: "ObservacionEvaluacion",
                type: "nvarchar(max)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 52);

            migrationBuilder.AddColumn<string>(
                name: "Observacion51",
                table: "ObservacionEvaluacion",
                type: "nvarchar(max)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 53);

            migrationBuilder.AddColumn<string>(
                name: "Observacion52",
                table: "ObservacionEvaluacion",
                type: "nvarchar(max)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 54);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta31",
                table: "Evaluacion",
                type: "decimal(4,2)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 36);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta32",
                table: "Evaluacion",
                type: "decimal(4,2)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 37);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta33",
                table: "Evaluacion",
                type: "decimal(4,2)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 38);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta34",
                table: "Evaluacion",
                type: "decimal(4,2)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 39);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta35",
                table: "Evaluacion",
                type: "decimal(4,2)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 40);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta36",
                table: "Evaluacion",
                type: "decimal(4,2)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 41);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta37",
                table: "Evaluacion",
                type: "decimal(4,2)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 42);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta38",
                table: "Evaluacion",
                type: "decimal(4,2)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 43);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta39",
                table: "Evaluacion",
                type: "decimal(4,2)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 44);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta40",
                table: "Evaluacion",
                type: "decimal(4,2)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 45);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta41",
                table: "Evaluacion",
                type: "decimal(4,2)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 46);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta42",
                table: "Evaluacion",
                type: "decimal(4,2)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 47);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta43",
                table: "Evaluacion",
                type: "decimal(4,2)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 48);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta44",
                table: "Evaluacion",
                type: "decimal(4,2)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 49);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta45",
                table: "Evaluacion",
                type: "decimal(4,2)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 50);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta46",
                table: "Evaluacion",
                type: "decimal(4,2)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 51);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta47",
                table: "Evaluacion",
                type: "decimal(4,2)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 52);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta48",
                table: "Evaluacion",
                type: "decimal(4,2)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 53);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta49",
                table: "Evaluacion",
                type: "decimal(4,2)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 54);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta50",
                table: "Evaluacion",
                type: "decimal(4,2)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 55);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta51",
                table: "Evaluacion",
                type: "decimal(4,2)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 56);

            migrationBuilder.AddColumn<decimal>(
                name: "Clfc_Pregunta52",
                table: "Evaluacion",
                type: "decimal(4,2)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 57);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Observacion31",
                table: "ObservacionEvaluacion");

            migrationBuilder.DropColumn(
                name: "Observacion32",
                table: "ObservacionEvaluacion");

            migrationBuilder.DropColumn(
                name: "Observacion33",
                table: "ObservacionEvaluacion");

            migrationBuilder.DropColumn(
                name: "Observacion34",
                table: "ObservacionEvaluacion");

            migrationBuilder.DropColumn(
                name: "Observacion35",
                table: "ObservacionEvaluacion");

            migrationBuilder.DropColumn(
                name: "Observacion36",
                table: "ObservacionEvaluacion");

            migrationBuilder.DropColumn(
                name: "Observacion37",
                table: "ObservacionEvaluacion");

            migrationBuilder.DropColumn(
                name: "Observacion38",
                table: "ObservacionEvaluacion");

            migrationBuilder.DropColumn(
                name: "Observacion39",
                table: "ObservacionEvaluacion");

            migrationBuilder.DropColumn(
                name: "Observacion40",
                table: "ObservacionEvaluacion");

            migrationBuilder.DropColumn(
                name: "Observacion41",
                table: "ObservacionEvaluacion");

            migrationBuilder.DropColumn(
                name: "Observacion42",
                table: "ObservacionEvaluacion");

            migrationBuilder.DropColumn(
                name: "Observacion43",
                table: "ObservacionEvaluacion");

            migrationBuilder.DropColumn(
                name: "Observacion44",
                table: "ObservacionEvaluacion");

            migrationBuilder.DropColumn(
                name: "Observacion45",
                table: "ObservacionEvaluacion");

            migrationBuilder.DropColumn(
                name: "Observacion46",
                table: "ObservacionEvaluacion");

            migrationBuilder.DropColumn(
                name: "Observacion47",
                table: "ObservacionEvaluacion");

            migrationBuilder.DropColumn(
                name: "Observacion48",
                table: "ObservacionEvaluacion");

            migrationBuilder.DropColumn(
                name: "Observacion49",
                table: "ObservacionEvaluacion");

            migrationBuilder.DropColumn(
                name: "Observacion50",
                table: "ObservacionEvaluacion");

            migrationBuilder.DropColumn(
                name: "Observacion51",
                table: "ObservacionEvaluacion");

            migrationBuilder.DropColumn(
                name: "Observacion52",
                table: "ObservacionEvaluacion");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta31",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta32",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta33",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta34",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta35",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta36",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta37",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta38",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta39",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta40",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta41",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta42",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta43",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta44",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta45",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta46",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta47",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta48",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta49",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta50",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta51",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "Clfc_Pregunta52",
                table: "Evaluacion");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha_Creacion",
                table: "ObservacionEvaluacion",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2")
                .Annotation("Relational:ColumnOrder", 33)
                .OldAnnotation("Relational:ColumnOrder", 55);
        }
    }
}
