﻿using MassTransit.Saga.Demo.TransportationService.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MassTransit.Saga.Demo.TransportationService.Configuration.Services;

internal static class ConfigurePersistenceExtensions
{
    public static void AddCustomPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionstring = configuration.GetConnectionString("flight-database");
        services.AddDbContext<FlightDbContext>(builder =>
            builder.UseSqlServer(connectionstring));

        // So we don't need to use ef migrations for this sample.
        // Likely if you are going to deploy to a production environment, you want a better DB deploy strategy.
        services.AddHostedService<EfDbCreatedHostedService>();
    }
}