namespace MadWorldNL.HomeFriend.Energy.Mappers;

public static class ElectricConsumptionExtensions
{
    public static ConsumptionContract ToDto(this ElectricConsumption consumption)
    {
        return new ConsumptionContract()
        {
            Cost = consumption.Cost,
            Currency = ElectricConsumption.Currency,
            Measured = consumption.Measured,
            Timestamp = consumption.TimestampUtc,
            Unit = ElectricConsumption.Unit
        };
    }
}