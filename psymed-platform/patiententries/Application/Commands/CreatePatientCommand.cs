namespace psymed_platform.patiententries.Application.Commands;

public record CreatePatientCommand(
    string FirstName,
    string LastName,
    string Email,
    int AccountId,
    int ClinicalHistoryId);