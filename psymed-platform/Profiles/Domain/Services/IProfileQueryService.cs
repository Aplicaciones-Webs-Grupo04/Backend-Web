using psymed_platform.Profiles.Domain.Model.Aggregates;
using psymed_platform.Profiles.Domain.Model.Queries;

namespace psymed_platform.Profiles.Domain.Services;

/// <summary>
/// Service interface for handling profile queries.
/// </summary>
public interface IProfileQueryService
{
    /// <summary>
    /// Handles the retrieval of all profiles.
    /// </summary>
    /// <param name="query">The query for retrieving all profiles.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains an enumerable of profiles.</returns>
    Task<IEnumerable<Profile>> Handle(GetAllProfilesQuery query);

    /// <summary>
    /// Handles the retrieval of a profile by its ID.
    /// </summary>
    /// <param name="query">The query for retrieving a profile by its ID.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the profile, or null if not found.</returns>
    Task<Profile?> Handle(GetProfileByIdQuery query);
}