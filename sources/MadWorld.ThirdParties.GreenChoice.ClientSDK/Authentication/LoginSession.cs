using System.Net;

namespace MadWorldNL.GreenChoice.Authentication;

public class LoginSession
{
    public required CookieContainer Cookies { get; set; }
}