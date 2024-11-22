namespace psymed_platform.Medication.Domain.Model.Commands;

public record CreateMedicationCommand(string Name, string Frequency, string Quantity, string StartedDate, string EndedDate);