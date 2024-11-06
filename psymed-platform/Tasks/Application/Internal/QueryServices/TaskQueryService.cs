using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using psymed_platform.Tasks.Domain.Model.Queries;
using psymed_platform.Tasks.Domain.Model.Repositories;

namespace psymed_platform.Tasks.Application.Internal.QueryServices
{
    public class TaskQueryService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskQueryService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<IEnumerable<TaskQuery>> GetAllTasksAsync()
        {
            var tasks = await _taskRepository.GetAllAsync();
            return tasks.Select(MapToQuery);
        }

        public async Task<TaskQuery> GetTaskByIdAsync(string id)
        {
            var task = await _taskRepository.GetByIdAsync(id);
            return task != null ? MapToQuery(task) : null;
        }

        private static TaskQuery MapToQuery(Domain.Model.Aggregates.Task task)
        {
            return new TaskQuery
            {
                Id = task.Id,
                IdPatient = task.IdPatient,
                Title = task.Title,
                Description = task.Description,
                Status = task.Status,
                CreatedAt = task.CreatedAt,
                UpdatedAt = task.UpdatedAt
            };
        }
    }
}