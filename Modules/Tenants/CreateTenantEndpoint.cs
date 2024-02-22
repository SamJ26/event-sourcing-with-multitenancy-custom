using EventSourcing.Persistence.Master;
using EventSourcing.Persistence.Master.Entities;
using EventSourcing.Persistence.Tenant;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventSourcing.Modules.Tenants;

public sealed class CreateTenantEndpoint
{
    public static async Task<IResult> Handle(
        [FromBody] CreateTenantRequest req,
        [FromServices] MasterDbContext masterDbContext,
        [FromServices] TenantDbContextFactory tenantDbContextFactory,
        CancellationToken ct)
    {
        // Create new tenant in master database
        var tenant = new TenantEntity()
        {
            Name = req.Name,
            Identifier = req.TenantIdentifier
        };

        masterDbContext.Add(tenant);
        await masterDbContext.SaveChangesAsync(ct);

        // Create database for the new tenant
        await using (var dbContext = tenantDbContextFactory.Create(tenant.Identifier))
        {
            await dbContext.Database.MigrateAsync(ct);
        }

        return Results.Ok(tenant.Id);
    }
}

public record CreateTenantRequest(
    string Name,
    string TenantIdentifier);