using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiprueba.Migrations
{
    /// <inheritdoc />
    public partial class TipoCompetenciaModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Peso_Modulo",
                table: "ModuloEvaluacion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoCompetenciaId_Tipo_Competencia",
                table: "ModuloEvaluacion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Tipo_Competencia_Id",
                table: "ModuloEvaluacion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TipoCompetencia",
                columns: table => new
                {
                    Id_Tipo_Competencia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Peso_Tipo_Competencia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCompetencia", x => x.Id_Tipo_Competencia);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModuloEvaluacion_TipoCompetenciaId_Tipo_Competencia",
                table: "ModuloEvaluacion",
                column: "TipoCompetenciaId_Tipo_Competencia");

            migrationBuilder.AddForeignKey(
                name: "FK_ModuloEvaluacion_TipoCompetencia_TipoCompetenciaId_Tipo_Competencia",
                table: "ModuloEvaluacion",
                column: "TipoCompetenciaId_Tipo_Competencia",
                principalTable: "TipoCompetencia",
                principalColumn: "Id_Tipo_Competencia",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModuloEvaluacion_TipoCompetencia_TipoCompetenciaId_Tipo_Competencia",
                table: "ModuloEvaluacion");

            migrationBuilder.DropTable(
                name: "TipoCompetencia");

            migrationBuilder.DropIndex(
                name: "IX_ModuloEvaluacion_TipoCompetenciaId_Tipo_Competencia",
                table: "ModuloEvaluacion");

            migrationBuilder.DropColumn(
                name: "Peso_Modulo",
                table: "ModuloEvaluacion");

            migrationBuilder.DropColumn(
                name: "TipoCompetenciaId_Tipo_Competencia",
                table: "ModuloEvaluacion");

            migrationBuilder.DropColumn(
                name: "Tipo_Competencia_Id",
                table: "ModuloEvaluacion");
        }
    }
}
