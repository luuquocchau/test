namespace BuildingBlocks.SharedKernel;

public interface IAggregateRoot<TId> : IAggregateRoot, IEntity<TId>;

public interface IAggregateRoot : IEntity
{
    IReadOnlyList<IDomainEvent> DomainEvents { get; }

    void ClearDomainEvents();
}