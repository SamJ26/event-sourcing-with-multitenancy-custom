using EventSourcing.Infrastructure.EventSourcing;
using EventSourcing.Persistence.Tenant.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventSourcing.Persistence.Tenant;

public sealed class TenantDbContext(string connectionString) : EventSourcingDbContext
{
    private readonly string _connectionString = connectionString;

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseNpgsql(_connectionString);
    }

    public DbSet<GameEntity> Games { get; init; } = null!;
}