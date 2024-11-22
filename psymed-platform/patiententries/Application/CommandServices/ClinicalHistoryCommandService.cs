using psymed_platform.patiententries.Application.Commands;
using psymed_platform.patiententries.Domain.Model.Aggregates;
using psymed_platform.patiententries.Domain.Repositories;

namespace psymed_platform.patiententries.Application.CommandServices;

public class ClinicalHistoryCommandService
{
    private readonly IClinicalHistoryRepository _clinicalHistoryRepository;

    public ClinicalHistoryCommandService(IClinicalHistoryRepository clinicalHistoryRepository)
    {
        _clinicalHistoryRepository = clinicalHistoryRepository;
    }

    public async Task<ClinicalHistory?> Handle(CreateClinicalHistoryCommand command)
    {
        var history = new ClinicalHistory(command.Reason, command.CreatedDate, command.UpdatedDate, command.PatientId);
        await _clinicalHistoryRepository.AddAsync(history);
        return history;
    }

    public async Task<ClinicalHistory?> Handle(UpdateClinicalHistoryCommand command)
    {
        var history = await _clinicalHistoryRepository.FindByIdAsync(command.Id);
        if (history == null) return null;

        history.Update(command.Reason, command.UpdatedDate);
        await _clinicalHistoryRepository.UpdateAsync(history);
        return history;
    }
}