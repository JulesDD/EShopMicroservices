namespace Ordering.Infrastructure.Data.Interceptors;

public class AuditableEntityInterceptor : SaveChangesInterceptor
{
    // This interceptor is designed to automatically set the CreatedAt and UpdatedAt properties of entities that implement the IAuditableEntity interface when they are added or modified in the database context.
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        UpdateEntities(eventData.Context);
        return base.SavingChanges(eventData, result);
    }

    // This asynchronous version of the SavingChanges method performs the same function as the synchronous version, but it allows for asynchronous execution.
    // It also calls the UpdateEntities method to set the CreatedAt and UpdatedAt properties of the entities before saving changes to the database.
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        UpdateEntities(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    public void UpdateEntities(DbContext? context)
    {
        if (context is null) return;

        foreach (var entry in context.ChangeTracker.Entries<IEntity>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedBy = "Jules";
                entry.Entity.CreatedAt = DateTime.UtcNow;
            }

            if (entry.State == EntityState.Modified || entry.State == EntityState.Added || entry.HasChangedOwnEntities())
            {
                entry.Entity.UpdatedBy = "Jules";
                entry.Entity.UpdatedAt = DateTime.UtcNow;
            }
        }
    }
}

// This static class provides an extension method for the EntityEntry class, which is used to track changes to entities in the Entity Framework Core context.
// The HasChangedOwnEntities method checks if any of the owned entities related to the current entity have been modified or added, which would indicate that the parent entity should also be considered modified and have its UpdatedAt property updated accordingly.
public static class Extensions
{
    public static bool HasChangedOwnEntities(this EntityEntry entry)
    {
        return entry.References.Any(r => 
            r.TargetEntry != null && 
            r.TargetEntry.Metadata.IsOwned() && 
            (r.TargetEntry.State == EntityState.Modified || r.TargetEntry.State == EntityState.Added));
    }
}
