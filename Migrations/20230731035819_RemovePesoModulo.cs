using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiprueba.Migrations
{
    /// <inheritdoc />
    public partial class RemovePesoModulo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Peso_Tipo_Competencia",
                table: "TipoCompetencia");

            migrationBuilder.DropColumn(
                name: "Peso_Modulo",
                table: "ModuloEvaluacion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Peso_Tipo_Competencia",
                table: "TipoCompetencia",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("Relational:ColumnOrder", 3);

            migrationBuilder.AddColumn<int>(
                name: "Peso_Modulo",
                table: "ModuloEvaluacion",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
