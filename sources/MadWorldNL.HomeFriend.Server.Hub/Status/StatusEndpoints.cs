namespace MadWorldNL.HomeFriend.Status;

public static class StatusEndpoints
{
    public static void AddStatusEndpoints(this WebApplication app)
    {
        var statusBuilder = app.MapGroup("/Status");

        statusBuilder.MapGet("/Healthy", () => HealthyResponse.Ok())
            .WithName("Healthy")
            .WithOpenApi();
    }
}