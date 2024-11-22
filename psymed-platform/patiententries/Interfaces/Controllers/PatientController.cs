using Microsoft.AspNetCore.Mvc;
using psymed_platform.patiententries.Application.Commands;
using psymed_platform.patiententries.Application.CommandServices;
using psymed_platform.patiententries.Application.QueryServices;
using psymed_platform.patiententries.Application.Queries;

namespace psymed_platform.patiententries.Interfaces.Controllers;

[ApiController]
[Route("api/v1/patients")]
public class PatientController : ControllerBase
{
    private readonly PatientQueryService _queryService;
    private readonly PatientCommandService _commandService;

    public PatientController(
        PatientQueryService queryService,
        PatientCommandService commandService)
    {
        _queryService = queryService;
        _commandService = commandService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPatients()
    {
        var patients = await _queryService.Handle(new GetAllPatientsQuery());
        return Ok(patients);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePatient([FromBody] CreatePatientCommand command)
    {
        var result = await _commandService.Handle(command);
        return CreatedAtAction(nameof(GetAllPatients), new { id = result.Id }, result);
    }
}