using psymed_platform.patiententries.Domain.Model.Aggregates;

namespace psymed_platform.patiententries.Domain.Repositories;

public interface IClinicalHistoryRepository
{
    Task<ClinicalHistory?> FindByIdAsync(int id);
    Task<IEnumerable<ClinicalHistory>> GetAllAsync();
    Task AddAsync(ClinicalHistory clinicalHistory);
    Task UpdateAsync(ClinicalHistory clinicalHistory);
    Task DeleteAsync(int id);
    Task<ClinicalHistory?> FindByPatientIdAsync(int patientId); // Nuevo método
}