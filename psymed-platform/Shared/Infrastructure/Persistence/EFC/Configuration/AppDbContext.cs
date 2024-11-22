using Microsoft.EntityFrameworkCore;

namespace psymed_platform.Shared.Infrastructure.Persistence.EFC.Configuration
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Método genérico para obtener DbSet de cualquier tipo de entidad
        public DbSet<T> SetEntity<T>() where T : class
        {
            return Set<T>();
        }
        
    }
}