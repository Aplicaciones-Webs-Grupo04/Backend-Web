using psymed_platform.patiententries.Domain.Model.Aggregates;

namespace psymed_platform.patiententries.Domain.Repositories;

public interface IPatientRepository
{
    Task<Patient?> FindByIdAsync(int id);
    Task<IEnumerable<Patient>> GetAllAsync();
    Task AddAsync(Patient patient);
    Task UpdateAsync(Patient patient);
    Task DeleteAsync(int id);
}