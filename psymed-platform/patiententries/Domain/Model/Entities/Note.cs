namespace psymed_platform.patiententries.Domain.Model.Entities;

public class Note
{
    public int Id { get; private set; }
    public string Description { get; private set; } = string.Empty;
    public string Symptoms { get; private set; } = string.Empty;

    public Note(string description, string symptoms)
    {
        Description = description;
        Symptoms = symptoms;
    }
}