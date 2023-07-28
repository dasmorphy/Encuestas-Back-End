using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiprueba.Migrations
{
    /// <inheritdoc />
    public partial class AddTipoEvalucionToPregunta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Tipo_Evaluacion_Id",
                table: "PreguntasByEvaluacion",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("Relational:ColumnOrder", 3);

            migrationBuilder.CreateIndex(
                name: "IX_PreguntasByEvaluacion_Tipo_Evaluacion_Id",
                table: "PreguntasByEvaluacion",
                column: "Tipo_Evaluacion_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PreguntasByEvaluacion_Tipo_Evaluacion_Tipo_Evaluacion_Id",
                table: "PreguntasByEvaluacion",
                column: "Tipo_Evaluacion_Id",
                principalTable: "Tipo_Evaluacion",
                principalColumn: "Id_Tipo_Evaluacion",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PreguntasByEvaluacion_Tipo_Evaluacion_Tipo_Evaluacion_Id",
                table: "PreguntasByEvaluacion");

            migrationBuilder.DropIndex(
                name: "IX_PreguntasByEvaluacion_Tipo_Evaluacion_Id",
                table: "PreguntasByEvaluacion");

            migrationBuilder.DropColumn(
                name: "Tipo_Evaluacion_Id",
                table: "PreguntasByEvaluacion");
        }
    }
}
