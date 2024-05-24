namespace MadWorldNL.Energy.Statistics;

public class History
{
    public List<ConsumptionHistory> ElectricConsumptions { get; init; } = [];
    public List<ConsumptionHistory> GasConsumptions { get; init; } = [];
}