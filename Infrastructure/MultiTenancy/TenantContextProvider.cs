using EventSourcing.Persistence.Master;
using Microsoft.EntityFrameworkCore;

namespace EventSourcing.Infrastructure.MultiTenancy;

public sealed class TenantContextProvider
{
    private TenantContext? _current;

    private readonly MasterDbContext _masterDbContext;

    public TenantContextProvider(MasterDbContext masterDbContext)
    {
        _masterDbContext = masterDbContext;
    }

    public TenantContext Current => _current ?? throw new Exception("Attempting to access tenant context before initialization!");

    public async Task InitializeAsync(string tenantIdentifier)
    {
        var tenant = await _masterDbContext
            .Tenants
            .FirstOrDefaultAsync(x => x.Identifier == tenantIdentifier);

        if (tenant is null)
        {
            throw new Exception($"Tenant with identifier '{tenantIdentifier}' does not exist!");
        }

        _current = new TenantContext(
            tenant.Id,
            tenant.Name,
            tenant.Identifier);
    }
}

public record TenantContext(
    int Id,
    string Name,
    string Identifier);