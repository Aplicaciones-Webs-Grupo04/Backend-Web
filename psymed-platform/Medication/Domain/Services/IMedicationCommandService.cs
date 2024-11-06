using psymed_platform.Medication.Domain.Model.Commands;
namespace psymed_platform.Medication.Domain.Services;

public interface IMedicationCommandService
{
    Task<Model.Aggregates.Medication?> Handle(CreateMedicationCommand command);
}