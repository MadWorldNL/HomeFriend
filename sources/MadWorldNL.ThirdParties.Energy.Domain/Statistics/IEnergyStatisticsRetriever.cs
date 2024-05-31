namespace MadWorldNL.Energy.Statistics;

public interface IEnergyStatisticsRetriever
{
    Task<History> RetrieveHistory(DateTime start, DateTime end);
}