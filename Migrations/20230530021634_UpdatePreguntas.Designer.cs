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
    [Migration("20230530021634_UpdatePreguntas")]
    partial class UpdatePreguntas
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("apiprueba.Models.ColaboradorModel", b =>
                {
                    b.Property<int>("Id_Colaborador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Colaborador"));

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

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

                    b.Property<decimal?>("Clfc_Pregunta4")
                        .HasColumnType("decimal(4, 2)")
                        .HasColumnOrder(9);

                    b.Property<decimal?>("Clfc_Pregunta5")
                        .HasColumnType("decimal(4, 2)")
                        .HasColumnOrder(10);

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

                    b.Property<DateTime>("Fecha_Creacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("PreguntasByEvaluacionModelId_Preguntas_Tipo")
                        .HasColumnType("int");

                    b.Property<int>("Preguntas_Tipo_id")
                        .HasColumnType("int")
                        .HasColumnOrder(4);

                    b.Property<int>("Usuario_id")
                        .HasColumnType("int")
                        .HasColumnOrder(2);

                    b.Property<int>("UsuariosModelId_Usuario")
                        .HasColumnType("int");

                    b.HasKey("Id_Evaluacion");

                    b.HasIndex("ColaboradorModelId_Colaborador");

                    b.HasIndex("PreguntasByEvaluacionModelId_Preguntas_Tipo");

                    b.HasIndex("UsuariosModelId_Usuario");

                    b.ToTable("Evaluacion");
                });

            modelBuilder.Entity("apiprueba.Models.ModuloEvaluacionModel", b =>
                {
                    b.Property<int>("Id_Modulo_Evaluacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Modulo_Evaluacion"));

                    b.Property<string>("Definicion")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<DateTime>("Fecha_Creacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre_Modulo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id_Modulo_Evaluacion");

                    b.ToTable("ModuloEvaluacion");
                });

            modelBuilder.Entity("apiprueba.Models.PreguntasByEvaluacionModel", b =>
                {
                    b.Property<int>("Id_Preguntas_Tipo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Preguntas_Tipo"));

                    b.Property<DateTime>("Fecha_Creacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModuloEvaluacionModelId_Modulo_Evaluacion")
                        .HasColumnType("int");

                    b.Property<int>("Modulo_Id")
                        .HasColumnType("int")
                        .HasColumnOrder(4);

                    b.Property<string>("Pregunta1")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnOrder(5);

                    b.Property<string>("Pregunta10")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnOrder(14);

                    b.Property<string>("Pregunta11")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnOrder(15);

                    b.Property<string>("Pregunta12")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnOrder(16);

                    b.Property<string>("Pregunta13")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnOrder(17);

                    b.Property<string>("Pregunta14")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnOrder(18);

                    b.Property<string>("Pregunta15")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnOrder(19);

                    b.Property<string>("Pregunta16")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnOrder(20);

                    b.Property<string>("Pregunta17")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnOrder(21);

                    b.Property<string>("Pregunta18")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnOrder(22);

                    b.Property<string>("Pregunta19")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnOrder(23);

                    b.Property<string>("Pregunta2")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnOrder(6);

                    b.Property<string>("Pregunta20")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnOrder(24);

                    b.Property<string>("Pregunta21")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnOrder(25);

                    b.Property<string>("Pregunta22")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnOrder(26);

                    b.Property<string>("Pregunta23")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnOrder(27);

                    b.Property<string>("Pregunta24")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnOrder(28);

                    b.Property<string>("Pregunta25")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnOrder(29);

                    b.Property<string>("Pregunta26")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnOrder(30);

                    b.Property<string>("Pregunta27")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnOrder(31);

                    b.Property<string>("Pregunta28")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnOrder(32);

                    b.Property<string>("Pregunta29")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnOrder(33);

                    b.Property<string>("Pregunta3")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnOrder(7);

                    b.Property<string>("Pregunta30")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnOrder(34);

                    b.Property<string>("Pregunta4")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnOrder(8);

                    b.Property<string>("Pregunta5")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnOrder(9);

                    b.Property<string>("Pregunta6")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnOrder(10);

                    b.Property<string>("Pregunta7")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnOrder(11);

                    b.Property<string>("Pregunta8")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnOrder(12);

                    b.Property<string>("Pregunta9")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnOrder(13);

                    b.Property<int>("Pregunta_Id")
                        .HasColumnType("int")
                        .HasColumnOrder(2);

                    b.Property<int>("TipoEvaluacionModelId_Tipo_Evaluacion")
                        .HasColumnType("int");

                    b.Property<int>("Tipo_Evaluacion_Id")
                        .HasColumnType("int")
                        .HasColumnOrder(3);

                    b.HasKey("Id_Preguntas_Tipo");

                    b.HasIndex("ModuloEvaluacionModelId_Modulo_Evaluacion");

                    b.HasIndex("TipoEvaluacionModelId_Tipo_Evaluacion");

                    b.ToTable("PreguntasByEvaluacion");
                });

            modelBuilder.Entity("apiprueba.Models.RolesModel", b =>
                {
                    b.Property<int>("Id_Rol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Rol"));

                    b.Property<DateTime>("Fecha_Creacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id_Usuario")
                        .HasColumnType("int");

                    b.Property<string>("Nombre_Rol")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id_Rol");

                    b.HasIndex("Id_Usuario")
                        .IsUnique();

                    b.ToTable("Roles");
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

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id_Usuario");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("apiprueba.Models.EvaluacionModel", b =>
                {
                    b.HasOne("apiprueba.Models.ColaboradorModel", "ColaboradorModel")
                        .WithMany("Evaluacion")
                        .HasForeignKey("ColaboradorModelId_Colaborador")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("apiprueba.Models.PreguntasByEvaluacionModel", "PreguntasByEvaluacionModel")
                        .WithMany("Evaluacion")
                        .HasForeignKey("PreguntasByEvaluacionModelId_Preguntas_Tipo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("apiprueba.Models.UsuariosModel", "UsuariosModel")
                        .WithMany("Evaluacion")
                        .HasForeignKey("UsuariosModelId_Usuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ColaboradorModel");

                    b.Navigation("PreguntasByEvaluacionModel");

                    b.Navigation("UsuariosModel");
                });

            modelBuilder.Entity("apiprueba.Models.PreguntasByEvaluacionModel", b =>
                {
                    b.HasOne("apiprueba.Models.ModuloEvaluacionModel", "ModuloEvaluacionModel")
                        .WithMany("PreguntasByEvaluacion")
                        .HasForeignKey("ModuloEvaluacionModelId_Modulo_Evaluacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("apiprueba.Models.TipoEvaluacionModel", "TipoEvaluacionModel")
                        .WithMany("PreguntasByEvaluacion")
                        .HasForeignKey("TipoEvaluacionModelId_Tipo_Evaluacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ModuloEvaluacionModel");

                    b.Navigation("TipoEvaluacionModel");
                });

            modelBuilder.Entity("apiprueba.Models.ColaboradorModel", b =>
                {
                    b.Navigation("Evaluacion");
                });

            modelBuilder.Entity("apiprueba.Models.ModuloEvaluacionModel", b =>
                {
                    b.Navigation("PreguntasByEvaluacion");
                });

            modelBuilder.Entity("apiprueba.Models.PreguntasByEvaluacionModel", b =>
                {
                    b.Navigation("Evaluacion");
                });

            modelBuilder.Entity("apiprueba.Models.TipoEvaluacionModel", b =>
                {
                    b.Navigation("PreguntasByEvaluacion");
                });

            modelBuilder.Entity("apiprueba.Models.UsuariosModel", b =>
                {
                    b.Navigation("Evaluacion");
                });
#pragma warning restore 612, 618
        }
    }
}
