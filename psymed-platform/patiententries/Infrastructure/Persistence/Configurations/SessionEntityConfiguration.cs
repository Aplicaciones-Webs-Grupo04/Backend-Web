using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using psymed_platform.patiententries.Domain.Model.Entities;
using psymed_platform.patiententries.Domain.Model.Aggregates;

namespace psymed_platform.patiententries.Infrastructure.Persistence.Configurations;

public class SessionEntityConfiguration : IEntityTypeConfiguration<Session>
{
    public void Configure(EntityTypeBuilder<Session> builder)
    {
        builder.ToTable("Sessions");
        builder.HasKey(s => s.Id);

        builder.Property(s => s.AppointmentDate)
            .IsRequired();

        builder.Property(s => s.SessionTime)
            .IsRequired();

        builder.Property(s => s.NoteId)
            .IsRequired();

        builder.Property(s => s.PatientId)
            .IsRequired();

        builder.Property(s => s.ProfessionalId)
            .IsRequired();

        builder.HasOne<Note>()
            .WithMany()
            .HasForeignKey(s => s.NoteId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Patient>()
            .WithMany()
            .HasForeignKey(s => s.PatientId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}