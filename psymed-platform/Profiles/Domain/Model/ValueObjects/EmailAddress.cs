namespace psymed_platform.Profiles.Domain.Model.ValueObjects;
/// <summary>
/// Value object representing an email address.
/// </summary>
public record EmailAddress(string Address)
{
    public EmailAddress() : this(string.Empty)
    {
    }
    
}