using psymed_platform.patiententries.Application.Commands;
using psymed_platform.patiententries.Domain.Model.Aggregates;
using psymed_platform.patiententries.Domain.Repositories;

namespace psymed_platform.patiententries.Application.CommandServices;

public class PatientCommandService
{
    private readonly IPatientRepository _patientRepository;

    public PatientCommandService(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<Patient?> Handle(CreatePatientCommand command)
    {
        var patient = new Patient(command.FirstName, command.LastName, command.Email, command.AccountId, command.ClinicalHistoryId);
        await _patientRepository.AddAsync(patient);
        return patient;
    }

    public async Task<Patient?> Handle(UpdatePatientCommand command)
    {
        var patient = await _patientRepository.FindByIdAsync(command.Id);
        if (patient == null) return null;

        patient.Update(command.FirstName, command.LastName, command.Email, command.AccountId, command.ClinicalHistoryId);
        await _patientRepository.UpdateAsync(patient);
        return patient;
    }
}