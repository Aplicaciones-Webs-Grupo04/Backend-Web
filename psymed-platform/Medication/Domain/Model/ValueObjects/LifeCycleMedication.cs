namespace psymed_platform.Medication.Domain.ValueObjects;

public record LifeCycleMedication(string StartedDate, string EndedDate)
{
    public LifeCycleMedication(): this(string.Empty, string.Empty){}
    
    public LifeCycleMedication(string startedDate): this(startedDate, string.Empty){} 
    
};