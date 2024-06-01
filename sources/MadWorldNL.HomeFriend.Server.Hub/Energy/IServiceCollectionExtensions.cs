using Hangfire;

namespace MadWorldNL.HomeFriend.Energy;

public static class ServiceProviderExtensions
{
    public static void AddEnergyJobs(this IServiceProvider _)
    {
        RecurringJob.AddOrUpdate<ImportConsumptionsUseCase>(
            nameof(ImportConsumptionsUseCase),
            useCase => useCase.ImportAsync(DateTime.UtcNow, DateTime.UtcNow.AddDays(-7)),
            Cron.Daily(5));
    }
}