using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Threading;
using System.Threading.Tasks;
using psymed_platform.Shared.Infrastructure.Persistence.EFC.Configuration.Interfaces;

namespace psymed_platform.Shared.Infrastructure.Persistence.EFC.Configuration.Interceptors
{
    public class CreatedUpdatedInterceptor : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            UpdateTimestamps(eventData.Context);
            return base.SavingChanges(eventData, result);
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            UpdateTimestamps(eventData.Context);
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private void UpdateTimestamps(DbContext context)
        {
            var entries = context.ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                if (entry.Entity is IHasTimestamps entityWithTimestamps)
                {
                    if (entry.State == EntityState.Added)
                    {
                        entityWithTimestamps.CreatedAt = DateTime.UtcNow;
                    }

                    if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                    {
                        entityWithTimestamps.UpdatedAt = DateTime.UtcNow;
                    }
                }
            }
        }
    }
}