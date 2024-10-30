using Microsoft.AspNetCore.Mvc;
using psymed_platform.Models;
using psymed_platform.Services;

namespace psymed_platform.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TreatmentController : ControllerBase
{
    private readonly TreatmentService _treatmentService;

    public TreatmentController(TreatmentService treatmentService)
    {
        _treatmentService = treatmentService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTreatment([FromBody] Treatment treatment)
    {
        var createdTreatment = await _treatmentService.CreateTreatment(treatment);
        return CreatedAtAction(nameof(GetTreatmentById), new { id = createdTreatment.Id }, createdTreatment);
    }

    [HttpGet("patient/{patientId}")]
    public async Task<ActionResult<IEnumerable<Treatment>>> GetTreatmentsByPatient(int patientId)
    {
        var treatments = await _treatmentService.GetTreatmentsByPatient(patientId);
        return Ok(treatments);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTreatment(int id, [FromBody] Treatment treatment)
    {
        var updatedTreatment = await _treatmentService.UpdateTreatment(id, treatment);
        if (updatedTreatment == null)
            return NotFound();

        return Ok(updatedTreatment);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTreatment(int id)
    {
        var success = await _treatmentService.DeleteTreatment(id);
        if (!success)
            return NotFound();

        return NoContent();
    }
}