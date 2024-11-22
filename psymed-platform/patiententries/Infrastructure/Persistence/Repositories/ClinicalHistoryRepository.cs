using Microsoft.EntityFrameworkCore;
using psymed_platform.patiententries.Domain.Model.Aggregates;
using psymed_platform.patiententries.Domain.Repositories;
using psymed_platform.patiententries.Infrastructure.Persistence.Context;

namespace psymed_platform.patiententries.Infrastructure.Persistence.Repositories;

public class ClinicalHistoryRepository : IClinicalHistoryRepository
{
    private readonly PatientEntriesDbContext _context;

    public ClinicalHistoryRepository(PatientEntriesDbContext context)
    {
        _context = context;
    }

    public async Task<ClinicalHistory?> FindByIdAsync(int id)
    {
        return await _context.ClinicalHistories.FindAsync(id);
    }

    public async Task<IEnumerable<ClinicalHistory>> GetAllAsync()
    {
        return await _context.ClinicalHistories.ToListAsync();
    }

    public async Task AddAsync(ClinicalHistory clinicalHistory)
    {
        await _context.ClinicalHistories.AddAsync(clinicalHistory);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(ClinicalHistory clinicalHistory)
    {
        _context.ClinicalHistories.Update(clinicalHistory);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var history = await FindByIdAsync(id);
        if (history != null)
        {
            _context.ClinicalHistories.Remove(history);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<ClinicalHistory?> FindByPatientIdAsync(int patientId)
    {
        return await _context.ClinicalHistories
            .FirstOrDefaultAsync(ch => ch.PatientId == patientId);
    }
}