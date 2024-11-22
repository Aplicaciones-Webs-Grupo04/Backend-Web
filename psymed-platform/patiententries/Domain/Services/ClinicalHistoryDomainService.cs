using psymed_platform.patiententries.Domain.Model.Aggregates;

namespace psymed_platform.patiententries.Domain.Services;

public class ClinicalHistoryDomainService
{
    public bool ValidateForUpdate(ClinicalHistory clinicalHistory, string reason)
    {
        // Validación de negocio para actualizar la historia clínica
        if (string.IsNullOrWhiteSpace(reason))
        {
            throw new ArgumentException("Reason cannot be empty");
        }

        return true;
    }
}