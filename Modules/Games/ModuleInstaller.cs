namespace EventSourcing.Modules.Games;

public static class ModuleInstaller
{
    public static void UseGamesModule(this WebApplication app)
    {
        var group = app
            .MapGroup("games")
            .WithTags("Games");

        // group.MapPost(string.Empty, StartGameEndpoint.Handle);
        // group.MapPut("{instanceId:int}/submit-answer", SubmitAnswerEndpoint.Handle);
        // group.MapPut("{instanceId:int}/terminate", TerminateGameEndpoint.Handle);
    }
}