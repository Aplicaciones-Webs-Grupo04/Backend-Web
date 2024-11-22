using psymed_platform.patiententries.Application.Dtos;
using psymed_platform.patiententries.Domain.Model.Aggregates;

namespace psymed_platform.patiententries.Interfaces.Mappers;

public static class ClinicalHistoryMapper
{
    public static ClinicalHistoryDto ToDto(ClinicalHistory clinicalHistory)
    {
        return new ClinicalHistoryDto
        {
            Id = clinicalHistory.Id,
            Reason = clinicalHistory.Reason,
            CreatedDate = clinicalHistory.CreatedDate,
            UpdatedDate = clinicalHistory.UpdatedDate,
            PatientId = clinicalHistory.PatientId
        };
    }
}