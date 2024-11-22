namespace psymed_platform.patiententries.Shared.Exceptions;

public class ClinicalHistoryNotFoundException : Exception
{
    public ClinicalHistoryNotFoundException(string message) : base(message)
    {
    }
}