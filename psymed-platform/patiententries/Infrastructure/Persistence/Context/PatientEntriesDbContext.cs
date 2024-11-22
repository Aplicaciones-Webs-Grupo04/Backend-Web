using Microsoft.EntityFrameworkCore;
using psymed_platform.patiententries.Domain.Model.Aggregates;
using psymed_platform.patiententries.Domain.Model.Entities;
using psymed_platform.patiententries.Infrastructure.Persistence.Configurations;

namespace psymed_platform.patiententries.Infrastructure.Persistence.Context;

public class PatientEntriesDbContext : DbContext
{
    public DbSet<Patient> Patients { get; set; }
    public DbSet<ClinicalHistory> ClinicalHistories { get; set; }
    public DbSet<Session> Sessions { get; set; }

    public PatientEntriesDbContext(DbContextOptions<PatientEntriesDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PatientEntityConfiguration());
        modelBuilder.ApplyConfiguration(new ClinicalHistoryEntityConfiguration());
        modelBuilder.ApplyConfiguration(new SessionEntityConfiguration());
    }
}