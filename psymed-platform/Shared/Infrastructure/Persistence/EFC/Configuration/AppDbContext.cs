using Microsoft.EntityFrameworkCore;
using psymed_platform.Shared.Infrastructure.Persistence.EFC.Configuration.Interceptors;
using static psymed_platform.Medication.Domain.Model.Aggregates.Medication;

namespace psymed_platform.Shared.Infrastructure.Persistence.EFC.Configuration
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            // Ensure the database is created
            Database.EnsureCreated();
        }

        public DbSet<Medication.Domain.Model.Aggregates.Medication> Medications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.AddInterceptors(new CreatedUpdatedInterceptor());
            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de la entidad Medication
            modelBuilder.Entity<Medication.Domain.Model.Aggregates.Medication>()
                .ToTable("medications")
                .HasKey(m => m.Id);

            modelBuilder.Entity<Medication.Domain.Model.Aggregates.Medication>()
                .Property(m => m.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Medication.Domain.Model.Aggregates.Medication>()
                .Property(m => m.Name)
                .IsRequired();

            modelBuilder.Entity<Medication.Domain.Model.Aggregates.Medication>()
                .OwnsOne(m => m.LifeCycleMedication);

            modelBuilder.Entity<Medication.Domain.Model.Aggregates.Medication>()
                .OwnsOne(m => m.Prescription);
        }
    }
}