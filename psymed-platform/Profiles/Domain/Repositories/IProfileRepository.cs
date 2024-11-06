using psymed_platform.Profiles.Domain.Model.Aggregates;
using psymed_platform.Shared.Domain.Repositories;

namespace psymed_platform.Profiles.Domain.Repositories;
/// <summary>
/// Repository interface for Profile aggregate.
/// </summary>
public interface IProfileRepository : IBaseRepository<Profile>
{
    
}