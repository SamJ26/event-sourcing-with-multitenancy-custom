namespace EventSourcing.Persistence.Tenant.Entities;

public sealed class GameEntity : EntityBase
{
    public required Guid EventStreamId { get; init; }
}