namespace psymed_platform.Profiles.Domain.Model.Commands;

public record UpdateProfileCommand(int Id ,string Email,string Weight,string Height, string Phone);