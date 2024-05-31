using Hangfire;

namespace MadWorldNL.HomeFriend.Energy;

public static class ServiceProviderExtensions
{
    public static void AddEnergyJobs(this IServiceProvider services)
    {
        RecurringJob.AddOrUpdate<ImportConsumptionsUseCase>(
            nameof(ImportConsumptionsUseCase),
            useCase => useCase.ImportAsync(),
            Cron.Daily(5));
    }
}