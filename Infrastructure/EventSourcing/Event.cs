namespace EventSourcing.Infrastructure.EventSourcing;

public sealed class Event
{
    public DateTime TimeStamp { get; } = DateTime.UtcNow;
    public required Guid StreamId { get; init; }
    public required string Data { get; init; }
}