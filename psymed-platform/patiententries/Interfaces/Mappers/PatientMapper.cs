using psymed_platform.patiententries.Application.Dtos;
using psymed_platform.patiententries.Domain.Model.Aggregates;

namespace psymed_platform.patiententries.Interfaces.Mappers;

public static class PatientMapper
{
    public static PatientDto ToDto(Patient patient)
    {
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