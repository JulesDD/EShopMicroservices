namespace Ordering.Infrastructure.Data.Interceptors;

public class DispatchDomainEventsInterceptor(IMediator mediator) 
    : SaveChangesInterceptor
{
    // This interceptor is used to dispatch domain events before saving changes to the database.
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        DispatchDomainEvents(eventData.Context).GetAwaiter().GetResult();
        return base.SavingChanges(eventData, result);
    }

    // This method is the asynchronous version of SavingChanges, allowing for asynchronous operations when dispatching domain events.
    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        await DispatchDomainEvents(eventData.Context);
        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    // This method retrieves all domain events from the tracked entities in the DbContext, clears them from the entities, and then publishes them using the mediator.
    public async Task DispatchDomainEvents(DbContext? context)
    {
        if(context is  null) return;

        var aggregates = context.ChangeTracker
            .Entries<IAggregate>()
            .Where(e => e.Entity.DomainEvents.Any())
            .Select(e => e.Entity);

        var domainEvents = aggregates
            .SelectMany(e => e.DomainEvents)
            .ToList();

        aggregates.ToList().ForEach(e => e.ClearDomainEvents());

        foreach (var domainEvent in domainEvents)
                    await mediator.Publish(domainEvent);
    }
}
