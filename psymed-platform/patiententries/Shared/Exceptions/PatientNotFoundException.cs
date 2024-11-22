namespace psymed_platform.patiententries.Shared.Exceptions;

public class PatientNotFoundException : Exception
{
    public PatientNotFoundException(string message) : base(message)
    {
    }
}