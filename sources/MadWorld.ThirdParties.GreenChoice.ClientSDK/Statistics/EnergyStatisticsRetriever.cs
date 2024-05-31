using MadWorldNL.Energy.Statistics;

namespace MadWorldNL.GreenChoice.Statistics;

public class EnergyStatisticsRetriever(IStatisticsService statisticsService) : IEnergyStatisticsRetriever
{
    public async Task<History> RetrieveHistory(DateTime start, DateTime end)
    {
        var consumption = await statisticsService.Get(start, end);

        return new History()
        {
            ElectricConsumptions = MapToTypeConsumption(consumption, "electricity"),
            GasConsumptions = MapToTypeConsumption(consumption, "gas"),
        };
    }

    private List<ConsumptionHistory> MapToTypeConsumption(Consumption consumption, string type)
    {
        var fuel = consumption
                                .Entries
                                .FirstOrDefault(e => e.ProductType == type);

        if (fuel is null)
        {
            return [];
        }
        
        return fuel
                .Values
                .Select(g => MapToConsumptionHistory(g.Value, g.Key, fuel.UnitType))
                .ToList();
    }

    private ConsumptionHistory MapToConsumptionHistory(CostSummary summary, DateTime timestamp, string unit)
    {
        return new ConsumptionHistory()
        {
            Timestamp = timestamp,
            TotalConsumption = summary.ConsumptionTotal,
            TotalCost = summary.CostsTotal,
            Unit = unit
        };
    }
}