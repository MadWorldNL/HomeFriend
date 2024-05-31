using MadWorldNL.Energy.Statistics;
using MadWorldNL.GreenChoice.Authentication;
using MadWorldNL.GreenChoice.Statistics;
using Microsoft.Extensions.DependencyInjection;

namespace MadWorldNL.GreenChoice.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddGreenChoiceApi(this IServiceCollection services, Action<Account> configureOptions)
    {
        var account = new Account();
        configureOptions(account);

        services.AddScoped<IAuthenticationService>(_ => new AuthenticationService(account));
        services.AddScoped<IStatisticsService, StatisticsService>();
        services.AddScoped<IEnergyStatisticsRetriever, EnergyStatisticsRetriever>();
    }
}