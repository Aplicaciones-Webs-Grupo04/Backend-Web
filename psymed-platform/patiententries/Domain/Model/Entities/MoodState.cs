namespace psymed_platform.patiententries.Domain.Model.Entities;

public class MoodState
{
    public int Id { get; private set; }
    public string State { get; private set; } = string.Empty;

    public MoodState(string state)
    {
        State = state;
    }
}