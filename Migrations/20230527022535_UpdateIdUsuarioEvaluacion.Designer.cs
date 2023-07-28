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
    [Migration("20230527022535_UpdateIdUsuarioEvaluacion")]
    partial class UpdateIdUsuarioEvaluacion
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

                    b.Property<int>("ColaboradorModelId_Colaborador")
                        .HasColumnType("int");

                    b.Property<int>("Colaborador_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha_Creacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("PreguntasByEvaluacionModelId_Preguntas_Tipo")
                        .HasColumnType("int");

                    b.Property<int>("Preguntas_Tipo_id")
                        .HasColumnType("int");

                    b.Property<int>("Usuario_id")
                        .HasColumnType("int");

                    b.HasKey("Id_Evaluacion");

                    b.HasIndex("ColaboradorModelId_Colaborador");

                    b.HasIndex("PreguntasByEvaluacionModelId_Preguntas_Tipo");

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
                        .HasColumnType("int");

                    b.Property<int>("Pregunta_Id")
                        .HasColumnType("int");

                    b.Property<int?>("PreguntasEvaluacionModelId_Pregunta")
                        .HasColumnType("int");

                    b.Property<int>("TipoEvaluacionModelId_Tipo_Evaluacion")
                        .HasColumnType("int");

                    b.Property<int>("Tipo_Evaluacion_Id")
                        .HasColumnType("int");

                    b.HasKey("Id_Preguntas_Tipo");

                    b.HasIndex("ModuloEvaluacionModelId_Modulo_Evaluacion");

                    b.HasIndex("PreguntasEvaluacionModelId_Pregunta");

                    b.HasIndex("TipoEvaluacionModelId_Tipo_Evaluacion");

                    b.ToTable("PreguntasByEvaluacion");
                });

            modelBuilder.Entity("apiprueba.Models.PreguntasEvaluacionModel", b =>
                {
                    b.Property<int>("Id_Pregunta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Pregunta"));

                    b.Property<DateTime>("Fecha_Creacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Pregunta")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id_Pregunta");

                    b.ToTable("PreguntasEvaluacion");
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
                        .WithMany()
                        .HasForeignKey("ColaboradorModelId_Colaborador")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("apiprueba.Models.PreguntasByEvaluacionModel", "PreguntasByEvaluacionModel")
                        .WithMany("Evaluacion")
                        .HasForeignKey("PreguntasByEvaluacionModelId_Preguntas_Tipo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ColaboradorModel");

                    b.Navigation("PreguntasByEvaluacionModel");
                });

            modelBuilder.Entity("apiprueba.Models.PreguntasByEvaluacionModel", b =>
                {
                    b.HasOne("apiprueba.Models.ModuloEvaluacionModel", "ModuloEvaluacionModel")
                        .WithMany("PreguntasByEvaluacion")
                        .HasForeignKey("ModuloEvaluacionModelId_Modulo_Evaluacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("apiprueba.Models.PreguntasEvaluacionModel", null)
                        .WithMany("PreguntasByEvaluacion")
                        .HasForeignKey("PreguntasEvaluacionModelId_Pregunta");

                    b.HasOne("apiprueba.Models.TipoEvaluacionModel", "TipoEvaluacionModel")
                        .WithMany("PreguntasByEvaluacion")
                        .HasForeignKey("TipoEvaluacionModelId_Tipo_Evaluacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ModuloEvaluacionModel");

                    b.Navigation("TipoEvaluacionModel");
                });

            modelBuilder.Entity("apiprueba.Models.ModuloEvaluacionModel", b =>
                {
                    b.Navigation("PreguntasByEvaluacion");
                });

            modelBuilder.Entity("apiprueba.Models.PreguntasByEvaluacionModel", b =>
                {
                    b.Navigation("Evaluacion");
                });

            modelBuilder.Entity("apiprueba.Models.PreguntasEvaluacionModel", b =>
                {
                    b.Navigation("PreguntasByEvaluacion");
                });

            modelBuilder.Entity("apiprueba.Models.TipoEvaluacionModel", b =>
                {
                    b.Navigation("PreguntasByEvaluacion");
                });
#pragma warning restore 612, 618
        }
    }
}
