namespace psymed_platform.patiententries.Application.Commands;

public record CreateClinicalHistoryCommand(
    string Reason,
    DateTime CreatedDate,
    DateTime UpdatedDate,
    int PatientId);