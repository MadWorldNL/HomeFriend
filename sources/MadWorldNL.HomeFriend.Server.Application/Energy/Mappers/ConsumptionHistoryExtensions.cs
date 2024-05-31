using MadWorldNL.Energy.Statistics;
using MadWorldNL.HomeFriend.Time;

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
}