namespace psymed_platform.patiententries.Domain.Model.ValueObjects;

public record PhoneNumber(string Number)
{
    public PhoneNumber() : this(string.Empty) { }
}