using EventSourcing.Infrastructure.MultiTenancy;

namespace EventSourcing.Infrastructure;

public static class ConfigureServices
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<MultiTenancyMiddleware>();
        services.AddScoped<TenantContextProvider>();
    }
}