using psymed_platform.Profiles.Domain.Model.Aggregates;
using psymed_platform.Profiles.Domain.Model.Commands;

namespace psymed_platform.Profiles.Domain.Services;

/// <summary>
/// Service interface for handling profile commands.
/// </summary>
public interface IProfileCommandService
{
    /// <summary>
    /// Handles the creation of a new profile.
    /// </summary>
    /// <param name="command">The command containing profile creation details.</param>
    /// <returns>The created profile, or null if creation failed.</returns>
    Task<Profile?> Handle(CreateProfileCommand command);

    /// <summary>
    /// Handles the update of an existing profile.
    /// </summary>
    /// <param name="command">The command containing profile update details.</param>
    /// <returns>The updated profile, or null if update failed.</returns>
    Task<Profile?> Handle(UpdateProfileCommand command);
}