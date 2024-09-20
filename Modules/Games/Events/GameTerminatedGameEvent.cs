using EventSourcing.Infrastructure.EventSourcing;

namespace EventSourcing.Modules.Games.Events;

public sealed class GameTerminatedGameEvent : EventBase
{
    public required int GameId { get; init; }
}