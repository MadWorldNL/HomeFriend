namespace MadWorldNL.GreenChoice.Statistics;

public interface IStatisticsService
{
    Task<Consumption> Get(DateTime start, DateTime end);
}