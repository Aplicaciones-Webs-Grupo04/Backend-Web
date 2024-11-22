namespace psymed_platform.patiententries.Application.Commands;

public record UpdateClinicalHistoryCommand(
    int Id,
    string Reason,
    DateTime UpdatedDate,
    int PatientId);