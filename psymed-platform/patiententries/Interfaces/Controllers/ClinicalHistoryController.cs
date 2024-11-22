using Microsoft.AspNetCore.Mvc;
using psymed_platform.patiententries.Application.Commands;
using psymed_platform.patiententries.Application.CommandServices;
using psymed_platform.patiententries.Application.QueryServices;
using psymed_platform.patiententries.Application.Queries;

namespace psymed_platform.patiententries.Interfaces.Controllers;

[ApiController]
[Route("api/v1/clinical-histories")]
public class ClinicalHistoryController : ControllerBase
{
    private readonly ClinicalHistoryQueryService _queryService;
    private readonly ClinicalHistoryCommandService _commandService;

    public ClinicalHistoryController(
        ClinicalHistoryQueryService queryService,
        ClinicalHistoryCommandService commandService)
    {
        _queryService = queryService;
        _commandService = commandService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetClinicalHistoryById(int id)
    {
        var history = await _queryService.Handle(new GetClinicalHistoryByPatientIdQuery(id));
        if (history == null)
            return NotFound();
        return Ok(history);
    }

    [HttpPost]
    public async Task<IActionResult> CreateClinicalHistory([FromBody] CreateClinicalHistoryCommand command)
    {
        var result = await _commandService.Handle(command);
        return CreatedAtAction(nameof(GetClinicalHistoryById), new { id = result.Id }, result);
    }
}