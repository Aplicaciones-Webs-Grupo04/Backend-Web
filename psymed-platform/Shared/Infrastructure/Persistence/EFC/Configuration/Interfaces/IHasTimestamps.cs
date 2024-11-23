namespace psymed_platform.Shared.Infrastructure.Persistence.EFC.Configuration.Interfaces
{
    public interface IHasTimestamps
    {
        DateTime CreatedAt { get; set; }
        DateTime UpdatedAt { get; set; }
    }
}