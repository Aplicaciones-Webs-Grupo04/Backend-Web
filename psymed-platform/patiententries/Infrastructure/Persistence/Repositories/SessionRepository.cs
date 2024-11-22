using Microsoft.EntityFrameworkCore;
using psymed_platform.patiententries.Domain.Model.Entities;
using psymed_platform.patiententries.Domain.Repositories;
using psymed_platform.patiententries.Infrastructure.Persistence.Context;

namespace psymed_platform.patiententries.Infrastructure.Persistence.Repositories;

public class SessionRepository : ISessionRepository
{
    private readonly PatientEntriesDbContext _context;

    public SessionRepository(PatientEntriesDbContext context)
    {
        _context = context;
    }

    public async Task<Session?> FindByIdAsync(int id)
    {
        return await _context.Sessions.FindAsync(id);
    }

    public async Task<IEnumerable<Session>> GetAllAsync()
    {
        return await _context.Sessions.ToListAsync();
    }

    public async Task AddAsync(Session session)
    {
        await _context.Sessions.AddAsync(session);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Session session)
    {
        _context.Sessions.Update(session);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var session = await FindByIdAsync(id);
        if (session != null)
        {
            _context.Sessions.Remove(session);
            await _context.SaveChangesAsync();
        }
    }
}