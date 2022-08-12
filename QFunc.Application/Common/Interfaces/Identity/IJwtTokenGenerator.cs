namespace QFunc.Application.Common.Interfaces.Identity;

public interface IJwtTokenGenerator
{
    string GenerateToken(Guid userId, string userName);
}