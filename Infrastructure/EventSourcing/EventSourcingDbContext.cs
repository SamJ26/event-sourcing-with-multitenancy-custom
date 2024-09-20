using Microsoft.EntityFrameworkCore;

namespace EventSourcing.Infrastructure.EventSourcing;

public class EventSourcingDbContext : DbContext
{
    public DbSet<Event> Events { get; init; } = null!;
}