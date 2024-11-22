namespace psymed_platform.patiententries.Shared.Helpers;

public static class ValidationHelper
{
    public static bool IsValidEmail(string email)
    {
        return email.Contains("@") && email.Contains(".");
    }
}