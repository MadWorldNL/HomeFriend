namespace MadWorldNL.HomeFriend.Energy.Mappers;

public static class GasConsumptionExtensions
{
    public static ConsumptionContract ToDto(this GasConsumption consumption)
    {
        return new ConsumptionContract()
        {
            Cost = consumption.Cost,
            Currency = GasConsumption.Currency,
            Measured = consumption.Measured,
            Timestamp = consumption.TimestampUtc,
            Unit = GasConsumption.Unit
        };
    }
}