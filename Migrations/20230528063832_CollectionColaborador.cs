using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiprueba.Migrations
{
    /// <inheritdoc />
    public partial class CollectionColaborador : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluacion_Colaborador_ColaboradorModelId_Colaborador",
                table: "Evaluacion");

            migrationBuilder.DropIndex(
                name: "IX_Evaluacion_ColaboradorModelId_Colaborador",
                table: "Evaluacion");

            migrationBuilder.DropColumn(
                name: "ColaboradorModelId_Colaborador",
                table: "Evaluacion");

            migrationBuilder.AddColumn<int>(
                name: "EvaluacionModelId_Evaluacion",
                table: "Colaborador",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_EvaluacionModelId_Evaluacion",
                table: "Colaborador",
                column: "EvaluacionModelId_Evaluacion");

            migrationBuilder.AddForeignKey(
                name: "FK_Colaborador_Evaluacion_EvaluacionModelId_Evaluacion",
                table: "Colaborador",
                column: "EvaluacionModelId_Evaluacion",
                principalTable: "Evaluacion",
                principalColumn: "Id_Evaluacion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colaborador_Evaluacion_EvaluacionModelId_Evaluacion",
                table: "Colaborador");

            migrationBuilder.DropIndex(
                name: "IX_Colaborador_EvaluacionModelId_Evaluacion",
                table: "Colaborador");

            migrationBuilder.DropColumn(
                name: "EvaluacionModelId_Evaluacion",
                table: "Colaborador");

            migrationBuilder.AddColumn<int>(
                name: "ColaboradorModelId_Colaborador",
                table: "Evaluacion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Evaluacion_ColaboradorModelId_Colaborador",
                table: "Evaluacion",
                column: "ColaboradorModelId_Colaborador");

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluacion_Colaborador_ColaboradorModelId_Colaborador",
                table: "Evaluacion",
                column: "ColaboradorModelId_Colaborador",
                principalTable: "Colaborador",
                principalColumn: "Id_Colaborador",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
