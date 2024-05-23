using System.Net;
using System.Web;
using HtmlAgilityPack;

namespace MadWorldNL.GreenChoice.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private const string MyAccountUrl = "https://mijn.greenchoice.nl";
    private const string SsoUrl = "https://sso.greenchoice.nl";
    
    private readonly CookieContainer _cookies = new();
    private readonly HttpClientHandler _handler = new();

    private readonly HttpClient _myAccountClient;
    private readonly HttpClient _ssoClient;
    
    private readonly Account _account;
    
    public AuthenticationService(Account account)
    {
        _account = account;
        FinaliseHttpHandler();

        _myAccountClient = new HttpClient(_handler)
        {
            BaseAddress = new Uri(MyAccountUrl)
        };

        _ssoClient = new HttpClient(_handler)
        {
            BaseAddress = new Uri(SsoUrl)
        };
    }

    public async Task<LoginSession> LoginAsync()
    {
        var ssoSession = await LoginSsoAsync(_account.Username, _account.Password);
        await LoginAccountAsync(ssoSession);

        return new LoginSession()
        {
            Cookies = _cookies
        };
    }

    private async Task LoginAccountAsync(SsoSession ssoSession)
    {
        var signinformContent = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("code", ssoSession.Code),
            new KeyValuePair<string, string>("scope", ssoSession.Scope),
            new KeyValuePair<string, string>("state", ssoSession.State),
            new KeyValuePair<string, string>("session_state", ssoSession.SessionState),
            new KeyValuePair<string, string>("iss", ssoSession.Issued),
        });

        await _myAccountClient.PostAsync("/signin-oidc", signinformContent);
    }

    private async Task<SsoSession> LoginSsoAsync(string username, string password)
    {
        var preLoginInfo = await GetPreLoginInfoAsync();
        var ssoSession = await GetTokenFromLoginAsync(preLoginInfo, username, password);
        return ssoSession;
    }

    private async Task<SsoSession> GetTokenFromLoginAsync(PreLogin preLogin, string username, string password)
    {
        var firstLoginformContent = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("ReturnUrl", preLogin.ReturnUrl), 
            new KeyValuePair<string, string>("Username", username),
            new KeyValuePair<string, string>("Password", password),
            new KeyValuePair<string, string>("__RequestVerificationToken", preLogin.RequestVerificationToken),
            new KeyValuePair<string, string>("RememberLogin", "false")
        });
        
        var firstLoginResponse = await _ssoClient.PostAsync(preLogin.LoginUrl, firstLoginformContent);
        var secondLoginResponse = await _ssoClient.GetAsync(firstLoginResponse!.RequestMessage!.RequestUri!.PathAndQuery);
        var secondLoginPage = await secondLoginResponse.Content!.ReadAsStringAsync();
        
        var doc = new HtmlDocument();
        doc.LoadHtml(secondLoginPage);
        
        var codeNode = doc.DocumentNode.SelectNodes("//input[@name='code']").FirstOrDefault();
        var code = codeNode!.GetAttributeValue("value", "");
        
        var scopeNode = doc.DocumentNode.SelectNodes("//input[@name='scope']").FirstOrDefault();
        var scope = scopeNode!.GetAttributeValue("value", "");
        
        var stateNode = doc.DocumentNode.SelectNodes("//input[@name='state']").FirstOrDefault();
        var state = stateNode!.GetAttributeValue("value", "");
        
        var sessionStateNode = doc.DocumentNode.SelectNodes("//input[@name='session_state']").FirstOrDefault();
        var sessionState = sessionStateNode!.GetAttributeValue("value", "");
        
        var issNode = doc.DocumentNode.SelectNodes("//input[@name='iss']").FirstOrDefault();
        var iss = issNode!.GetAttributeValue("value", "");
        
        return new SsoSession()
        {
            Code = code,
            Scope = scope,
            State = state,
            SessionState = sessionState,
            Issued = iss
        };
    }

    private async Task<PreLogin> GetPreLoginInfoAsync()
    {
        var redirectResponse = await _myAccountClient.GetAsync("/");
        var loginPage = await redirectResponse.Content!.ReadAsStringAsync();

        var doc = new HtmlDocument();
        doc.LoadHtml(loginPage);
        
        var returnUrlNode = doc.DocumentNode.SelectNodes("//input[@name='ReturnUrl']").FirstOrDefault();
        var returnUrl = returnUrlNode!.GetAttributeValue("value", "");
        
        var requestVerificationTokenNode = doc.DocumentNode.SelectNodes("//input[@name='__RequestVerificationToken']").FirstOrDefault();
        var requestVerificationToken = requestVerificationTokenNode!.GetAttributeValue("value", "");
        return new PreLogin()
        {
            LoginUrl = redirectResponse!.RequestMessage!.RequestUri!.PathAndQuery,
            ReturnUrl =  HttpUtility.HtmlDecode(returnUrl),
            RequestVerificationToken = requestVerificationToken
        };
    }

    private void FinaliseHttpHandler()
    {
        _handler.CookieContainer = _cookies;
    }
}