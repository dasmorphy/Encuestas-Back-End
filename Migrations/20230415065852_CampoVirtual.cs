using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiprueba.Migrations
{
    /// <inheritdoc />
    public partial class CampoVirtual : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Colaborador_ColaboradorId_Colaborador",
                table: "Usuarios");

            migrationBuilder.AlterColumn<int>(
                name: "ColaboradorId_Colaborador",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Colaborador_ColaboradorId_Colaborador",
                table: "Usuarios",
                column: "ColaboradorId_Colaborador",
                principalTable: "Colaborador",
                principalColumn: "Id_Colaborador",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Colaborador_ColaboradorId_Colaborador",
                table: "Usuarios");

            migrationBuilder.AlterColumn<int>(
                name: "ColaboradorId_Colaborador",
                table: "Usuarios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Colaborador_ColaboradorId_Colaborador",
                table: "Usuarios",
                column: "ColaboradorId_Colaborador",
                principalTable: "Colaborador",
                principalColumn: "Id_Colaborador");
        }
    }
}
