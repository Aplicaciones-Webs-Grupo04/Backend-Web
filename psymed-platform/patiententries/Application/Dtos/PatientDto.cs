namespace psymed_platform.patiententries.Application.Dtos;

public class PatientDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int AccountId { get; set; }
    public int ClinicalHistoryId { get; set; }
}