using EventSourcing.Persistence.Options;
using Microsoft.EntityFrameworkCore.Design;
using OptionsPattern = Microsoft.Extensions.Options.Options;

namespace EventSourcing.Persistence.Master;

public sealed class MasterDbContextDesignTimeFactory : IDesignTimeDbContextFactory<MasterDbContext>
{
    public MasterDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddUserSecrets<MasterDbContextDesignTimeFactory>()
            .Build();

        var connectionStringOptions = configuration
            .GetSection("Persistence:" + nameof(ConnectionStringOptions))
            .Get<ConnectionStringOptions>()!;

        var databaseOptions = configuration
            .GetSection("Persistence:" + nameof(DatabaseOptions))
            .Get<DatabaseOptions>()!;

        return new MasterDbContext(OptionsPattern.Create(connectionStringOptions), OptionsPattern.Create(databaseOptions));
    }
}