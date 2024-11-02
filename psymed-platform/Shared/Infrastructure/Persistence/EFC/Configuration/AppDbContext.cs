using Microsoft.EntityFrameworkCore;

namespace psymed_platform.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options) {
    
    
}