namespace EventSourcing.Infrastructure.MultiTenancy;

public sealed class MultiTenancyMiddleware(TenantContextProvider tenantContextProvider) : IMiddleware
{
    private readonly TenantContextProvider _tenantContextProvider = tenantContextProvider;

    public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
    {
        if (httpContext.Request.Query.TryGetValue("tenant", out var values))
        {
            var tenantIdentifier = values.First();
            if (tenantIdentifier is not null)
            {
                await _tenantContextProvider.InitializeAsync(tenantIdentifier);
            }
        }

        await next(httpContext);
    }
}