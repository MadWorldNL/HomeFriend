using MadWorldNL.HomeFriend.General;
using MadWorldNL.HomeFriend.Time;
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
        
        energyBuilder.MapPost("/StartImportHistory",
            async ([FromServices] ImportConsumptionsUseCase useCase, [FromBody] PostStartImportHistoryRequest request) =>
            {
                await useCase.ImportAsync(request.Start.ConvertToUtc(), request.End.ConvertToUtc());

                return DefaultResponse.OK();
            })
            .WithName("StartImportHistory")
            .WithOpenApi();
    }
}