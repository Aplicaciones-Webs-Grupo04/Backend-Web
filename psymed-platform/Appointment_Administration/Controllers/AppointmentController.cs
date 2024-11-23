using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using psymed_platform.Appoiment_Administration.Domain.Models;
using psymed_platform.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace psymed_platform.Appointment_Administration.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AppointmentsController : ControllerBase
{
    private readonly AppDbContext _context;

    public AppointmentsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments()
    {
        return await _context.Set<Appointment>().ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Appointment>> PostAppointment(Appointment appointment)
    {
        _context.Set<Appointment>().Add(appointment);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetAppointments), new { id = appointment.Id }, appointment);
    }
}