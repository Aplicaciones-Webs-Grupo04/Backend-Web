using psymed_platform.patiententries.Domain.Model.Entities;

namespace psymed_platform.patiententries.Domain.Repositories;

public interface ISessionRepository
{
    Task<Session?> FindByIdAsync(int id);
    Task<IEnumerable<Session>> GetAllAsync();
    Task AddAsync(Session session);
    Task UpdateAsync(Session session);
    Task DeleteAsync(int id);
}