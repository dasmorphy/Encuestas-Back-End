using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiprueba.Migrations
{
    /// <inheritdoc />
    public partial class UpdateColaboradorModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombres_Jefe",
                table: "Colaborador",
                newName: "Nombres_Evaluador");

            migrationBuilder.RenameColumn(
                name: "Fe_Ingreso_Jefe",
                table: "Colaborador",
                newName: "Fe_Ingreso_Evaluador");

            migrationBuilder.RenameColumn(
                name: "Cedula_Jefe",
                table: "Colaborador",
                newName: "Cedula_Evaluador");

            migrationBuilder.RenameColumn(
                name: "Cargo_Jefe",
                table: "Colaborador",
                newName: "Cargo_Evaluador");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombres_Evaluador",
                table: "Colaborador",
                newName: "Nombres_Jefe");

            migrationBuilder.RenameColumn(
                name: "Fe_Ingreso_Evaluador",
                table: "Colaborador",
                newName: "Fe_Ingreso_Jefe");

            migrationBuilder.RenameColumn(
                name: "Cedula_Evaluador",
                table: "Colaborador",
                newName: "Cedula_Jefe");

            migrationBuilder.RenameColumn(
                name: "Cargo_Evaluador",
                table: "Colaborador",
                newName: "Cargo_Jefe");
        }
    }
}
