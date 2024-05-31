using MadWorldNL.Energy.Statistics;

namespace MadWorldNL.HomeFriend.Energy.Mappers;

public static class ConsumptionHistoryExtensions
{
    public static ElectricConsumption ToElectricConsumption(this ConsumptionHistory consumption)
    {
        return new ElectricConsumption()
        {
            Cost = consumption.TotalCost,
            Measured = consumption.TotalConsumption,
            TimestampUtc = consumption.Timestamp.ConvertToUtc()
        };
    }
    
    public static GasConsumption ToGasConsumption(this ConsumptionHistory consumption)
    {
        return new GasConsumption()
        {
            Cost = consumption.TotalCost,
            Measured = consumption.TotalConsumption,
            TimestampUtc = consumption.Timestamp.ConvertToUtc()
        };
    }

    private static DateTime ConvertToUtc(this DateTime dateTime)
    {
        return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0, DateTimeKind.Utc);
    }
}