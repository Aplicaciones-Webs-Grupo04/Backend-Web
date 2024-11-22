using Microsoft.EntityFrameworkCore;
using psymed_platform.patiententries.Domain.Model.Aggregates;
using psymed_platform.patiententries.Domain.Repositories;
using psymed_platform.patiententries.Infrastructure.Persistence.Context;

namespace psymed_platform.patiententries.Infrastructure.Persistence.Repositories;

public class PatientRepository : IPatientRepository
{
    private readonly PatientEntriesDbContext _context;

    public PatientRepository(PatientEntriesDbContext context)
    {
        _context = context;
    }

    public async Task<Patient?> FindByIdAsync(int id)
    {
        return await _context.Patients.FindAsync(id);
    }

    public async Task<IEnumerable<Patient>> GetAllAsync()
    {
        return await _context.Patients.ToListAsync();
    }

    public async Task AddAsync(Patient patient)
    {
        await _context.Patients.AddAsync(patient);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Patient patient)
    {
        _context.Patients.Update(patient);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var patient = await FindByIdAsync(id);
        if (patient != null)
        {
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
        }
    }
}