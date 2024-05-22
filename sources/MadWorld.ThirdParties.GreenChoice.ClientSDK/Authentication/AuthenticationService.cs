using System.Net.Http.Json;
using HtmlAgilityPack;

namespace MadWorldNL.GreenChoice.Authentication;

public class AuthenticationService
{
    public AuthenticationService()
    {
        
    }

    public async Task LoginAsync(string username, string password)
    {
        var client = new HttpClient();
        client.BaseAddress = new Uri("https://sso.greenchoice.nl");
        var response = await client.GetAsync("/Account/Login");
        var loginPage = await response.Content!.ReadAsStringAsync();

        var doc = new HtmlDocument();
        doc.LoadHtml(loginPage);
        
        var returnUrlNode = doc.DocumentNode.SelectNodes("//input[@name='ReturnUrl']").FirstOrDefault();
        var returnUrl = returnUrlNode!.GetAttributeValue("value", "");
        
        var requestVerificationTokenNode = doc.DocumentNode.SelectNodes("//input[@name='__RequestVerificationToken']").FirstOrDefault();
        var requestVerificationToken = requestVerificationTokenNode!.GetAttributeValue("value", "");
        
        var request = new LoginRequest()
        {
            ReturnUrl = returnUrl,
            Username = "",
            Password = "",
            RequestVerificationToken = requestVerificationToken
        };
        
        var response2 = await client.PostAsJsonAsync("/Account/Login", request);
        var homePage = await response2.Content!.ReadAsStringAsync();
    }
}