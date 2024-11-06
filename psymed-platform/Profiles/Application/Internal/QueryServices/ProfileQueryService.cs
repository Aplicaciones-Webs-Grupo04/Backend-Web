using psymed_platform.Profiles.Domain.Model.Aggregates;
using psymed_platform.Profiles.Domain.Model.Queries;
using psymed_platform.Profiles.Domain.Repositories;
using psymed_platform.Profiles.Domain.Services;

namespace psymed_platform.Profiles.Application.Internal.QueryServices;

public class ProfileQueryService(IProfileRepository profileRepository): IProfileQueryService
{
    public async Task<IEnumerable<Profile>> Handle(GetAllProfilesQuery query)
    {
        return await profileRepository.ListAsync();
    }

    public async Task<Profile?> Handle(GetProfileByIdQuery query)
    {
        return await profileRepository.FindByIdAsync(query.ProfileId);
    }
}