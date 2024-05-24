namespace MadWorldNL.Energy.Statistics;

public class ConsumptionHistory
{
    public DateTime Timestamp { get; init; }

    public string Unit { get; init; } = string.Empty;
    public float TotalConsumption { get; init; }
    public float TotalCost { get; init; }
}