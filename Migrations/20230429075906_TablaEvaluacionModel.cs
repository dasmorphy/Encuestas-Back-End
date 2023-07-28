using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiprueba.Migrations
{
    /// <inheritdoc />
    public partial class TablaEvaluacionModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Evaluacion",
                columns: table => new
                {
                    Id_Evaluacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Tipo_Evaluacion = table.Column<int>(type: "int", nullable: false),
                    Pregunta = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Competencia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Definicion = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Fecha_Creacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluacion", x => x.Id_Evaluacion);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Evaluacion_Id_Tipo_Evaluacion",
                table: "Evaluacion",
                column: "Id_Tipo_Evaluacion",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Evaluacion");
        }
    }
}
