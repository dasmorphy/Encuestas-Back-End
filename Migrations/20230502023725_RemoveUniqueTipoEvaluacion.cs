using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiprueba.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUniqueTipoEvaluacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Evaluacion_Tipo_Evaluacion_Id",
                table: "Evaluacion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Evaluacion_Tipo_Evaluacion_Id",
                table: "Evaluacion",
                column: "Tipo_Evaluacion_Id",
                unique: true);
        }
    }
}
