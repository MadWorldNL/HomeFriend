namespace MadWorldNL.HomeFriend.Energy;

public interface IConsumptionRepository
{
    Task Add(ElectricConsumption consumption);
    Task Add(GasConsumption consumption);
    List<ElectricConsumption> GetElectrics(DateTime start, DateTime ends);
    List<GasConsumption> GetGases(DateTime start, DateTime ends);
}