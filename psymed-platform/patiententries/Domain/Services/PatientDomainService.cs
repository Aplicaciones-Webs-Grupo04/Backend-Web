using psymed_platform.patiententries.Domain.Model.Aggregates;

namespace psymed_platform.patiententries.Domain.Services;

public class PatientDomainService
{
    public bool ValidateForUpdate(Patient patient, string firstName, string lastName, string email)
    {
        // Validación de negocio para actualizar el paciente
        if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
        {
            throw new ArgumentException("First name and last name cannot be empty");
        }

        if (!email.Contains("@"))
        {
            throw new ArgumentException("Email must be valid");
        }

        return true;
    }
}