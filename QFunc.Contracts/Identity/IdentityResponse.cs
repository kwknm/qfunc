namespace QFunc.Contracts.Identity;

#nullable disable

public class IdentityResponse
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Token { get; set; }
}