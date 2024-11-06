using psymed_platform.Medication.Domain.Model.ValueObjects;
using psymed_platform.Shared.Domain.Repositories;
namespace psymed_platform.Medication.Domain.Repositories;

public interface IMedicationRepository: IBaseRepository<Model.Aggregates.Medication> {
    
    Task<Model.Aggregates.Medication?> FindMedicationByNameAsync(MedicationName name);
    
    
}