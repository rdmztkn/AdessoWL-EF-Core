using AdessoWL.Application.Interfaces.Repositories;
using AdessoWL.Persistence.Context;
using AdessoWL.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AdessoWL.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ITeamRepository, TeamRepository>();
        services.AddScoped<IDrawRepository, DrawRepository>();

        services.AddDbContext<AdessoWLContext>(opt =>
        {
            var connStr = configuration.GetConnectionString("DefaultConnection");
            opt.EnableDetailedErrors();
            opt.EnableSensitiveDataLogging();
            opt.LogTo(Console.WriteLine);
            opt.UseSqlServer(connStr, sqlOpt =>
            {
                sqlOpt.EnableRetryOnFailure();
            });
        });
    }
}
