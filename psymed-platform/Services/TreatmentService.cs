using psymed_platform.Data;
using psymed_platform.Models;

namespace psymed_platform.Services;

public class TreatmentService
{
    private readonly ApplicationDbContext _context;

    public TreatmentService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Treatment> CreateTreatment(Treatment treatment)
    {
        _context.Treatments.Add(treatment);
        await _context.SaveChangesAsync();
        return treatment;
    }

    public async Task<IEnumerable<Treatment>> GetTreatmentsByPatient(int patientId)
    {
        return await _context.Treatments.Where(t => t.PatientId == patientId).ToListAsync();
    }

    public async Task<Treatment> UpdateTreatment(int id, Treatment treatment)
    {
        var existingTreatment = await _context.Treatments.FindAsync(id);
        if (existingTreatment != null)
        {
            _context.Entry(existingTreatment).CurrentValues.SetValues(treatment);
            await _context.SaveChangesAsync();
        }
        return existingTreatment;
    }

    public async Task<bool> DeleteTreatment(int id)
    {
        var treatment = await _context.Treatments.FindAsync(id);
        if (treatment != null)
        {
            _context.Treatments.Remove(treatment);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }
}