namespace psymed_platform.patiententries.Domain.Model.Aggregates;

public class ClinicalHistory
{
    public int Id { get; private set; }
    public string Reason { get; private set; } = string.Empty;
    public DateTime CreatedDate { get; private set; }
    public DateTime UpdatedDate { get; private set; }
    public int PatientId { get; private set; }

    // Constructor principal
    public ClinicalHistory(string reason, DateTime createdDate, DateTime updatedDate, int patientId)
    {
        Reason = reason;
        CreatedDate = createdDate;
        UpdatedDate = updatedDate;
        PatientId = patientId;
    }

    // Método para actualizar la historia clínica
    public void Update(string reason, DateTime updatedDate)
    {
        Reason = reason;
        UpdatedDate = updatedDate;
    }
}