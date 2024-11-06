namespace psymed_platform.Profiles.Interfaces.REST.Resources;
/// <summary>
/// Resource for creating a new profile.
/// </summary>
public record CreateProfileResource(string FirstName, string LastName, string Email,string Weight,string Height, string Phone,string Role);