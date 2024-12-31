namespace BuildingBlocks.SharedKernel;

public record DomainEventBase : IDomainEvent
{
    public Guid Id => Guid.NewGuid();

    public DateTime OccurredOn => DateTime.Now;

    public string EventType => GetType().AssemblyQualifiedName!;
}
