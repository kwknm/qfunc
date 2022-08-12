using ErrorOr;
using MediatR;
using QFunc.Application.Common.Interfaces.Identity;
using QFunc.Application.Common.Interfaces.Persistence;
using QFunc.Application.Identity.Common;
using QFunc.Domain.Common.Errors;
using QFunc.Domain.Entities;

namespace QFunc.Application.Identity.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<IdentityResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    
    public async Task<ErrorOr<IdentityResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask; // todo : remove it

        // Validate the user exists
        if (_userRepository.GetUserByUserName(request.UserName) is not User user)
        {
            return Errors.Identity.InvalidCredentials;
        }
        
        // Validate the password
        if (user.PasswordHash != request.Password)
        {
            return Errors.Identity.InvalidCredentials;
        }
        
        // Create JWT
        var token = _jwtTokenGenerator.GenerateToken(user.Id, user.UserName);
        return new IdentityResult
        {
            User = user,
            Token = token
        };
    }
}