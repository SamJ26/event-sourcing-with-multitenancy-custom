using EventSourcing.Infrastructure.EventSourcing;

namespace EventSourcing.Modules.Games.Events;

public sealed class GameAnswerSubmittedGameEvent : EventBase
{
    public required int GameId { get; init; }
    public required string Text { get; init; }
}