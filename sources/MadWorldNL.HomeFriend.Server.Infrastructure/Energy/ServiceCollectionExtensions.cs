using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MadWorldNL.HomeFriend.Energy;

public static class ServiceCollectionExtensions
{
    public static void AddEnergyInfrastructure(this IServiceCollection services, EnergyOptions options)
    {
        services.AddDbContext<EnergyDbContext>(dbOptions =>
            dbOptions.UseNpgsql(options.DbConnectionString));
    }
}