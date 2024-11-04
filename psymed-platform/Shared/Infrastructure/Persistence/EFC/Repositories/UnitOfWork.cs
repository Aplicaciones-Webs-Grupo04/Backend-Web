using psymed_platform.Shared.Domain.Repositories;
using psymed_platform.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace psymed_platform.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task CompleteAsync() => await context.SaveChangesAsync();
}