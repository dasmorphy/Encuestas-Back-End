using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiprueba.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PreguntasByEvaluacionModel_ModuloEvaluacionModel_ModuloEvaluacionModelId_Modulo_Evaluacion",
                table: "PreguntasByEvaluacionModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PreguntasByEvaluacionModel_Tipo_Evaluacion_TipoEvaluacionModelId_Tipo_Evaluacion",
                table: "PreguntasByEvaluacionModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PreguntasByEvaluacionModel",
                table: "PreguntasByEvaluacionModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ModuloEvaluacionModel",
                table: "ModuloEvaluacionModel");

            migrationBuilder.RenameTable(
                name: "PreguntasByEvaluacionModel",
                newName: "PreguntasByEvaluacion");

            migrationBuilder.RenameTable(
                name: "ModuloEvaluacionModel",
                newName: "ModuloEvaluacion");

            migrationBuilder.RenameIndex(
                name: "IX_PreguntasByEvaluacionModel_TipoEvaluacionModelId_Tipo_Evaluacion",
                table: "PreguntasByEvaluacion",
                newName: "IX_PreguntasByEvaluacion_TipoEvaluacionModelId_Tipo_Evaluacion");

            migrationBuilder.RenameIndex(
                name: "IX_PreguntasByEvaluacionModel_ModuloEvaluacionModelId_Modulo_Evaluacion",
                table: "PreguntasByEvaluacion",
                newName: "IX_PreguntasByEvaluacion_ModuloEvaluacionModelId_Modulo_Evaluacion");

            migrationBuilder.AddColumn<int>(
                name: "PreguntasEvaluacionModelId_Pregunta",
                table: "PreguntasByEvaluacion",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PreguntasByEvaluacion",
                table: "PreguntasByEvaluacion",
                column: "Id_Preguntas_Tipo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModuloEvaluacion",
                table: "ModuloEvaluacion",
                column: "Id_Modulo_Evaluacion");

            migrationBuilder.CreateTable(
                name: "PreguntasEvaluacion",
                columns: table => new
                {
                    Id_Pregunta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pregunta = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Fecha_Creacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreguntasEvaluacion", x => x.Id_Pregunta);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PreguntasByEvaluacion_PreguntasEvaluacionModelId_Pregunta",
                table: "PreguntasByEvaluacion",
                column: "PreguntasEvaluacionModelId_Pregunta");

            migrationBuilder.AddForeignKey(
                name: "FK_PreguntasByEvaluacion_ModuloEvaluacion_ModuloEvaluacionModelId_Modulo_Evaluacion",
                table: "PreguntasByEvaluacion",
                column: "ModuloEvaluacionModelId_Modulo_Evaluacion",
                principalTable: "ModuloEvaluacion",
                principalColumn: "Id_Modulo_Evaluacion",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PreguntasByEvaluacion_PreguntasEvaluacion_PreguntasEvaluacionModelId_Pregunta",
                table: "PreguntasByEvaluacion",
                column: "PreguntasEvaluacionModelId_Pregunta",
                principalTable: "PreguntasEvaluacion",
                principalColumn: "Id_Pregunta");

            migrationBuilder.AddForeignKey(
                name: "FK_PreguntasByEvaluacion_Tipo_Evaluacion_TipoEvaluacionModelId_Tipo_Evaluacion",
                table: "PreguntasByEvaluacion",
                column: "TipoEvaluacionModelId_Tipo_Evaluacion",
                principalTable: "Tipo_Evaluacion",
                principalColumn: "Id_Tipo_Evaluacion",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PreguntasByEvaluacion_ModuloEvaluacion_ModuloEvaluacionModelId_Modulo_Evaluacion",
                table: "PreguntasByEvaluacion");

            migrationBuilder.DropForeignKey(
                name: "FK_PreguntasByEvaluacion_PreguntasEvaluacion_PreguntasEvaluacionModelId_Pregunta",
                table: "PreguntasByEvaluacion");

            migrationBuilder.DropForeignKey(
                name: "FK_PreguntasByEvaluacion_Tipo_Evaluacion_TipoEvaluacionModelId_Tipo_Evaluacion",
                table: "PreguntasByEvaluacion");

            migrationBuilder.DropTable(
                name: "PreguntasEvaluacion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PreguntasByEvaluacion",
                table: "PreguntasByEvaluacion");

            migrationBuilder.DropIndex(
                name: "IX_PreguntasByEvaluacion_PreguntasEvaluacionModelId_Pregunta",
                table: "PreguntasByEvaluacion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ModuloEvaluacion",
                table: "ModuloEvaluacion");

            migrationBuilder.DropColumn(
                name: "PreguntasEvaluacionModelId_Pregunta",
                table: "PreguntasByEvaluacion");

            migrationBuilder.RenameTable(
                name: "PreguntasByEvaluacion",
                newName: "PreguntasByEvaluacionModel");

            migrationBuilder.RenameTable(
                name: "ModuloEvaluacion",
                newName: "ModuloEvaluacionModel");

            migrationBuilder.RenameIndex(
                name: "IX_PreguntasByEvaluacion_TipoEvaluacionModelId_Tipo_Evaluacion",
                table: "PreguntasByEvaluacionModel",
                newName: "IX_PreguntasByEvaluacionModel_TipoEvaluacionModelId_Tipo_Evaluacion");

            migrationBuilder.RenameIndex(
                name: "IX_PreguntasByEvaluacion_ModuloEvaluacionModelId_Modulo_Evaluacion",
                table: "PreguntasByEvaluacionModel",
                newName: "IX_PreguntasByEvaluacionModel_ModuloEvaluacionModelId_Modulo_Evaluacion");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PreguntasByEvaluacionModel",
                table: "PreguntasByEvaluacionModel",
                column: "Id_Preguntas_Tipo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModuloEvaluacionModel",
                table: "ModuloEvaluacionModel",
                column: "Id_Modulo_Evaluacion");

            migrationBuilder.AddForeignKey(
                name: "FK_PreguntasByEvaluacionModel_ModuloEvaluacionModel_ModuloEvaluacionModelId_Modulo_Evaluacion",
                table: "PreguntasByEvaluacionModel",
                column: "ModuloEvaluacionModelId_Modulo_Evaluacion",
                principalTable: "ModuloEvaluacionModel",
                principalColumn: "Id_Modulo_Evaluacion",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PreguntasByEvaluacionModel_Tipo_Evaluacion_TipoEvaluacionModelId_Tipo_Evaluacion",
                table: "PreguntasByEvaluacionModel",
                column: "TipoEvaluacionModelId_Tipo_Evaluacion",
                principalTable: "Tipo_Evaluacion",
                principalColumn: "Id_Tipo_Evaluacion",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
