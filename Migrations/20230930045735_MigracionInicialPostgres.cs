using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace apiprueba.Migrations
{
    /// <inheritdoc />
    public partial class MigracionInicialPostgres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    Id_Cargo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre_Cargo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.Id_Cargo);
                });

            migrationBuilder.CreateTable(
                name: "Colaborador",
                columns: table => new
                {
                    Id_Colaborador = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Cedula = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false),
                    Nombres = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    Fe_Ingreso_Colaborador = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Cargo_Colaborador = table.Column<string>(type: "text", nullable: false),
                    CC = table.Column<string>(type: "text", nullable: false),
                    Localidad = table.Column<string>(type: "text", nullable: false),
                    Zona = table.Column<string>(type: "text", nullable: false),
                    Area = table.Column<string>(type: "text", nullable: false),
                    Departamento = table.Column<string>(type: "text", nullable: false),
                    Cedula_Evaluador = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false),
                    Nombres_Evaluador = table.Column<string>(type: "text", nullable: false),
                    Fe_Ingreso_Evaluador = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Cargo_Evaluador = table.Column<string>(type: "text", nullable: false),
                    Cargo = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Grupo = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Cargo_Id = table.Column<int>(type: "integer", nullable: false),
                    Estado = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaborador", x => x.Id_Colaborador);
                });

            migrationBuilder.CreateTable(
                name: "PreguntasModuloCargo",
                columns: table => new
                {
                    Id_PreguntaModuloCargo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Modulo_Id = table.Column<int>(type: "integer", nullable: false),
                    Cargo_Id = table.Column<int>(type: "integer", nullable: false),
                    Tipo_Evaluacion_Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreguntasModuloCargo", x => x.Id_PreguntaModuloCargo);
                });

            migrationBuilder.CreateTable(
                name: "ProcesosEvaluacion",
                columns: table => new
                {
                    Id_Proceso_Evaluacion = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Fecha_Inicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Fecha_Fin = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Estado = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcesosEvaluacion", x => x.Id_Proceso_Evaluacion);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id_Rol = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre_Rol = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Fecha_Creacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id_Rol);
                });

            migrationBuilder.CreateTable(
                name: "Tipo_Evaluacion",
                columns: table => new
                {
                    Id_Tipo_Evaluacion = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre_Tipo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Fecha_Creacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_Evaluacion", x => x.Id_Tipo_Evaluacion);
                });

            migrationBuilder.CreateTable(
                name: "TipoCompetencia",
                columns: table => new
                {
                    Id_Tipo_Competencia = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCompetencia", x => x.Id_Tipo_Competencia);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id_Usuario = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Usuario = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Identificacion = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Rol_Id = table.Column<int>(type: "integer", nullable: false),
                    Fecha_Creacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RolesModelId_Rol = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id_Usuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_RolesModelId_Rol",
                        column: x => x.RolesModelId_Rol,
                        principalTable: "Roles",
                        principalColumn: "Id_Rol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModuloEvaluacion",
                columns: table => new
                {
                    Id_Modulo_Evaluacion = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre_Modulo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Definicion = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Fecha_Creacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Tipo_Evaluacion_Id = table.Column<int>(type: "integer", nullable: false),
                    Tipo_Competencia_Id = table.Column<int>(type: "integer", nullable: false),
                    TipoEvaluacionModelId_Tipo_Evaluacion = table.Column<int>(type: "integer", nullable: false),
                    TipoCompetenciaId_Tipo_Competencia = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuloEvaluacion", x => x.Id_Modulo_Evaluacion);
                    table.ForeignKey(
                        name: "FK_ModuloEvaluacion_TipoCompetencia_TipoCompetenciaId_Tipo_Com~",
                        column: x => x.TipoCompetenciaId_Tipo_Competencia,
                        principalTable: "TipoCompetencia",
                        principalColumn: "Id_Tipo_Competencia",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuloEvaluacion_Tipo_Evaluacion_TipoEvaluacionModelId_Tipo~",
                        column: x => x.TipoEvaluacionModelId_Tipo_Evaluacion,
                        principalTable: "Tipo_Evaluacion",
                        principalColumn: "Id_Tipo_Evaluacion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Evaluacion",
                columns: table => new
                {
                    Id_Evaluacion = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Usuario_id = table.Column<int>(type: "integer", nullable: false),
                    Colaborador_id = table.Column<int>(type: "integer", nullable: false),
                    Estado = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: true),
                    CalificacionFinal = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    Clfc_Pregunta1 = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    Clfc_Pregunta2 = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    Clfc_Pregunta3 = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    Clfc_Pregunta4 = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    Clfc_Pregunta5 = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    Clfc_Pregunta6 = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    Clfc_Pregunta7 = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    Clfc_Pregunta8 = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    Clfc_Pregunta9 = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    Clfc_Pregunta10 = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    Clfc_Pregunta11 = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    Clfc_Pregunta12 = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    Clfc_Pregunta13 = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    Clfc_Pregunta14 = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    Clfc_Pregunta15 = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    Clfc_Pregunta16 = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    Clfc_Pregunta17 = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    Clfc_Pregunta18 = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    Clfc_Pregunta19 = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    Clfc_Pregunta20 = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    Clfc_Pregunta21 = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    Clfc_Pregunta22 = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    Clfc_Pregunta23 = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    Clfc_Pregunta24 = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    Clfc_Pregunta25 = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    Clfc_Pregunta26 = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    Clfc_Pregunta27 = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    Clfc_Pregunta28 = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    Clfc_Pregunta29 = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    Clfc_Pregunta30 = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    Clfc_Pregunta31 = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    Clfc_Pregunta32 = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    Clfc_Pregunta33 = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    Clfc_Pregunta34 = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    Clfc_Pregunta35 = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    Clfc_Pregunta36 = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    Clfc_Pregunta37 = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    Clfc_Pregunta38 = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    Clfc_Pregunta39 = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    Clfc_Pregunta40 = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    Clfc_Pregunta41 = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    Clfc_Pregunta42 = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    Clfc_Pregunta43 = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    Clfc_Pregunta44 = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    Clfc_Pregunta45 = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    Clfc_Pregunta46 = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    Clfc_Pregunta47 = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    Clfc_Pregunta48 = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    Clfc_Pregunta49 = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    Clfc_Pregunta50 = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    Clfc_Pregunta51 = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    Clfc_Pregunta52 = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    Observacion_id = table.Column<int>(type: "integer", nullable: false),
                    Fecha_Creacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuariosModelId_Usuario = table.Column<int>(type: "integer", nullable: false),
                    ColaboradorModelId_Colaborador = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluacion", x => x.Id_Evaluacion);
                    table.ForeignKey(
                        name: "FK_Evaluacion_Colaborador_ColaboradorModelId_Colaborador",
                        column: x => x.ColaboradorModelId_Colaborador,
                        principalTable: "Colaborador",
                        principalColumn: "Id_Colaborador",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Evaluacion_Usuarios_UsuariosModelId_Usuario",
                        column: x => x.UsuariosModelId_Usuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id_Usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PreguntasByEvaluacion",
                columns: table => new
                {
                    Id_Preguntas_Tipo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Tipo_Evaluacion_Id = table.Column<int>(type: "integer", nullable: false),
                    Modulo_Id = table.Column<int>(type: "integer", nullable: false),
                    Pregunta = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: false),
                    Numero_Pregunta = table.Column<int>(type: "integer", nullable: false),
                    Fecha_Creacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModuloEvaluacionModelId_Modulo_Evaluacion = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreguntasByEvaluacion", x => x.Id_Preguntas_Tipo);
                    table.ForeignKey(
                        name: "FK_PreguntasByEvaluacion_ModuloEvaluacion_ModuloEvaluacionMode~",
                        column: x => x.ModuloEvaluacionModelId_Modulo_Evaluacion,
                        principalTable: "ModuloEvaluacion",
                        principalColumn: "Id_Modulo_Evaluacion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PreguntasByEvaluacion_Tipo_Evaluacion_Tipo_Evaluacion_Id",
                        column: x => x.Tipo_Evaluacion_Id,
                        principalTable: "Tipo_Evaluacion",
                        principalColumn: "Id_Tipo_Evaluacion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ObservacionEvaluacion",
                columns: table => new
                {
                    Id_Observacion = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Evaluacion_id = table.Column<int>(type: "integer", nullable: false),
                    Observacion1 = table.Column<string>(type: "text", nullable: true),
                    Observacion2 = table.Column<string>(type: "text", nullable: true),
                    Observacion3 = table.Column<string>(type: "text", nullable: true),
                    Observacion4 = table.Column<string>(type: "text", nullable: true),
                    Observacion5 = table.Column<string>(type: "text", nullable: true),
                    Observacion6 = table.Column<string>(type: "text", nullable: true),
                    Observacion7 = table.Column<string>(type: "text", nullable: true),
                    Observacion8 = table.Column<string>(type: "text", nullable: true),
                    Observacion9 = table.Column<string>(type: "text", nullable: true),
                    Observacion10 = table.Column<string>(type: "text", nullable: true),
                    Observacion11 = table.Column<string>(type: "text", nullable: true),
                    Observacion12 = table.Column<string>(type: "text", nullable: true),
                    Observacion13 = table.Column<string>(type: "text", nullable: true),
                    Observacion14 = table.Column<string>(type: "text", nullable: true),
                    Observacion15 = table.Column<string>(type: "text", nullable: true),
                    Observacion16 = table.Column<string>(type: "text", nullable: true),
                    Observacion17 = table.Column<string>(type: "text", nullable: true),
                    Observacion18 = table.Column<string>(type: "text", nullable: true),
                    Observacion19 = table.Column<string>(type: "text", nullable: true),
                    Observacion20 = table.Column<string>(type: "text", nullable: true),
                    Observacion21 = table.Column<string>(type: "text", nullable: true),
                    Observacion22 = table.Column<string>(type: "text", nullable: true),
                    Observacion23 = table.Column<string>(type: "text", nullable: true),
                    Observacion24 = table.Column<string>(type: "text", nullable: true),
                    Observacion25 = table.Column<string>(type: "text", nullable: true),
                    Observacion26 = table.Column<string>(type: "text", nullable: true),
                    Observacion27 = table.Column<string>(type: "text", nullable: true),
                    Observacion28 = table.Column<string>(type: "text", nullable: true),
                    Observacion29 = table.Column<string>(type: "text", nullable: true),
                    Observacion30 = table.Column<string>(type: "text", nullable: true),
                    Observacion31 = table.Column<string>(type: "text", nullable: true),
                    Observacion32 = table.Column<string>(type: "text", nullable: true),
                    Observacion33 = table.Column<string>(type: "text", nullable: true),
                    Observacion34 = table.Column<string>(type: "text", nullable: true),
                    Observacion35 = table.Column<string>(type: "text", nullable: true),
                    Observacion36 = table.Column<string>(type: "text", nullable: true),
                    Observacion37 = table.Column<string>(type: "text", nullable: true),
                    Observacion38 = table.Column<string>(type: "text", nullable: true),
                    Observacion39 = table.Column<string>(type: "text", nullable: true),
                    Observacion40 = table.Column<string>(type: "text", nullable: true),
                    Observacion41 = table.Column<string>(type: "text", nullable: true),
                    Observacion42 = table.Column<string>(type: "text", nullable: true),
                    Observacion43 = table.Column<string>(type: "text", nullable: true),
                    Observacion44 = table.Column<string>(type: "text", nullable: true),
                    Observacion45 = table.Column<string>(type: "text", nullable: true),
                    Observacion46 = table.Column<string>(type: "text", nullable: true),
                    Observacion47 = table.Column<string>(type: "text", nullable: true),
                    Observacion48 = table.Column<string>(type: "text", nullable: true),
                    Observacion49 = table.Column<string>(type: "text", nullable: true),
                    Observacion50 = table.Column<string>(type: "text", nullable: true),
                    Observacion51 = table.Column<string>(type: "text", nullable: true),
                    Observacion52 = table.Column<string>(type: "text", nullable: true),
                    Fecha_Creacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
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
                name: "IX_Evaluacion_ColaboradorModelId_Colaborador",
                table: "Evaluacion",
                column: "ColaboradorModelId_Colaborador");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluacion_UsuariosModelId_Usuario",
                table: "Evaluacion",
                column: "UsuariosModelId_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_ModuloEvaluacion_TipoCompetenciaId_Tipo_Competencia",
                table: "ModuloEvaluacion",
                column: "TipoCompetenciaId_Tipo_Competencia");

            migrationBuilder.CreateIndex(
                name: "IX_ModuloEvaluacion_TipoEvaluacionModelId_Tipo_Evaluacion",
                table: "ModuloEvaluacion",
                column: "TipoEvaluacionModelId_Tipo_Evaluacion");

            migrationBuilder.CreateIndex(
                name: "IX_ObservacionEvaluacion_Evaluacion_id",
                table: "ObservacionEvaluacion",
                column: "Evaluacion_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PreguntasByEvaluacion_ModuloEvaluacionModelId_Modulo_Evalua~",
                table: "PreguntasByEvaluacion",
                column: "ModuloEvaluacionModelId_Modulo_Evaluacion");

            migrationBuilder.CreateIndex(
                name: "IX_PreguntasByEvaluacion_Tipo_Evaluacion_Id",
                table: "PreguntasByEvaluacion",
                column: "Tipo_Evaluacion_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RolesModelId_Rol",
                table: "Usuarios",
                column: "RolesModelId_Rol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cargos");

            migrationBuilder.DropTable(
                name: "ObservacionEvaluacion");

            migrationBuilder.DropTable(
                name: "PreguntasByEvaluacion");

            migrationBuilder.DropTable(
                name: "PreguntasModuloCargo");

            migrationBuilder.DropTable(
                name: "ProcesosEvaluacion");

            migrationBuilder.DropTable(
                name: "Evaluacion");

            migrationBuilder.DropTable(
                name: "ModuloEvaluacion");

            migrationBuilder.DropTable(
                name: "Colaborador");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "TipoCompetencia");

            migrationBuilder.DropTable(
                name: "Tipo_Evaluacion");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
