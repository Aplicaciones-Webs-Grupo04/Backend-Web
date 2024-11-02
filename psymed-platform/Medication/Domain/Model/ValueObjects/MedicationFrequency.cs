namespace psymed_platform.Medication.Domain.Model.ValueObjects;

public record MedicationFrequency(string Frecuency)
{
    public MedicationFrequency(): this(string.Empty){}
};