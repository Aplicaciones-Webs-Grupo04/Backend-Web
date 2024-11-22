using System.Collections.Generic;
using System.Threading.Tasks;
using psymed_platform.Tasks.Domain.Model.Aggregates;

namespace psymed_platform.Tasks.Domain.Model.Repositories
{
    public interface ITaskRepository
    {
        Task<IEnumerable<Aggregates.Task>> GetAllAsync();
        Task<Aggregates.Task> GetByIdAsync(string id);
        Task<Aggregates.Task> AddAsync(Aggregates.Task task);
        Task<Aggregates.Task> UpdateAsync(Aggregates.Task task);
        Task<bool> DeleteAsync(string id);
    }
}