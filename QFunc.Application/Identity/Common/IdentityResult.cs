using QFunc.Domain.Entities;

namespace QFunc.Application.Identity.Common;

#nullable disable

public class IdentityResult
{
    public User User { get; set; }
    public string Token { get; set; }
}