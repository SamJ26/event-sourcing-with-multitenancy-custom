using EventSourcing.Infrastructure.MultiTenancy;
using EventSourcing.Persistence.Tenant;
using Microsoft.AspNetCore.Mvc;

namespace EventSourcing.Modules.Games.Endpoints;

public sealed class SubmitAnswerEndpoint
{
    public static async Task<IResult> Handle(
        [FromRoute] int instanceId,
        [FromBody] SubmitAnswerRequest req,
        [FromServices] TenantDbContextFactory tenantDbContextFactory,
        [FromServices] TenantContextProvider tenantContextProvider,
        CancellationToken ct)
    {
        var tenant = tenantContextProvider.Current;

        using (var dbContext = tenantDbContextFactory.Create(tenant.Identifier))
        {
            // var game = dbContext.Events.Aggregate<GameAggregate>();
            // if (game.IsTerminated) {...}

            // dbContext.Events.Add();
            
            await dbContext.SaveChangesAsync(ct);
        }

        return Results.Ok();
    }
}

public record SubmitAnswerRequest(string Text);