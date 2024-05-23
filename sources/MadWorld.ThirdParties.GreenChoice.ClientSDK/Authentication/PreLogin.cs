namespace MadWorldNL.GreenChoice.Authentication;

public class PreLogin
{
    public required string LoginUrl { get; set; }
    public required string ReturnUrl { get; set; }
    public required string RequestVerificationToken { get; set; }
}