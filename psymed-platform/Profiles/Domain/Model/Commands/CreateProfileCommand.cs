namespace psymed_platform.Profiles.Domain.Model.Commands;

public record CreateProfileCommand(string FirstName, string LastName, string Email,string Weight,string Height,string Phone, string Role);