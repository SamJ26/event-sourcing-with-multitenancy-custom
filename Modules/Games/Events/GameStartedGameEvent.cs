using EventSourcing.Infrastructure.EventSourcing;

namespace EventSourcing.Modules.Games.Events;

public sealed class GameStartedGameEvent : EventBase
{
    public required int GameId { get; init; }
}