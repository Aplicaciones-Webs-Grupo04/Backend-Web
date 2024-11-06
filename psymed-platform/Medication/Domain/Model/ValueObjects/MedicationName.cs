namespace psymed_platform.Medication.Domain.Model.ValueObjects;

public record MedicationName(string Name) {
    
    public MedicationName() :this(string.Empty) { }
    
};