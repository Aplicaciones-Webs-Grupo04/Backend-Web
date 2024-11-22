namespace psymed_platform.patiententries.Shared.Helpers;

public static class DateTimeHelper
{
    public static string FormatToIso(this DateTime dateTime)
    {
        return dateTime.ToString("yyyy-MM-ddTHH:mm:ssZ");
    }
}