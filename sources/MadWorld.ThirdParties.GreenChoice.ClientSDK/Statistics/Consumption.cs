namespace MadWorldNL.GreenChoice.Statistics;

public sealed class Consumption
{
    public string Interval { get; set; } = string.Empty;
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public Fuel[] Entries { get; set; } = [];
}