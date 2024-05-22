using System.Net.Http.Json;
using HtmlAgilityPack;

namespace MadWorldNL.GreenChoice.Authentication;

public class AuthenticationService
{
    private const string SsoUrl =
        "https://sso.greenchoice.nl/Account/Login?ReturnUrl=/connect/authorize/callback?client_id=app-mijngreenchoice&redirect_uri=https%3A%2F%2Fmijn.greenchoice.nl%2Fsignin-oidc&response_type=code&scope=openid%20profile%20id&code_challenge={0}&code_challenge_method=S256&response_mode=form_post&nonce={1}&x-client-SKU=ID_NET8_0&x-client-ver=7.1.2.0";
    
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