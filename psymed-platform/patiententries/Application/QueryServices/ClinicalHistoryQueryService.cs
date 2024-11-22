using psymed_platform.patiententries.Application.Dtos;
using psymed_platform.patiententries.Application.Queries;
using psymed_platform.patiententries.Domain.Repositories;

namespace psymed_platform.patiententries.Application.QueryServices;

public class ClinicalHistoryQueryService
{
    private readonly IClinicalHistoryRepository _clinicalHistoryRepository;

    public ClinicalHistoryQueryService(IClinicalHistoryRepository clinicalHistoryRepository)
    {
        _clinicalHistoryRepository = clinicalHistoryRepository;
    }

    public async Task<ClinicalHistoryDto?> Handle(GetClinicalHistoryByPatientIdQuery query)
    {
        var history = await _clinicalHistoryRepository.FindByPatientIdAsync(query.PatientId);
        if (history == null) return null;

        return new ClinicalHistoryDto
        {
            Id = history.Id,
            Reason = history.Reason,
            CreatedDate = history.CreatedDate,
            UpdatedDate = history.UpdatedDate,
            PatientId = history.PatientId
        };
    }
}