using System.Threading.Tasks;
using psymed_platform.Tasks.Domain.Model.Commands;
using psymed_platform.Tasks.Domain.Model.Repositories;

namespace psymed_platform.Tasks.Application.Internal.CommandServices
{
    public class TaskCommandService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskCommandService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<Domain.Model.Aggregates.Task> CreateTaskAsync(CreateTaskCommand command)
        {
            var task = new Domain.Model.Aggregates.Task(
                command.IdPatient,
                command.Title,
                command.Description,
                command.Status
            );

            return await _taskRepository.AddAsync(task);
        }

        public async Task<Domain.Model.Aggregates.Task> UpdateTaskAsync(UpdateTaskCommand command)
        {
            var task = await _taskRepository.GetByIdAsync(command.Id);
            if (task == null) return null;

            task.Update(command.Title, command.Description, command.Status);
            return await _taskRepository.UpdateAsync(task);
        }

        public async Task<bool> DeleteTaskAsync(string id)
        {
            return await _taskRepository.DeleteAsync(id);
        }
    }
}