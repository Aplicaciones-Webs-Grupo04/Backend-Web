using psymed_platform.Profiles.Domain.Model.Commands;
using psymed_platform.Profiles.Domain.Services;

namespace psymed_platform.Profiles.Interfaces.ACL.Services;

/// <summary>
/// Facade for interacting with profile-related services.
/// </summary>
public class ProfilesContextFacade : IProfilesContextFacade
{
    private readonly IProfileCommandService _profileCommandService;
    private readonly IProfileQueryService _profileQueryService;

    public ProfilesContextFacade(IProfileCommandService profileCommandService, IProfileQueryService profileQueryService)
    {
        _profileCommandService = profileCommandService;
        _profileQueryService = profileQueryService;
    }

    /// <summary>
    /// Creates a new profile.
    /// </summary>
    /// <param name="firstName">The first name of the profile.</param>
    /// <param name="lastName">The last name of the profile.</param>
    /// <param name="email">The email address of the profile.</param>
    /// <param name="weight">The weight of the profile.</param>
    /// <param name="height">The height of the profile.</param>
    /// <param name="phone">The phone number of the profile.</param>
    /// <param name="role">The role of the profile.</param>
    /// <returns>The ID of the created profile, or 0 if creation failed.</returns>
    public async Task<int> CreateProfile(string firstName, string lastName, string email, string weight, string height, string phone, string role)
    {
        var createProfileCommand = new CreateProfileCommand(firstName, lastName, email, weight, height, phone, role);
        try
        {
            var profile = await _profileCommandService.Handle(createProfileCommand);
            return profile?.Id ?? 0;
        }
        catch (Exception ex)
        {
            // Log the exception
            Console.WriteLine($"An error occurred while creating the profile: {ex.Message}");
            return 0;
        }
    }
}