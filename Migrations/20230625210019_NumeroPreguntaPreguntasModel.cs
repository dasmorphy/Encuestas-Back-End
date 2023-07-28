using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiprueba.Migrations
{
    /// <inheritdoc />
    public partial class NumeroPreguntaPreguntasModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Numero_Pregunta",
                table: "PreguntasByEvaluacion",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("Relational:ColumnOrder", 6);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Numero_Pregunta",
                table: "PreguntasByEvaluacion");
        }
    }
}
