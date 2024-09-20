using EventSourcing.Modules.Games.Events;

namespace EventSourcing;

public sealed class GameAggregate
{
    public int Id { get; private set; }
    public bool IsTerminated { get; private set; }
    public string Answer { get; private set; } = null!;

    public void Apply(GameStartedGameEvent e)
    {
        Id = e.GameId;
    }

    public void Apply(GameAnswerSubmittedGameEvent e)
    {
        Answer = e.Text;
    }

    public void Apply(GameTerminatedGameEvent _)
    {
        IsTerminated = true;
    }

    public override string ToString()
    {
        return $"{{ Id: {Id}, IsTerminated: {IsTerminated}, Answer: {Answer} }}";
    }
}