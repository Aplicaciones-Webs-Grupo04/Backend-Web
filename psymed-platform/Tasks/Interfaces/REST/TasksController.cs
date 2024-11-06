using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using psymed_platform.Tasks.Application.Internal.CommandServices;
using psymed_platform.Tasks.Application.Internal.QueryServices;
using psymed_platform.Tasks.Interfaces.REST.Resources;
using psymed_platform.Tasks.Interfaces.REST.Transform;

namespace psymed_platform.Tasks.Interfaces.REST
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly TaskCommandService _commandService;
        private readonly TaskQueryService _queryService;

        public TasksController(TaskCommandService commandService, TaskQueryService queryService)
        {
            _commandService = commandService;
            _queryService = queryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskResource>>> GetAll()
        {
            var tasks = await _queryService.GetAllTasksAsync();
            var resources = tasks.Select(TaskTransform.ToResource);
            return Ok(resources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskResource>> GetById(string id)
        {
            var task = await _queryService.GetTaskByIdAsync(id);
            if (task == null) return NotFound();
            
            return Ok(TaskTransform.ToResource(task));
        }

        [HttpPost]
        public async Task<ActionResult<TaskResource>> Create(CreateTaskResource resource)
        {
            var command = TaskTransform.ToCreateCommand(resource);
            var task = await _commandService.CreateTaskAsync(command);
            var query = await _queryService.GetTaskByIdAsync(task.Id);
            
            return CreatedAtAction(nameof(GetById), new { id = task.Id }, TaskTransform.ToResource(query));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TaskResource>> Update(string id, UpdateTaskResource resource)
        {
            var command = TaskTransform.ToUpdateCommand(id, resource);
            var task = await _commandService.UpdateTaskAsync(command);
            if (task == null) return NotFound();
            
            var query = await _queryService.GetTaskByIdAsync(task.Id);
            return Ok(TaskTransform.ToResource(query));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var result = await _commandService.DeleteTaskAsync(id);
            if (!result) return NotFound();
            
            return NoContent();
        }
    }
}