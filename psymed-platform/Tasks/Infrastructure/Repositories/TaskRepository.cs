using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using psymed_platform.Tasks.Domain.Model.Repositories;

namespace psymed_platform.Tasks.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly List<Domain.Model.Aggregates.Task> _tasks = new();

        public async Task<IEnumerable<Domain.Model.Aggregates.Task>> GetAllAsync()
        {
            return _tasks;
        }

        public async Task<Domain.Model.Aggregates.Task> GetByIdAsync(string id)
        {
            return _tasks.FirstOrDefault(t => t.Id == id);
        }

        public async Task<Domain.Model.Aggregates.Task> AddAsync(Domain.Model.Aggregates.Task task)
        {
            _tasks.Add(task);
            return task;
        }

        public async Task<Domain.Model.Aggregates.Task> UpdateAsync(Domain.Model.Aggregates.Task task)
        {
            var existingTask = _tasks.FirstOrDefault(t => t.Id == task.Id);
            if (existingTask == null) return null;
            
            existingTask.Update(task.Title, task.Description, task.Status);
            return existingTask;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return false;
            
            return _tasks.Remove(task);
        }
    }
}