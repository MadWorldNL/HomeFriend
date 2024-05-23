namespace MadWorldNL.GreenChoice.Authentication;

public interface IAuthenticationService
{
    Task<LoginSession> LoginAsync();
}