namespace BuildingBlocks.Messaging.Events;

// This acts as a DTO designed to communicate state changes across different bounded microservices.  
public record IntegrationEvent
{
    public Guid Id => Guid.NewGuid();
    public DateTime OccuredOn => DateTime.UtcNow;
    public string EventType => GetType().AssemblyQualifiedName;
}