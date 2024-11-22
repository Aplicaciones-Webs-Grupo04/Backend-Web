namespace psymed_platform.patiententries.Application.Commands;

public record UpdatePatientCommand(
    int Id,
    string FirstName,
    string LastName,
    string Email,
    int AccountId,
    int ClinicalHistoryId);