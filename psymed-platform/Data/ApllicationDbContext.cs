using psymed_platform.Models;

namespace psymed_platform.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Treatment> Treatments { get; set; }
}