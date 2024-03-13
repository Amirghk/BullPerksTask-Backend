using BullPerksTask.Application.Commands;
using BullPerksTask.Application.Queries;
using BullPerksTask.Domain;
using Microsoft.Extensions.Options;

namespace BullPerksTask.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, ConfigurationManager configuration)
    {
        var blpSettings = new BLPSettings();
        configuration.Bind(BLPSettings.SectionName, blpSettings);

        services.AddSingleton(Options.Create(blpSettings));

        services.AddScoped<CalculateTokenSupplyAndPersistToDatabaseAppService>();

        services.AddScoped<GetTokenInfoAppService>();

        return services;
    }
}
