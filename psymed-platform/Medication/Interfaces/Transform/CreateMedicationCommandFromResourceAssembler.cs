using psymed_platform.Medication.Domain.Model.Commands;
using psymed_platform.Medication.Interfaces.Resources;

namespace psymed_platform.Medication.Interfaces.Transform;

public static class CreateMedicationCommandFromResourceAssembler
{
    public static CreateMedicationCommand ToCommandFromResource(CreateMedicationResource resource)
    {
        return new CreateMedicationCommand(resource.Name, resource.Frequency, resource.Quantity, resource.StartedDate,
            resource.EndedDate);
    }
}