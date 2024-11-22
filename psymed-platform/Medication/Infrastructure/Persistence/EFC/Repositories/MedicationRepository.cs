using Microsoft.EntityFrameworkCore;
using psymed_platform.Medication.Domain.Model.ValueObjects;
using psymed_platform.Medication.Domain.Repositories;
using psymed_platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using psymed_platform.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace psymed_platform.Medication.Infrastructure.Persistence.EFC.Repositories;

public class MedicationRepository(AppDbContext context): BaseRepository<Domain.Model.Aggregates.Medication>(context), IMedicationRepository
{
    public Task<Domain.Model.Aggregates.Medication?> FindMedicationByNameAsync(MedicationName name)
    {
        return Context.Set<Domain.Model.Aggregates.Medication>().Where(m => m.Name == name).FirstOrDefaultAsync();
    }
    
}