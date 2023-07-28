using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiprueba.Migrations
{
    /// <inheritdoc />
    public partial class ObservacionModelRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Observacion_id",
                table: "Evaluacion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ObservacionEvaluacion",
                columns: table => new
                {
                    Evaluacion_id = table.Column<int>(type: "int", nullable: false),
                    Observacion1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacion2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacion3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacion4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacion5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacion6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacion7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacion8 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacion9 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacion10 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacion11 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacion12 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacion13 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacion14 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacion15 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacion16 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacion17 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacion18 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacion19 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacion20 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacion21 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacion22 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacion23 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacion24 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacion25 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacion26 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacion27 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacion28 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacion29 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacion30 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha_Creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id_Observacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObservacionEvaluacion", x => x.Id_Observacion);
                    table.ForeignKey(
                        name: "FK_ObservacionEvaluacion_Evaluacion_Evaluacion_id",
                        column: x => x.Evaluacion_id,
                        principalTable: "Evaluacion",
                        principalColumn: "Id_Evaluacion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ObservacionEvaluacion_Evaluacion_id",
                table: "ObservacionEvaluacion",
                column: "Evaluacion_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ObservacionEvaluacion");

            migrationBuilder.DropColumn(
                name: "Observacion_id",
                table: "Evaluacion");
        }
    }
}
