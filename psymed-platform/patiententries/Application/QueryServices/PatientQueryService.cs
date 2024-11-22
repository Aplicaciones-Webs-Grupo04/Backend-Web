using psymed_platform.patiententries.Application.Dtos;
using psymed_platform.patiententries.Application.Queries;
using psymed_platform.patiententries.Domain.Repositories;

namespace psymed_platform.patiententries.Application.QueryServices;

public class PatientQueryService
{
    private readonly IPatientRepository _patientRepository;

    public PatientQueryService(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<IEnumerable<PatientDto>> Handle(GetAllPatientsQuery query)
    {
        var patients = await _patientRepository.GetAllAsync();
        return patients.Select(p => new PatientDto
        {
            Id = p.Id,
            FirstName = p.FirstName,
            LastName = p.LastName,
            Email = p.Email,
            AccountId = p.AccountId,
            ClinicalHistoryId = p.ClinicalHistoryId
        });
    }

    public async Task<PatientDto?> Handle(GetPatientByIdQuery query)
    {
        var patient = await _patientRepository.FindByIdAsync(query.Id);
        if (patient == null) return null;

        return new PatientDto
        {
            Id = patient.Id,
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            Email = patient.Email,
            AccountId = patient.AccountId,
            ClinicalHistoryId = patient.ClinicalHistoryId
        };
    }
}   