namespace psymed_platform.Medication.Interfaces.Resources;

public record CreateMedicationResource(string Name, string Frequency, string Quantity, string StartedDate, string EndedDate)
{
    
}