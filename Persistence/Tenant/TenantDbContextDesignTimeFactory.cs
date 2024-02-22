using EventSourcing.Persistence.Options;
using Microsoft.EntityFrameworkCore.Design;

namespace EventSourcing.Persistence.Tenant;

public sealed class TenantDbContextDesignTimeFactory : IDesignTimeDbContextFactory<TenantDbContext>
{
    public TenantDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddUserSecrets<TenantDbContextDesignTimeFactory>()
            .Build();

        var connectionStringOptions = configuration
            .GetSection("Persistence:" + nameof(ConnectionStringOptions))
            .Get<ConnectionStringOptions>()!;

        var databaseOptions = configuration
            .GetSection("Persistence:" + nameof(DatabaseOptions))
            .Get<DatabaseOptions>()!;

        var connectionString =
            $"Host={connectionStringOptions.Host};" +
            $"Port={connectionStringOptions.Port};" +
            $"Database={databaseOptions.TenantDatabasePrefix + "xxx"};" +
            $"Username={connectionStringOptions.Username};" +
            $"Password={connectionStringOptions.Password}";

        return new TenantDbContext(connectionString);
    }
}