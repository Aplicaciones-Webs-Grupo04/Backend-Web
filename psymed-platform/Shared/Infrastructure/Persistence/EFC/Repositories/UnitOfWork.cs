using psymed_platform.Shared.Domain.Repositories;
using psymed_platform.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace psymed_platform.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}