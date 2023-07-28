using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiprueba.Migrations
{
    /// <inheritdoc />
    public partial class NuevosAtributosColaborador : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apellidos",
                table: "Colaborador");

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Evaluacion",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "Nombres",
                table: "Colaborador",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<string>(
                name: "Area",
                table: "Colaborador",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CC",
                table: "Colaborador",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cargo_Colaborador",
                table: "Colaborador",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cargo_Jefe",
                table: "Colaborador",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cedula",
                table: "Colaborador",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cedula_Jefe",
                table: "Colaborador",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Departamento",
                table: "Colaborador",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Fe_Ingreso_Colaborador",
                table: "Colaborador",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Fe_Ingreso_Jefe",
                table: "Colaborador",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Localidad",
                table: "Colaborador",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nombres_Jefe",
                table: "Colaborador",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Zona",
                table: "Colaborador",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Area",
                table: "Colaborador");

            migrationBuilder.DropColumn(
                name: "CC",
                table: "Colaborador");

            migrationBuilder.DropColumn(
                name: "Cargo_Colaborador",
                table: "Colaborador");

            migrationBuilder.DropColumn(
                name: "Cargo_Jefe",
                table: "Colaborador");

            migrationBuilder.DropColumn(
                name: "Cedula",
                table: "Colaborador");

            migrationBuilder.DropColumn(
                name: "Cedula_Jefe",
                table: "Colaborador");

            migrationBuilder.DropColumn(
                name: "Departamento",
                table: "Colaborador");

            migrationBuilder.DropColumn(
                name: "Fe_Ingreso_Colaborador",
                table: "Colaborador");

            migrationBuilder.DropColumn(
                name: "Fe_Ingreso_Jefe",
                table: "Colaborador");

            migrationBuilder.DropColumn(
                name: "Localidad",
                table: "Colaborador");

            migrationBuilder.DropColumn(
                name: "Nombres_Jefe",
                table: "Colaborador");

            migrationBuilder.DropColumn(
                name: "Zona",
                table: "Colaborador");

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Evaluacion",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombres",
                table: "Colaborador",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.AddColumn<string>(
                name: "Apellidos",
                table: "Colaborador",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }
    }
}
