using BullPerksTask.Domain.Services;

namespace BullPerksTask.Domain;

public static class DependencyInjection
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddScoped<GetTokenEntityDomainService>();

        return services;
    }
}
