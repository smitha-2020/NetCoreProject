using Microsoft.EntityFrameworkCore.Diagnostics;
using project.Models;
using Microsoft.EntityFrameworkCore;

namespace project.DB;

public class AppDBContextInterceptor : SaveChangesInterceptor
{
    public void UpdateTimestamp(DbContextEventData eventData)
    {
        var entries = eventData.Context!.ChangeTracker
        .Entries()
        .Where(e => e.Entity is BaseModel && (e.State == EntityState.Added || e.State == EntityState.Modified));

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                ((BaseModel)entry.Entity).createdAt = DateTime.Now;
            }
            else
            {
                ((BaseModel)entry.Entity).updatedAt = DateTime.Now;
            }
        }
    }
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        UpdateTimestamp(eventData);
        return base.SavingChanges(eventData, result);
    }
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        UpdateTimestamp(eventData);
        return base.SavingChangesAsync(eventData, result);
    }
}