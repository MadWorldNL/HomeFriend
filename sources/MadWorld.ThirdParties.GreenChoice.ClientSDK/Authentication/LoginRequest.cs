using System.Text.Json.Serialization;

namespace MadWorldNL.GreenChoice.Authentication;

public class LoginRequest
{
    public required string ReturnUrl { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
    
    [JsonPropertyName("__RequestVerificationToken")]
    public required string RequestVerificationToken { get; set; }
    public bool RememberLogin { get; set; }
}