using Microsoft.EntityFrameworkCore.Design;

namespace EventSourcing.Persistence.Tenant;

public sealed class TenantDbContextDesignTimeFactory : IDesignTimeDbContextFactory<TenantDbContext>
{
    public TenantDbContext CreateDbContext(string[] args)
    {
        const string fakeConnectionString = "ThisDbContextIsOnlyForMigrations";

        return new TenantDbContext(fakeConnectionString);
    }
}