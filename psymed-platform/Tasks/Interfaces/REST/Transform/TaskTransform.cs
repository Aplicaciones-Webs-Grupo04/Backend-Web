using psymed_platform.Tasks.Domain.Model.Commands;
using psymed_platform.Tasks.Domain.Model.Queries;
using psymed_platform.Tasks.Interfaces.REST.Resources;

namespace psymed_platform.Tasks.Interfaces.REST.Transform
{
    public static class TaskTransform
    {
        public static TaskResource ToResource(TaskQuery query)
        {
            return new TaskResource
            {
                Id = query.Id,
                IdPatient = query.IdPatient,
                Title = query.Title,
                Description = query.Description,
                Status = query.Status,
                CreatedAt = query.CreatedAt,
                UpdatedAt = query.UpdatedAt
            };
        }

        public static CreateTaskCommand ToCreateCommand(CreateTaskResource resource)
        {
            return new CreateTaskCommand
            {
                IdPatient = resource.IdPatient,
                Title = resource.Title,
                Description = resource.Description,
                Status = resource.Status
            };
        }

        public static UpdateTaskCommand ToUpdateCommand(string id, UpdateTaskResource resource)
        {
            return new UpdateTaskCommand
            {
                Id = id,
                Title = resource.Title,
                Description = resource.Description,
                Status = resource.Status
            };
        }
    }
}