using MadWorldNL.HomeFriend.Energy.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MadWorldNL.HomeFriend.Energy;

public static class ServiceCollectionExtensions
{
    public static void AddEnergyInfrastructure(this IServiceCollection services, EnergyOptions options)
    {
        services.AddScoped<IConsumptionRepository, ConsumptionRepository>();
        
        services.AddDbContext<EnergyDbContext>(dbOptions =>
            dbOptions.UseNpgsql(
                options.DbConnectionString,
                b => b.MigrationsAssembly(typeof(IInfrastructureMarker).Assembly.GetName().Name)));
    }
}