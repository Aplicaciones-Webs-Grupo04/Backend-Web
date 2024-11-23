using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using psymed_platform.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace psymed_platform.Treatment.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TreatmentController : ControllerBase
{
    private readonly AppDbContext _context;

    public TreatmentController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Domain.Models.Treatment>>> GetTreatments()
    {
        return await _context.Set<Domain.Models.Treatment>().ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Domain.Models.Treatment>> PostTreatment(Domain.Models.Treatment treatment)
    {
        _context.Set<Domain.Models.Treatment>().Add(treatment);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetTreatments), new { id = treatment.Id }, treatment);
    }
}