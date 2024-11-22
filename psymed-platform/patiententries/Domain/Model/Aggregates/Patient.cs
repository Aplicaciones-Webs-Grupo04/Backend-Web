namespace psymed_platform.patiententries.Domain.Model.Aggregates;

public class Patient
{
    public int Id { get; private set; }
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public int AccountId { get; private set; }
    public int ClinicalHistoryId { get; private set; }

    public Patient(string firstName, string lastName, string email, int accountId, int clinicalHistoryId)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        AccountId = accountId;
        ClinicalHistoryId = clinicalHistoryId;
    }

    public void Update(string firstName, string lastName, string email, int accountId, int clinicalHistoryId)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        AccountId = accountId;
        ClinicalHistoryId = clinicalHistoryId;
    }
}