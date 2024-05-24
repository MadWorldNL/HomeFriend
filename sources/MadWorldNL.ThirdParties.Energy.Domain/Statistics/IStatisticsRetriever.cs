namespace MadWorldNL.Energy.Statistics;

public interface IStatisticsRetriever
{
    Task<History> RetrieveHistory(DateTime start, DateTime end);
}