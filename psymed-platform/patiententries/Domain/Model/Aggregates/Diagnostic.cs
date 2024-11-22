namespace psymed_platform.patiententries.Domain.Model.Aggregates;

public class Diagnostic
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public DateTime CreatedDate { get; private set; }
    public DateTime UpdatedDate { get; private set; }
    public int ClinicalHistoryId { get; private set; }

    // Constructor principal
    public Diagnostic(string name, string description, DateTime createdDate, DateTime updatedDate, int clinicalHistoryId)
    {
        Name = name;
        Description = description;
        CreatedDate = createdDate;
        UpdatedDate = updatedDate;
        ClinicalHistoryId = clinicalHistoryId;
    }

    // Método para actualizar el diagnóstico
    public void Update(string name, string description, DateTime updatedDate)
    {
        Name = name;
        Description = description;
        UpdatedDate = updatedDate;
    }
}