namespace MadWorldNL.HomeFriend.Energy;

public sealed class ConsumptionContract
{
    public float Cost { get; init; }
    public string Currency { get; init; } = string.Empty;
    public float Measured { get; init; }
    public DateTime Timestamp { get; init; }
    public string Unit { get; init; } = string.Empty;
}