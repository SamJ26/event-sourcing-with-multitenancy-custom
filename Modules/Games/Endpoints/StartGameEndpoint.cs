using EventSourcing.Infrastructure.EventSourcing;
using EventSourcing.Infrastructure.MultiTenancy;
using EventSourcing.Modules.Games.Events;
using EventSourcing.Persistence.Tenant;
using EventSourcing.Persistence.Tenant.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EventSourcing.Modules.Games.Endpoints;

public sealed class StartGameEndpoint
{
    public static async Task<IResult> Handle(
        [FromServices] TenantDbContextFactory tenantDbContextFactory,
        [FromServices] TenantContextProvider tenantContextProvider,
        CancellationToken ct)
    {
        var tenant = tenantContextProvider.Current;

        var game = new GameEntity()
        {
            EventStreamId = Guid.NewGuid()
        };

        await using (var dbContext = tenantDbContextFactory.Create(tenant.Identifier))
        {
            dbContext.Add(game);
            await dbContext.SaveChangesAsync(ct);

            var gameEvent = new GameStartedGameEvent()
            {
                GameId = game.Id
            };

            dbContext.Events.AppendEvent(gameEvent, game.EventStreamId);
            await dbContext.SaveChangesAsync(ct);
        }

        return Results.Ok(game.Id);
    }
}