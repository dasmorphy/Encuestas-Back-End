using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiprueba.Migrations
{
    /// <inheritdoc />
    public partial class RelacionEvaluacionToTipo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id_Tipo_Evaluacion",
                table: "Evaluacion",
                newName: "Tipo_Evaluacion_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Evaluacion_Id_Tipo_Evaluacion",
                table: "Evaluacion",
                newName: "IX_Evaluacion_Tipo_Evaluacion_Id");

            migrationBuilder.AddColumn<int>(
                name: "TipoEvaluacionModelId_Tipo_Evaluacion",
                table: "Evaluacion",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Evaluacion_TipoEvaluacionModelId_Tipo_Evaluacion",
                table: "Evaluacion",
                column: "TipoEvaluacionModelId_Tipo_Evaluacion");

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluacion_Tipo_Evaluacion_TipoEvaluacionModelId_Tipo_Evaluacion",
                table: "Evaluacion",
                column: "TipoEvaluacionModelId_Tipo_Evaluacion",
                principalTable: "Tipo_Evaluacion",
                principalColumn: "Id_Tipo_Evaluacion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluacion_Tipo_Evaluacion_TipoEvaluacionModelId_Tipo_Evaluacion",
                table: "Evaluacion");

            migrationBuilder.DropIndex(
                name: "IX_Evaluacion_TipoEvaluacionModelId_Tipo_Evaluacion",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "TipoEvaluacionModelId_Tipo_Evaluacion",
                table: "Evaluacion");

            migrationBuilder.RenameColumn(
                name: "Tipo_Evaluacion_Id",
                table: "Evaluacion",
                newName: "Id_Tipo_Evaluacion");

            migrationBuilder.RenameIndex(
                name: "IX_Evaluacion_Tipo_Evaluacion_Id",
                table: "Evaluacion",
                newName: "IX_Evaluacion_Id_Tipo_Evaluacion");
        }
    }
}
