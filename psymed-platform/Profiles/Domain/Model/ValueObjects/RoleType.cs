namespace psymed_platform.Profiles.Domain.Model.ValueObjects;
/// <summary>
/// Value object representing a role type.
/// </summary>
public record RoleType(string Role)
{
    public RoleType() : this(string.Empty)
    {
    }
    
}