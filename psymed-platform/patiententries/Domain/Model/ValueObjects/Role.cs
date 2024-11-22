namespace psymed_platform.patiententries.Domain.Model.ValueObjects;

public record Role(string RoleName)
{
    public Role() : this(string.Empty) { }
}