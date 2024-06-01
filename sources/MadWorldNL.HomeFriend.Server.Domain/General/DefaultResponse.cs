namespace MadWorldNL.HomeFriend.General;

public class DefaultResponse
{
    public bool IsSucceed { get; init; }
    
    public static DefaultResponse OK()
    {
        return new DefaultResponse()
        {
            IsSucceed = true
        };
    }
}