﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using apiprueba;

#nullable disable

namespace apiprueba.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230813063928_ProcesosEvaluacionTable")]
    partial class ProcesosEvaluacionTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("apiprueba.Models.CargosModel", b =>
                {
                    b.Property<int>("Id_Cargo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Cargo"));

                    b.Property<string>("Nombre_Cargo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Cargo");

                    b.ToTable("Cargos");
                });

            modelBuilder.Entity("apiprueba.Models.ColaboradorModel", b =>
                {
                    b.Property<int>("Id_Colaborador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Colaborador"));

                    b.Property<string>("Area")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CC")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Cargo_Colaborador")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cargo_Evaluador")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Cargo_Id")
                        .HasColumnType("int");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Cedula_Evaluador")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Departamento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<DateTime>("Fe_Ingreso_Colaborador")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Fe_Ingreso_Evaluador")
                        .HasColumnType("datetime2");

                    b.Property<string>("Grupo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Localidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Nombres_Evaluador")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zona")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Colaborador");

                    b.ToTable("Colaborador");
                });

            modelBuilder.Entity("apiprueba.Models.EvaluacionModel", b =>
                {
                    b.Property<int>("Id_Evaluacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Evaluacion"));

                    b.Property<decimal?>("CalificacionFinal")
                        .HasColumnType("decimal(4, 2)")
                        .HasColumnOrder(5);

                    b.Property<decimal?>("Clfc_Pregunta1")
                        .HasColumnType("decimal(4, 2)")
                        .HasColumnOrder(6);

                    b.Property<decimal?>("Clfc_Pregunta10")
                        .HasColumnType("decimal(4, 2)")
                        .HasColumnOrder(15);

                    b.Property<decimal?>("Clfc_Pregunta11")
                        .HasColumnType("decimal(4, 2)")
                        .HasColumnOrder(16);

                    b.Property<decimal?>("Clfc_Pregunta12")
                        .HasColumnType("decimal(4, 2)")
                        .HasColumnOrder(17);

                    b.Property<decimal?>("Clfc_Pregunta13")
                        .HasColumnType("decimal(4, 2)")
                        .HasColumnOrder(18);

                    b.Property<decimal?>("Clfc_Pregunta14")
                        .HasColumnType("decimal(4, 2)")
                        .HasColumnOrder(19);

                    b.Property<decimal?>("Clfc_Pregunta15")
                        .HasColumnType("decimal(4, 2)")
                        .HasColumnOrder(20);

                    b.Property<decimal?>("Clfc_Pregunta16")
                        .HasColumnType("decimal(4, 2)")
                        .HasColumnOrder(21);

                    b.Property<decimal?>("Clfc_Pregunta17")
                        .HasColumnType("decimal(4, 2)")
                        .HasColumnOrder(22);

                    b.Property<decimal?>("Clfc_Pregunta18")
                        .HasColumnType("decimal(4, 2)")
                        .HasColumnOrder(23);

                    b.Property<decimal?>("Clfc_Pregunta19")
                        .HasColumnType("decimal(4, 2)")
                        .HasColumnOrder(24);

                    b.Property<decimal?>("Clfc_Pregunta2")
                        .HasColumnType("decimal(4, 2)")
                        .HasColumnOrder(7);

                    b.Property<decimal?>("Clfc_Pregunta20")
                        .HasColumnType("decimal(4, 2)")
                        .HasColumnOrder(25);

                    b.Property<decimal?>("Clfc_Pregunta21")
                        .HasColumnType("decimal(4, 2)")
                        .HasColumnOrder(26);

                    b.Property<decimal?>("Clfc_Pregunta22")
                        .HasColumnType("decimal(4, 2)")
                        .HasColumnOrder(27);

                    b.Property<decimal?>("Clfc_Pregunta23")
                        .HasColumnType("decimal(4, 2)")
                        .HasColumnOrder(28);

                    b.Property<decimal?>("Clfc_Pregunta24")
                        .HasColumnType("decimal(4, 2)")
                        .HasColumnOrder(29);

                    b.Property<decimal?>("Clfc_Pregunta25")
                        .HasColumnType("decimal(4, 2)")
                        .HasColumnOrder(30);

                    b.Property<decimal?>("Clfc_Pregunta26")
                        .HasColumnType("decimal(4, 2)")
                        .HasColumnOrder(31);

                    b.Property<decimal?>("Clfc_Pregunta27")
                        .HasColumnType("decimal(4, 2)")
                        .HasColumnOrder(32);

                    b.Property<decimal?>("Clfc_Pregunta28")
                        .HasColumnType("decimal(4, 2)")
                        .HasColumnOrder(33);

                    b.Property<decimal?>("Clfc_Pregunta29")
                        .HasColumnType("decimal(4, 2)")
                        .HasColumnOrder(34);

                    b.Property<decimal?>("Clfc_Pregunta3")
                        .HasColumnType("decimal(4, 2)")
                        .HasColumnOrder(8);

                    b.Property<decimal?>("Clfc_Pregunta30")
                        .HasColumnType("decimal(4, 2)")
                        .HasColumnOrder(35);

                    b.Property<decimal?>("Clfc_Pregunta31")
                        .HasColumnType("decimal(4, 2)")
                        .HasColumnOrder(36);

                    b.Property<decimal?>("Clfc_Pregunta32")
                        .HasColumnType("decimal(4, 2)")
                        .HasColumnOrder(37);

                    b.Property<decimal?>("Clfc_Pregunta33")
                        .HasColumnType("decimal(4, 2)")
                        .HasColumnOrder(38);

                    b.Property<decimal?>("Clfc_Pregunta34")
                        .HasColumnType("decimal(4, 2)")
                        .HasColumnOrder(39);

                    b.Property<decimal?>("Clfc_Pregunta35")
                        .HasColumnType("decimal(4, 2)")
                        .HasColumnOrder(40);

                    b.Property<decimal?>("Clfc_Pregunta36")
                        .HasColumnType("decimal(4, 2)")
                        .HasColumnOrder(41);

                    b.Property<decimal?>("Clfc_Pregunta37")
                        .HasColumnType("decimal(4, 2)")
                        .HasColumnOrder(42);

                    b.Property<decimal?>("Clfc_Pregunta38")
                        .HasColumnType("decimal(4, 2)")
                        .HasColumnOrder(43);

                    b.Property<decimal?>("Clfc_Pregunta39")
                        .HasColumnType("decimal(4, 2)")
                        .HasColumnOrder(44);

                    b.Property<decimal?>("Clfc_Pregunta4")
                        .HasColumnType("decimal(4, 2)")
                        .HasColumnOrder(9);

                    b.Property<decimal?>("Clfc_Pregunta40")
                        .HasColumnType("decimal(4, 2)")
                        .HasColumnOrder(45);

                    b.Property<decimal?>("Clfc_Pregunta41")
                        .HasColumnType("decimal(4, 2)")
                        .HasColumnOrder(46);

                    b.Property<decimal?>("Clfc_Pregunta42")
                        .HasColumnType("decimal(4, 2)")
                        .HasColumnOrder(47);

                    b.Property<decimal?>("Clfc_Pregunta43")
                        .HasColumnType("decimal(4, 2)")
                        .HasColumnOrder(48);

                    b.Property<decimal?>("Clfc_Pregunta44")
                        .HasColumnType("decimal(4, 2)")
                        .HasColumnOrder(49);

                    b.Property<decimal?>("Clfc_Pregunta45")
                        .HasColumnType("decimal(4, 2)")
                        .HasColumnOrder(50);

                    b.Property<decimal?>("Clfc_Pregunta46")
                        .HasColumnType("decimal(4, 2)")
                        .HasColumnOrder(51);

                    b.Property<decimal?>("Clfc_Pregunta47")
                        .HasColumnType("decimal(4, 2)")
                        .HasColumnOrder(52);

                    b.Property<decimal?>("Clfc_Pregunta48")
                        .HasColumnType("decimal(4, 2)")
                        .HasColumnOrder(53);

                    b.Property<decimal?>("Clfc_Pregunta49")
                        .HasColumnType("decimal(4, 2)")
                        .HasColumnOrder(54);

                    b.Property<decimal?>("Clfc_Pregunta5")
                        .HasColumnType("decimal(4, 2)")
                        .HasColumnOrder(10);

                    b.Property<decimal?>("Clfc_Pregunta50")
                        .HasColumnType("decimal(4, 2)")
                        .HasColumnOrder(55);

                    b.Property<decimal?>("Clfc_Pregunta51")
                        .HasColumnType("decimal(4, 2)")
                        .HasColumnOrder(56);

                    b.Property<decimal?>("Clfc_Pregunta52")
                        .HasColumnType("decimal(4, 2)")
                        .HasColumnOrder(57);

                    b.Property<decimal?>("Clfc_Pregunta6")
                        .HasColumnType("decimal(4, 2)")
                        .HasColumnOrder(11);

                    b.Property<decimal?>("Clfc_Pregunta7")
                        .HasColumnType("decimal(4, 2)")
                        .HasColumnOrder(12);

                    b.Property<decimal?>("Clfc_Pregunta8")
                        .HasColumnType("decimal(4, 2)")
                        .HasColumnOrder(13);

                    b.Property<decimal?>("Clfc_Pregunta9")
                        .HasColumnType("decimal(4, 2)")
                        .HasColumnOrder(14);

                    b.Property<int>("ColaboradorModelId_Colaborador")
                        .HasColumnType("int");

                    b.Property<int>("Colaborador_id")
                        .HasColumnType("int")
                        .HasColumnOrder(3);

                    b.Property<string>("Estado")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)")
                        .HasColumnOrder(4);

                    b.Property<DateTime>("Fecha_Creacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("Observacion_id")
                        .HasColumnType("int");

                    b.Property<int>("Usuario_id")
                        .HasColumnType("int")
                        .HasColumnOrder(2);

                    b.Property<int>("UsuariosModelId_Usuario")
                        .HasColumnType("int");

                    b.HasKey("Id_Evaluacion");

                    b.HasIndex("ColaboradorModelId_Colaborador");

                    b.HasIndex("UsuariosModelId_Usuario");

                    b.ToTable("Evaluacion");
                });

            modelBuilder.Entity("apiprueba.Models.FechaProcesosEvaluacionModel", b =>
                {
                    b.Property<int>("Id_Proceso_Evaluacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Proceso_Evaluacion"));

                    b.Property<DateTime>("Fecha_Fin")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(3);

                    b.Property<DateTime>("Fecha_Inicio")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(2);

                    b.HasKey("Id_Proceso_Evaluacion");

                    b.ToTable("ProcesosEvaluacion");
                });

            modelBuilder.Entity("apiprueba.Models.ModuloEvaluacionModel", b =>
                {
                    b.Property<int>("Id_Modulo_Evaluacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Modulo_Evaluacion"));

                    b.Property<string>("Definicion")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("Fecha_Creacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre_Modulo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("TipoCompetenciaId_Tipo_Competencia")
                        .HasColumnType("int");

                    b.Property<int>("TipoEvaluacionModelId_Tipo_Evaluacion")
                        .HasColumnType("int");

                    b.Property<int>("Tipo_Competencia_Id")
                        .HasColumnType("int");

                    b.Property<int>("Tipo_Evaluacion_Id")
                        .HasColumnType("int");

                    b.HasKey("Id_Modulo_Evaluacion");

                    b.HasIndex("TipoCompetenciaId_Tipo_Competencia");

                    b.HasIndex("TipoEvaluacionModelId_Tipo_Evaluacion");

                    b.ToTable("ModuloEvaluacion");
                });

            modelBuilder.Entity("apiprueba.Models.ObservacionModel", b =>
                {
                    b.Property<int>("Id_Observacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Observacion"));

                    b.Property<int>("Evaluacion_id")
                        .HasColumnType("int")
                        .HasColumnOrder(2);

                    b.Property<DateTime>("Fecha_Creacion")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(55);

                    b.Property<string>("Observacion1")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(3);

                    b.Property<string>("Observacion10")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(12);

                    b.Property<string>("Observacion11")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(13);

                    b.Property<string>("Observacion12")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(14);

                    b.Property<string>("Observacion13")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(15);

                    b.Property<string>("Observacion14")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(16);

                    b.Property<string>("Observacion15")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(17);

                    b.Property<string>("Observacion16")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(18);

                    b.Property<string>("Observacion17")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(19);

                    b.Property<string>("Observacion18")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(20);

                    b.Property<string>("Observacion19")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(21);

                    b.Property<string>("Observacion2")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(4);

                    b.Property<string>("Observacion20")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(22);

                    b.Property<string>("Observacion21")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(23);

                    b.Property<string>("Observacion22")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(24);

                    b.Property<string>("Observacion23")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(25);

                    b.Property<string>("Observacion24")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(26);

                    b.Property<string>("Observacion25")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(27);

                    b.Property<string>("Observacion26")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(28);

                    b.Property<string>("Observacion27")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(29);

                    b.Property<string>("Observacion28")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(30);

                    b.Property<string>("Observacion29")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(31);

                    b.Property<string>("Observacion3")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(5);

                    b.Property<string>("Observacion30")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(32);

                    b.Property<string>("Observacion31")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(33);

                    b.Property<string>("Observacion32")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(34);

                    b.Property<string>("Observacion33")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(35);

                    b.Property<string>("Observacion34")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(36);

                    b.Property<string>("Observacion35")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(37);

                    b.Property<string>("Observacion36")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(38);

                    b.Property<string>("Observacion37")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(39);

                    b.Property<string>("Observacion38")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(40);

                    b.Property<string>("Observacion39")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(41);

                    b.Property<string>("Observacion4")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(6);

                    b.Property<string>("Observacion40")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(42);

                    b.Property<string>("Observacion41")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(43);

                    b.Property<string>("Observacion42")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(44);

                    b.Property<string>("Observacion43")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(45);

                    b.Property<string>("Observacion44")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(46);

                    b.Property<string>("Observacion45")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(47);

                    b.Property<string>("Observacion46")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(48);

                    b.Property<string>("Observacion47")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(49);

                    b.Property<string>("Observacion48")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(50);

                    b.Property<string>("Observacion49")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(51);

                    b.Property<string>("Observacion5")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(7);

                    b.Property<string>("Observacion50")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(52);

                    b.Property<string>("Observacion51")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(53);

                    b.Property<string>("Observacion52")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(54);

                    b.Property<string>("Observacion6")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(8);

                    b.Property<string>("Observacion7")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(9);

                    b.Property<string>("Observacion8")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(10);

                    b.Property<string>("Observacion9")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(11);

                    b.HasKey("Id_Observacion");

                    b.HasIndex("Evaluacion_id")
                        .IsUnique();

                    b.ToTable("ObservacionEvaluacion");
                });

            modelBuilder.Entity("apiprueba.Models.PreguntasByEvaluacionModel", b =>
                {
                    b.Property<int>("Id_Preguntas_Tipo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Preguntas_Tipo"));

                    b.Property<DateTime>("Fecha_Creacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModuloEvaluacionModelId_Modulo_Evaluacion")
                        .HasColumnType("int");

                    b.Property<int>("Modulo_Id")
                        .HasColumnType("int")
                        .HasColumnOrder(4);

                    b.Property<int>("Numero_Pregunta")
                        .HasColumnType("int")
                        .HasColumnOrder(6);

                    b.Property<string>("Pregunta")
                        .IsRequired()
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)")
                        .HasColumnOrder(5);

                    b.Property<int>("Tipo_Evaluacion_Id")
                        .HasColumnType("int")
                        .HasColumnOrder(3);

                    b.HasKey("Id_Preguntas_Tipo");

                    b.HasIndex("ModuloEvaluacionModelId_Modulo_Evaluacion");

                    b.HasIndex("Tipo_Evaluacion_Id");

                    b.ToTable("PreguntasByEvaluacion");
                });

            modelBuilder.Entity("apiprueba.Models.PreguntasModuloCargo", b =>
                {
                    b.Property<int>("Id_PreguntaModuloCargo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_PreguntaModuloCargo"));

                    b.Property<int>("Cargo_Id")
                        .HasColumnType("int");

                    b.Property<int>("Modulo_Id")
                        .HasColumnType("int");

                    b.Property<int>("Tipo_Evaluacion_Id")
                        .HasColumnType("int");

                    b.HasKey("Id_PreguntaModuloCargo");

                    b.ToTable("PreguntasModuloCargo");
                });

            modelBuilder.Entity("apiprueba.Models.RolesModel", b =>
                {
                    b.Property<int>("Id_Rol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Rol"));

                    b.Property<DateTime>("Fecha_Creacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre_Rol")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id_Rol");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("apiprueba.Models.TipoCompetenciaModel", b =>
                {
                    b.Property<int>("Id_Tipo_Competencia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Tipo_Competencia"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)")
                        .HasColumnOrder(2);

                    b.HasKey("Id_Tipo_Competencia");

                    b.ToTable("TipoCompetencia");
                });

            modelBuilder.Entity("apiprueba.Models.TipoEvaluacionModel", b =>
                {
                    b.Property<int>("Id_Tipo_Evaluacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Tipo_Evaluacion"));

                    b.Property<DateTime>("Fecha_Creacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre_Tipo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id_Tipo_Evaluacion");

                    b.ToTable("Tipo_Evaluacion");
                });

            modelBuilder.Entity("apiprueba.Models.UsuariosModel", b =>
                {
                    b.Property<int>("Id_Usuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Usuario"));

                    b.Property<int?>("CargosModelId_Cargo")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha_Creacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Identificacion")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<int>("Rol_Id")
                        .HasColumnType("int");

                    b.Property<int>("RolesModelId_Rol")
                        .HasColumnType("int");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id_Usuario");

                    b.HasIndex("CargosModelId_Cargo");

                    b.HasIndex("RolesModelId_Rol");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("apiprueba.Models.EvaluacionModel", b =>
                {
                    b.HasOne("apiprueba.Models.ColaboradorModel", "ColaboradorModel")
                        .WithMany("Evaluacion")
                        .HasForeignKey("ColaboradorModelId_Colaborador")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("apiprueba.Models.UsuariosModel", "UsuariosModel")
                        .WithMany("Evaluacion")
                        .HasForeignKey("UsuariosModelId_Usuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ColaboradorModel");

                    b.Navigation("UsuariosModel");
                });

            modelBuilder.Entity("apiprueba.Models.ModuloEvaluacionModel", b =>
                {
                    b.HasOne("apiprueba.Models.TipoCompetenciaModel", "TipoCompetencia")
                        .WithMany("ModuloEvaluacion")
                        .HasForeignKey("TipoCompetenciaId_Tipo_Competencia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("apiprueba.Models.TipoEvaluacionModel", "TipoEvaluacionModel")
                        .WithMany("ModuloEvaluacionModel")
                        .HasForeignKey("TipoEvaluacionModelId_Tipo_Evaluacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoCompetencia");

                    b.Navigation("TipoEvaluacionModel");
                });

            modelBuilder.Entity("apiprueba.Models.ObservacionModel", b =>
                {
                    b.HasOne("apiprueba.Models.EvaluacionModel", "EvaluacionModel")
                        .WithOne("ObservacionModel")
                        .HasForeignKey("apiprueba.Models.ObservacionModel", "Evaluacion_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EvaluacionModel");
                });

            modelBuilder.Entity("apiprueba.Models.PreguntasByEvaluacionModel", b =>
                {
                    b.HasOne("apiprueba.Models.ModuloEvaluacionModel", "ModuloEvaluacionModel")
                        .WithMany("PreguntasByEvaluacion")
                        .HasForeignKey("ModuloEvaluacionModelId_Modulo_Evaluacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("apiprueba.Models.TipoEvaluacionModel", "TipoEvaluacionModel")
                        .WithMany("PreguntasByEvaluacionModel")
                        .HasForeignKey("Tipo_Evaluacion_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ModuloEvaluacionModel");

                    b.Navigation("TipoEvaluacionModel");
                });

            modelBuilder.Entity("apiprueba.Models.UsuariosModel", b =>
                {
                    b.HasOne("apiprueba.Models.CargosModel", null)
                        .WithMany("UsuariosModel")
                        .HasForeignKey("CargosModelId_Cargo");

                    b.HasOne("apiprueba.Models.RolesModel", "RolesModel")
                        .WithMany()
                        .HasForeignKey("RolesModelId_Rol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RolesModel");
                });

            modelBuilder.Entity("apiprueba.Models.CargosModel", b =>
                {
                    b.Navigation("UsuariosModel");
                });

            modelBuilder.Entity("apiprueba.Models.ColaboradorModel", b =>
                {
                    b.Navigation("Evaluacion");
                });

            modelBuilder.Entity("apiprueba.Models.EvaluacionModel", b =>
                {
                    b.Navigation("ObservacionModel")
                        .IsRequired();
                });

            modelBuilder.Entity("apiprueba.Models.ModuloEvaluacionModel", b =>
                {
                    b.Navigation("PreguntasByEvaluacion");
                });

            modelBuilder.Entity("apiprueba.Models.TipoCompetenciaModel", b =>
                {
                    b.Navigation("ModuloEvaluacion");
                });

            modelBuilder.Entity("apiprueba.Models.TipoEvaluacionModel", b =>
                {
                    b.Navigation("ModuloEvaluacionModel");

                    b.Navigation("PreguntasByEvaluacionModel");
                });

            modelBuilder.Entity("apiprueba.Models.UsuariosModel", b =>
                {
                    b.Navigation("Evaluacion");
                });
#pragma warning restore 612, 618
        }
    }
}
