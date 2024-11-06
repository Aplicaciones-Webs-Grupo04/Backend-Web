using System.Net.Mime;
using psymed_platform.Profiles.Domain.Model.Queries;
using psymed_platform.Profiles.Domain.Services;
using psymed_platform.Profiles.Interfaces.REST.Resources;
using psymed_platform.Profiles.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace FlexPalPlatform.API.Profiles.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class ProfilesController : ControllerBase
{
    private readonly IProfileCommandService _profileCommandService;
    private readonly IProfileQueryService _profileQueryService;

    public ProfilesController(IProfileCommandService profileCommandService, IProfileQueryService profileQueryService)
    {
        _profileCommandService = profileCommandService;
        _profileQueryService = profileQueryService;
    }

    /// <summary>
    /// Creates a new profile.
    /// </summary>
    /// <param name="resource">The resource containing profile data.</param>
    /// <returns>The created profile resource.</returns>
    [HttpPost]
    public async Task<IActionResult> CreateProfile(CreateProfileResource resource)
    {
        try
        {
            var createProfileCommand = CreateProfileCommandFromResourceAssembler.ToCommandFromResource(resource);
            var profile = await _profileCommandService.Handle(createProfileCommand);
            if (profile is null) return BadRequest();
            var profileResource = ProfileResourceFromEntityAssembler.ToResourceFromEntity(profile);
            return CreatedAtAction(nameof(GetProfileById), new { profileId = profileResource.Id }, profileResource);
        }
        catch (Exception ex)
        {
            // Log the exception
            Console.WriteLine($"An error occurred while creating the profile: {ex.Message}");
            return StatusCode(500, "Internal server error");
        }
    }

    /// <summary>
    /// Gets a profile by its ID.
    /// </summary>
    /// <param name="profileId">The ID of the profile.</param>
    /// <returns>The profile resource.</returns>
    [HttpGet("{profileId:int}")]
    public async Task<IActionResult> GetProfileById(int profileId)
    {
        try
        {
            var getProfileByIdQuery = new GetProfileByIdQuery(profileId);
            var profile = await _profileQueryService.Handle(getProfileByIdQuery);
            if (profile == null) return NotFound();
            var profileResource = ProfileResourceFromEntityAssembler.ToResourceFromEntity(profile);
            return Ok(profileResource);
        }
        catch (Exception ex)
        {
            // Log the exception
            Console.WriteLine($"An error occurred while fetching the profile: {ex.Message}");
            return StatusCode(500, "Internal server error");
        }
    }

    /// <summary>
    /// Gets all profiles.
    /// </summary>
    /// <returns>A list of profile resources.</returns>
    [HttpGet]
    public async Task<IActionResult> GetAllProfiles()
    {
        try
        {
            var getAllProfilesQuery = new GetAllProfilesQuery();
            var profiles = await _profileQueryService.Handle(getAllProfilesQuery);
            var profileResources = profiles.Select(ProfileResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(profileResources);
        }
        catch (Exception ex)
        {
            // Log the exception
            Console.WriteLine($"An error occurred while fetching the profiles: {ex.Message}");
            return StatusCode(500, "Internal server error");
        }
    }

    /// <summary>
    /// Updates a profile.
    /// </summary>
    /// <param name="profileId">The ID of the profile to update.</param>
    /// <param name="resource">The resource containing updated profile data.</param>
    /// <returns>The updated profile resource.</returns>
    [HttpPut("{profileId:int}")]
    public async Task<IActionResult> UpdateProfile(int profileId, UpdateProfileResource resource)
    {
        if (profileId != resource.Id)
        {
            return BadRequest("Profile ID in the URL and in the resource do not match.");
        }

        try
        {
            var updateProfileCommand = UpdateProfileCommandFromResourceAssembler.ToCommandFromResource(resource);
            var updatedProfile = await _profileCommandService.Handle(updateProfileCommand);

            if (updatedProfile == null)
            {
                return NotFound();
            }

            var profileResource = ProfileResourceFromEntityAssembler.ToResourceFromEntity(updatedProfile);
            return Ok(profileResource);
        }
        catch (Exception ex)
        {
            // Log the exception
            Console.WriteLine($"An error occurred while updating the profile: {ex.Message}");
            return StatusCode(500, "Internal server error");
        }
    }
}