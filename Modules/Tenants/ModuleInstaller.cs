namespace EventSourcing.Modules.Tenants;

public static class ModuleInstaller
{
    public static void UseTenantsModule(this WebApplication app)
    {
        var group = app
            .MapGroup("tenants")
            .WithTags("Tenants");

        group.MapPost(string.Empty, CreateTenantEndpoint.Handle);
    }
}