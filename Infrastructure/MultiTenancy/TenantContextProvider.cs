using EventSourcing.Persistence.Master;
using Microsoft.EntityFrameworkCore;

namespace EventSourcing.Infrastructure.MultiTenancy;

public sealed class TenantContextProvider
{
    private readonly MasterDbContext _masterDbContext;

    public TenantContextProvider(MasterDbContext masterDbContext)
    {
        _masterDbContext = masterDbContext;
    }

    public TenantContext? Current { get; private set; }

    public async Task InitializeAsync(string tenantIdentifier)
    {
        var tenant = await _masterDbContext
            .Tenants
            .FirstOrDefaultAsync(x => x.Identifier == tenantIdentifier);

        if (tenant is null)
        {
            throw new Exception($"Tenant with identifier '{tenantIdentifier}' does not exist!");
        }

        Current = new TenantContext(
            tenant.Id,
            tenant.Name,
            tenant.Identifier);
    }
}

public record TenantContext(
    int Id,
    string Name,
    string Identifier);