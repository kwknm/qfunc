namespace QFunc.Contracts.Identity;

#nullable disable

public class LoginRequest
{
    public string UserName { get; set; }
    public string Password { get; set; }
}