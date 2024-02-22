using EventSourcing.Persistence.Master;
using EventSourcing.Persistence.Options;
using EventSourcing.Persistence.Tenant;

namespace EventSourcing.Persistence;

public static class ConfigureServices
{
    public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MasterDbContext>();
        services.AddScoped<TenantDbContextFactory>();

        services.AddOptions<ConnectionStringOptions>()
            .Bind(configuration.GetSection("Persistence:ConnectionStringOptions"))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        services.AddOptions<DatabaseOptions>()
            .Bind(configuration.GetSection("Persistence:DatabaseOptions"))
            .ValidateDataAnnotations()
            .ValidateOnStart();
    }
}