namespace MadWorldNL.HomeFriend.Energy;

public class ElectricConsumption
{
    public Guid Id { get; set; }
    public DateTime TimestampUtc { get; set; }
    public float Measured { get; set; }
    public float Cost { get; set; }

    public const string Currency = "Euro";
    public const string Unit = "kWh";
}