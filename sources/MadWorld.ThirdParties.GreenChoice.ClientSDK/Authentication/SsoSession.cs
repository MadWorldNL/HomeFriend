namespace MadWorldNL.GreenChoice.Authentication;

public class SsoSession
{
    public required string Code { get; set; }
    public required string Scope { get; set; }
    public required string State { get; set; }
    public required string SessionState { get; set; }
    public required string Issued { get; set; }
}