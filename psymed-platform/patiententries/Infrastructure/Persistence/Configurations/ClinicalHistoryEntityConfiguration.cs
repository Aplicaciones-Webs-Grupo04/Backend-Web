using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using psymed_platform.patiententries.Domain.Model.Aggregates;

namespace psymed_platform.patiententries.Infrastructure.Persistence.Configurations;

public class ClinicalHistoryEntityConfiguration : IEntityTypeConfiguration<ClinicalHistory>
{
    public void Configure(EntityTypeBuilder<ClinicalHistory> builder)
    {
        builder.ToTable("ClinicalHistories");
        builder.HasKey(ch => ch.Id);
        builder.Property(ch => ch.Reason).IsRequired().HasMaxLength(255);
        builder.Property(ch => ch.CreatedDate).IsRequired();
        builder.Property(ch => ch.UpdatedDate).IsRequired();
        builder.HasOne<Patient>()
            .WithMany()
            .HasForeignKey(ch => ch.PatientId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}