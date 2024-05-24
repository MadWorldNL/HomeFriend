using System.Net.Http.Json;
using MadWorldNL.GreenChoice.Authentication;

namespace MadWorldNL.GreenChoice.Statistics;

public sealed class StatisticsService
{
    private const string MyAccountUrl = "https://mijn.greenchoice.nl";
    
    private readonly IAuthenticationService _authenticationService;
    
    public StatisticsService(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    public async Task<Consumption> Get(DateTime start, DateTime end)
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
            $"/api/consumption?interval=day&start={start:yyyy-MM-dd}&end={end:yyyy-MM-dd}");
        
        return await responseStats.Content!.ReadFromJsonAsync<Consumption>() ?? new Consumption();
    }
}