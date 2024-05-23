using MadWorldNL.GreenChoice.Authentication;

namespace MadWorldNL.GreenChoice.Statistics;

public class StatisticsService
{
    private const string MyAccountUrl = "https://mijn.greenchoice.nl";
    
    private readonly IAuthenticationService _authenticationService;
    
    public StatisticsService(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    public async Task<string> Get()
    {
        var session = await _authenticationService.LoginAsync();

        var handler = new HttpClientHandler()
        {
            CookieContainer = session.Cookies
        };

        var client = new HttpClient(handler)
        {
            BaseAddress = new Uri(MyAccountUrl)
        };
        
        var responseStats = await client.GetAsync(
            "/api/consumption?interval=day&start=2024-05-01&end=2024-06-01");
        return await responseStats.Content!.ReadAsStringAsync();
    }
}