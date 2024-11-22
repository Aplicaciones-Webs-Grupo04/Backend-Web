using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using psymed_platform.Medication.Domain.Model.Queries;
using psymed_platform.Medication.Domain.Services;
using psymed_platform.Medication.Interfaces.Resources;

namespace psymed_platform.Medication.Interfaces.Transform;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]

public class MedicationsController(IMedicationCommandService medicationCommandService, IMedicationQueryService medicationQueryService) : ControllerBase
{

    [HttpGet("{medicationId:int}")]
    public async Task<IActionResult> GetMedicationById(int medicationId)
    {
        var getMedicationByIdQuery = new GetMedicationByIdQuery(medicationId);
        var medication = await medicationQueryService.Handle(getMedicationByIdQuery);

        if (medication == null) return NotFound();
        var medicationResource = MedicationResourceFromEntityAssembler.ToResourceFromEntity(medication);
        return Ok(medicationResource);

    }
    
    
    [HttpPost]
    public async Task<IActionResult> CreateMedication(CreateMedicationResource resource)
    {
        var createMedicationCommand = CreateMedicationCommandFromResourceAssembler.ToCommandFromResource(resource);
        var medication = await medicationCommandService.Handle(createMedicationCommand);

        if (medication is null) return BadRequest();

        var medicationResource = MedicationResourceFromEntityAssembler.ToResourceFromEntity(medication);
        return CreatedAtAction(nameof(GetMedicationById), new { medicationId = medicationResource.Id },
            medicationResource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllMedications()
    {
        var getAllMedicationsQuery = new GetAllMedicationsQuery();
        var medications = await medicationQueryService.Handle(getAllMedicationsQuery);
        var medicationResources = medications.Select(MedicationResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(medicationResources);
    }
    
    
}