namespace psymed_platform.Profiles.Interfaces.REST.Resources;

/// <summary>
/// Resource representing a profile.
/// </summary>
public record ProfileResource(int Id, string FullName, string Email, string Weight, string Height, string Phone, string Role);