using Microsoft.EntityFrameworkCore;
using apiprueba.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apiprueba
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<UsuariosModel> Usuarios => Set<UsuariosModel>();
        public DbSet<ColaboradorModel> Colaborador => Set<ColaboradorModel>();
        public DbSet<RolesModel> Roles => Set<RolesModel>();
        public DbSet<TipoEvaluacionModel> Tipo_Evaluacion => Set<TipoEvaluacionModel>();
        public DbSet<EvaluacionModel> Evaluacion => Set<EvaluacionModel>();
        //public DbSet<PreguntasEvaluacionModel> PreguntasEvaluacion => Set<PreguntasEvaluacionModel>();
        public DbSet<ModuloEvaluacionModel> ModuloEvaluacion => Set<ModuloEvaluacionModel>();
        public DbSet<PreguntasByEvaluacionModel> PreguntasByEvaluacion => Set<PreguntasByEvaluacionModel>();
        public DbSet<ObservacionModel> ObservacionEvaluacion => Set<ObservacionModel>();

        public DbSet<CargosModel> Cargos => Set<CargosModel>();
        public DbSet<PreguntasModuloCargo> PreguntasModuloCargo => Set<PreguntasModuloCargo>();
        public DbSet<TipoCompetenciaModel> TipoCompetencia => Set<TipoCompetenciaModel>();

        public DbSet<FechaProcesosEvaluacionModel> ProcesosEvaluacion => Set<FechaProcesosEvaluacionModel>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var calificacionEvaluacionProperties = typeof(EvaluacionModel).GetProperties();

            foreach (var property in calificacionEvaluacionProperties)
            {
                if (property.PropertyType == typeof(decimal?))
                {
                    modelBuilder.Entity<EvaluacionModel>()
                        .Property(property.Name)
                        .HasColumnType("decimal(4, 2)");
                }
            }

            //modelBuilder.Entity<UsuariosModel>()
            //    .HasMany(u => u.TipoEvaluacionModel)
            //    .WithOne(tr => tr.UsuariosModel).IsRequired()
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<TipoEvaluacionModel>()
            //    .HasRequired(s => s.UsuariosModel)
            //    .WithMany()
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<UsuariosModel>()
            //     .HasOne(u => u.TipoEvaluacionModel)
            //     .HasForeignKey<UsuariosModel>(u => u.Tipo_Evaluacion_Id)
            //     .IsRequired()
            //     .OnDelete(DeleteBehavior.Restrict);



            //modelBuilder.Entity<UsuariosModel>()
            //    .HasOne(p => p.TipoEvaluacionModel)
            //    .WithMany(b => b.UsuariosModel)
            //    .HasForeignKey(p => p.Tipo_Evaluacion_Id)
            //    .IsRequired()
            //    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TipoEvaluacionModel>()
                .HasMany(b => b.PreguntasByEvaluacionModel)
                .WithOne(p => p.TipoEvaluacionModel)
                .HasForeignKey(p => p.Tipo_Evaluacion_Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ObservacionModel>()
            .HasOne(u => u.EvaluacionModel)
            .WithOne(p => p.ObservacionModel)
            .HasForeignKey<ObservacionModel>(p => p.Evaluacion_id);

            modelBuilder.Entity<TipoEvaluacionModel>()
                .HasMany(b => b.PreguntasByEvaluacionModel)
                .WithOne(p => p.TipoEvaluacionModel)
                .HasForeignKey(p => p.Tipo_Evaluacion_Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }

    }
}
