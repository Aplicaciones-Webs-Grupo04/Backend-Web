namespace psymed_platform.Medication.Domain.Model.Aggregates;

public class Medication {
    
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Frecuency { get; private set; }
    public int Quantity { get; private set; }
    
}