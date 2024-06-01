using Hangfire;

namespace MadWorldNL.HomeFriend.Energy;

public static class ServiceProviderExtensions
{
    public static void AddEnergyJobs(this IServiceProvider services)
    {
        RecurringJob.AddOrUpdate<ImportConsumptionsUseCase>(
            nameof(ImportConsumptionsUseCase),
            useCase => StartImportConsumptions(useCase),
            Cron.Daily(5));
    }

    private static Task StartImportConsumptions(ImportConsumptionsUseCase useCase)
    {
        var now = DateTime.UtcNow;
        var startDate = now.AddDays(-7);

        return useCase.ImportAsync(startDate, now);
    }
}