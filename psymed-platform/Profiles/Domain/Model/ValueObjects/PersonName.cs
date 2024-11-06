namespace psymed_platform.Profiles.Domain.Model.ValueObjects;
/// <summary>
/// Value object representing a person's name.
/// </summary>
public record PersonName(string FirstName, string LastName)
{
    public PersonName() : this(string.Empty, string.Empty)
    {
    }

    public PersonName(string firstName) : this(firstName, string.Empty)
    {
    }

    public string FullName => $"{FirstName} {LastName}";
}