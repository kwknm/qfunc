namespace QFunc.Infrastructure.Identity;

#nullable disable

public class JwtSettings
{
    public const string SectionName = "JwtSettings";
    // General
    public string Secret { get; init; }
    public string Issuer { get; init; }
    public string Audience { get; init; }
    public int ExpiryMinutes { get; init; }
}