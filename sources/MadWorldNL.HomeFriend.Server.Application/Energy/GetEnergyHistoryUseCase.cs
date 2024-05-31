using MadWorldNL.HomeFriend.Time;

namespace MadWorldNL.HomeFriend.Energy;

public class GetEnergyHistoryUseCase
{
    private readonly IConsumptionRepository _consumptionRepository;

    public GetEnergyHistoryUseCase(IConsumptionRepository consumptionRepository)
    {
        _consumptionRepository = consumptionRepository;
    }
    
    public GetEnergyHistoryResponse GetEnergyHistory(GetEnergyHistoryRequest request)
    {
        request.Start = request.Start.ConvertToUtc();
        request.End = request.End.ConvertToUtc();
        
        var electricConsumptions = _consumptionRepository.GetElectrics(request.Start, request.End);
        var gasConsumptions = _consumptionRepository.GetGases(request.Start, request.End);

        return new GetEnergyHistoryResponse();
    }
}