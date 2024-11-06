using psymed_platform.Medication.Domain.Model.ValueObjects;

namespace psymed_platform.Medication.Domain.Model.Queries;

public record GetMedicationByNameQuery(MedicationName Name);