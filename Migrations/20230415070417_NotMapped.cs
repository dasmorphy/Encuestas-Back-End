using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiprueba.Migrations
{
    /// <inheritdoc />
    public partial class NotMapped : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Colaborador_ColaboradorId_Colaborador",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_ColaboradorId_Colaborador",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "ColaboradorId_Colaborador",
                table: "Usuarios");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ColaboradorId_Colaborador",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_ColaboradorId_Colaborador",
                table: "Usuarios",
                column: "ColaboradorId_Colaborador");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Colaborador_ColaboradorId_Colaborador",
                table: "Usuarios",
                column: "ColaboradorId_Colaborador",
                principalTable: "Colaborador",
                principalColumn: "Id_Colaborador",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
