namespace MadWorldNL.GreenChoice.Statistics;

public sealed class Fuel
{
    public string ProductType { get; set; } = string.Empty;
    public string UnitType { get; set; } = string.Empty;
    public Dictionary<DateTime, CostSummary> Values { get; set; } = new();
    public CostSummary Total { get; set; } = new();
}