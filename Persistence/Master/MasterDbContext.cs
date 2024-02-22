using EventSourcing.Persistence.Master.Entities;
using EventSourcing.Persistence.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EventSourcing.Persistence.Master;

public sealed class MasterDbContext : DbContext
{
    private readonly string _connectionString;

    public MasterDbContext(
        IOptions<ConnectionStringOptions> connectionStringOptions,
        IOptions<DatabaseOptions> databaseOptions)
    {
        _connectionString =
            $"Host={connectionStringOptions.Value.Host};" +
            $"Port={connectionStringOptions.Value.Port};" +
            $"Database={databaseOptions.Value.MasterDatabaseName};" +
            $"Username={connectionStringOptions.Value.Username};" +
            $"Password={connectionStringOptions.Value.Password}";
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseNpgsql(_connectionString);
    }

    public DbSet<TenantEntity> Tenants { get; init; } = null!;
}