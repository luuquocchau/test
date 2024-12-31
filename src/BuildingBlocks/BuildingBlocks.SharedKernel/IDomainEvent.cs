using MediatR;

namespace BuildingBlocks.SharedKernel;

public interface IDomainEvent : INotification
{
    Guid Id { get; }

    DateTime OccurredOn { get; }

    string EventType { get; }
}
