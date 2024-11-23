namespace psymed_platform.Medication.Domain.Model.ValueObjects;

public record MedicationName(string Name) {
    
    public MedicationName() :this(string.Empty) { }

    public static MedicationName FromString(string s)
    {
        throw new NotImplementedException();
    }
};