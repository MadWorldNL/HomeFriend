using MadWorldNL.Energy.Statistics;
using MadWorldNL.HomeFriend.Energy.Mappers;

namespace MadWorldNL.HomeFriend.Energy;

public class ImportConsumptionsUseCase
{
    private readonly IEnergyStatisticsRetriever _statisticsRetriever;
    private readonly IConsumptionRepository _energyRepository;

    public ImportConsumptionsUseCase(IEnergyStatisticsRetriever statisticsRetriever, IConsumptionRepository energyRepository)
    {
        _statisticsRetriever = statisticsRetriever;
        _energyRepository = energyRepository;
    }
    
    public async Task ImportAsync(DateTime start, DateTime ends)
    {
        var now = DateTime.UtcNow;
        var startDate = now.AddDays(-7);
        
        var history = await _statisticsRetriever.RetrieveHistory(start, ends);
        await SaveElectrics(history.ElectricConsumptions, start, ends);
        await SaveGases(history.GasConsumptions, start, ends);
    }

    private async Task SaveElectrics(List<ConsumptionHistory> consumptions, DateTime start, DateTime ends)
    {
        var knownElectrics = _energyRepository.GetElectrics(start, ends);
        var knownDates = knownElectrics
                                        .Select(e => e.TimestampUtc)
                                        .ToList();
        
        var newConsumptions = FilterByUnknownConsumption(consumptions, knownDates);
        
        foreach (var electricConsumption in newConsumptions.Select(newConsumption => newConsumption.ToElectricConsumption()))
        {
            await _energyRepository.Add(electricConsumption);
        }
    }
    
    private async Task SaveGases(List<ConsumptionHistory> consumptions, DateTime start, DateTime ends)
    {
        var knownGases = _energyRepository.GetGases(start, ends);
        var knownDates = knownGases
            .Select(e => e.TimestampUtc)
            .ToList();
        
        var newConsumptions = FilterByUnknownConsumption(consumptions, knownDates);

        foreach (var gasConsumption in newConsumptions.Select(newConsumption => newConsumption.ToGasConsumption()))
        {
            await _energyRepository.Add(gasConsumption);
        }
    }

    private List<ConsumptionHistory> FilterByUnknownConsumption(List<ConsumptionHistory> consumptions, List<DateTime> knownConsumptions)
    {
        return consumptions
            .Where(c => !knownConsumptions
                                        .Select(kc => kc.Date)
                                        .Contains(c.Timestamp.Date))
            .ToList();
    }
}