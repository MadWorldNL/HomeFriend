using Microsoft.AspNetCore.Mvc;

namespace MadWorldNL.HomeFriend.Energy;

public static class EnergyEndpoints
{
    public static void AddEnergyEndpoints(this WebApplication app)
    {
        var energyBuilder = app.MapGroup("/Energy");
        
        energyBuilder.MapGet("/EnergyHistory", 
                ([FromServices]GetEnergyHistoryUseCase useCase, [AsParameters] GetEnergyHistoryRequest request) => 
                    useCase.GetEnergyHistory(request))
            .WithName("EnergyHistory")
            .WithOpenApi();
    }
}