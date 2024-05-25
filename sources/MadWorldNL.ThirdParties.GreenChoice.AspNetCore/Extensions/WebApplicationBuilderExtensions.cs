using MadWorldNL.Energy.Statistics;
using MadWorldNL.GreenChoice.Authentication;
using MadWorldNL.GreenChoice.Statistics;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MadWorldNL.GreenChoice.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static void AddGreenChoiceApi(this WebApplicationBuilder builder, Action<Account> configureOptions)
    {
        var account = new Account();
        configureOptions(account);

        builder.Services.AddScoped<IAuthenticationService>(_ => new AuthenticationService(account));
        builder.Services.AddScoped<IStatisticsService, StatisticsService>();
        builder.Services.AddScoped<IStatisticsRetriever, StatisticsRetriever>();
    }
}