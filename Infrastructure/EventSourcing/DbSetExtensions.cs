using Microsoft.EntityFrameworkCore;

namespace EventSourcing.Infrastructure.EventSourcing;

public static class DbSetExtensions
{
    public static void AppendEvent(this DbSet<Event> dbSet, EventBase e, Guid streamId)
    {
        var @event = new Event()
        {
            Data = e.Serialize(),
            StreamId = streamId
        };

        dbSet.Add(@event);
    }

    public static TAggregate AggregateEvents<TAggregate>(this DbSet<Event> dbSet, Guid streamId)
    {
        var events = dbSet.Where(x => x.StreamId == streamId);

        foreach (var @event in events)
        {
            // TODO: apply event
        }

        // Return aggregate

        throw new NotImplementedException();
    }
}