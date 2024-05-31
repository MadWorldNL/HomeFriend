namespace MadWorldNL.HomeFriend.Energy;

public class GetEnergyHistoryResponse
{
    public List<ConsumptionContract> ElectricConsumptions { get; init; } = [];
    public List<ConsumptionContract> GasConsumptions { get; init; } = [];
}