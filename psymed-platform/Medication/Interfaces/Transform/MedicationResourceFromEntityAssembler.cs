using psymed_platform.Medication.Interfaces.Resources;

namespace psymed_platform.Medication.Interfaces.Transform;

public class MedicationResourceFromEntityAssembler
{
    public static MedicationResource ToResourceFromEntity(Domain.Model.Aggregates.Medication entity)
    {
        return new MedicationResource(entity.Id, entity.MedicalPrescription);
    }

}