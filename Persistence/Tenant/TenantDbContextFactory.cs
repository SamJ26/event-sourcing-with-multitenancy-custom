using EventSourcing.Persistence.Options;
using Microsoft.Extensions.Options;

namespace EventSourcing.Persistence.Tenant;

public sealed class TenantDbContextFactory(
    IOptions<ConnectionStringOptions> connectionStringOptions,
    IOptions<DatabaseOptions> databaseOptions)
{
    private readonly ConnectionStringOptions _connectionStringOptions = connectionStringOptions.Value;
    private readonly DatabaseOptions _databaseOptions = databaseOptions.Value;

    public TenantDbContext Create(string tenantIdentifier)
    {
        var connectionString =
            $"Host={_connectionStringOptions.Host};" +
            $"Port={_connectionStringOptions.Port};" +
            $"Database={_databaseOptions.TenantDatabasePrefix + tenantIdentifier};" +
            $"Username={_connectionStringOptions.Username};" +
            $"Password={_connectionStringOptions.Password}";

        return new TenantDbContext(connectionString);
    }
}