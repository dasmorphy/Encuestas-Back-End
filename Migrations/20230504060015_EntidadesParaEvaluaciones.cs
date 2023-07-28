using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiprueba.Migrations
{
    /// <inheritdoc />
    public partial class EntidadesParaEvaluaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "ModuloEvaluacionModel",
                columns: table => new
                {
                    Id_Modulo_Evaluacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Modulo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Definicion = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Fecha_Creacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuloEvaluacionModel", x => x.Id_Modulo_Evaluacion);
                });

            migrationBuilder.CreateTable(
                name: "PreguntasByEvaluacionModel",
                columns: table => new
                {
                    Id_Preguntas_Tipo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pregunta_Id = table.Column<int>(type: "int", nullable: false),
                    Tipo_Evaluacion_Id = table.Column<int>(type: "int", nullable: false),
                    Modulo_Id = table.Column<int>(type: "int", nullable: false),
                    Fecha_Creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModuloEvaluacionModelId_Modulo_Evaluacion = table.Column<int>(type: "int", nullable: false),
                    TipoEvaluacionModelId_Tipo_Evaluacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreguntasByEvaluacionModel", x => x.Id_Preguntas_Tipo);
                    table.ForeignKey(
                        name: "FK_PreguntasByEvaluacionModel_ModuloEvaluacionModel_ModuloEvaluacionModelId_Modulo_Evaluacion",
                        column: x => x.ModuloEvaluacionModelId_Modulo_Evaluacion,
                        principalTable: "ModuloEvaluacionModel",
                        principalColumn: "Id_Modulo_Evaluacion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PreguntasByEvaluacionModel_Tipo_Evaluacion_TipoEvaluacionModelId_Tipo_Evaluacion",
                        column: x => x.TipoEvaluacionModelId_Tipo_Evaluacion,
                        principalTable: "Tipo_Evaluacion",
                        principalColumn: "Id_Tipo_Evaluacion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PreguntasByEvaluacionModel_ModuloEvaluacionModelId_Modulo_Evaluacion",
                table: "PreguntasByEvaluacionModel",
                column: "ModuloEvaluacionModelId_Modulo_Evaluacion");

            migrationBuilder.CreateIndex(
                name: "IX_PreguntasByEvaluacionModel_TipoEvaluacionModelId_Tipo_Evaluacion",
                table: "PreguntasByEvaluacionModel",
                column: "TipoEvaluacionModelId_Tipo_Evaluacion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PreguntasByEvaluacionModel");

            migrationBuilder.DropTable(
                name: "ModuloEvaluacionModel");

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
    }
}
