namespace psymed_platform.Medication.Domain.Model.ValueObjects;

public record Prescription(string Frequency, string Quantity)
{
    public Prescription():this(string.Empty,string.Empty){}
    
    public Prescription(string frequency): this(frequency,string.Empty){}
    
    public string MedicalPrescription => $"{Quantity}{Frequency}";
};