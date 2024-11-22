namespace psymed_platform.patiententries.Domain.Model.ValueObjects;

public record Name(string FirstName, string LastName)
{
    public string FullName => $"{FirstName} {LastName}";
}