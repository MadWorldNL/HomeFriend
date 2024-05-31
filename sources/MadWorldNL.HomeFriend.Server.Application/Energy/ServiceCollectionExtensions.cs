using Microsoft.Extensions.DependencyInjection;

namespace MadWorldNL.HomeFriend.Energy;

public static class ServiceCollectionExtensions
{
    public static void AddEnergyApplication(this IServiceCollection services)
    {
        services.AddScoped<GetEnergyHistoryUseCase>();
    }
}