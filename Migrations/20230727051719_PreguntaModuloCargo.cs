using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiprueba.Migrations
{
    /// <inheritdoc />
    public partial class PreguntaModuloCargo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PreguntasModuloCargo",
                columns: table => new
                {
                    Id_PreguntaModuloCargo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modulo_Id = table.Column<int>(type: "int", nullable: false),
                    Cargo_Id = table.Column<int>(type: "int", nullable: false),
                    Tipo_Evaluacion_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreguntasModuloCargo", x => x.Id_PreguntaModuloCargo);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PreguntasModuloCargo");
        }
    }
}
