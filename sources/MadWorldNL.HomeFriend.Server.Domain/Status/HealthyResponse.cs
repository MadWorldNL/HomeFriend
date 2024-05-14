namespace MadWorldNL.HomeFriend.Status;

public class HealthyResponse
{
    public bool IsHealth { get; init; }

    public static HealthyResponse Ok()
    {
        return new HealthyResponse()
        {
            IsHealth = true
        };
    }
}