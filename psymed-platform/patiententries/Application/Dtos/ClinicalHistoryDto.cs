namespace psymed_platform.patiententries.Application.Dtos;

public class ClinicalHistoryDto
{
    public int Id { get; set; }
    public string Reason { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public int PatientId { get; set; }
}