using EventSourcing.Infrastructure;
using EventSourcing.Infrastructure.MultiTenancy;
using EventSourcing.Modules.Games;
using EventSourcing.Modules.Tenants;
using EventSourcing.Persistence;

namespace EventSourcing;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        {
            var services = builder.Services;
            var configuration = builder.Configuration;

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddInfrastructure();
            services.AddPersistence(configuration);
        }

        var app = builder.Build();
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<MultiTenancyMiddleware>();

            app.UseTenantsModule();
            app.UseGamesModule();
        }

        app.Run();
    }
}