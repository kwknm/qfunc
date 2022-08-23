using ErrorOr;
using MediatR;
using QFunc.Application.Common.Interfaces.Identity;
using QFunc.Application.Common.Interfaces.Persistence;
using QFunc.Application.Identity.Common;
using QFunc.Domain.Common.Errors;
using QFunc.Domain.Entities;

namespace QFunc.Application.Identity.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<IdentityResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<IdentityResult>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask; // todo : remove it
        
        // Check if user already exists
        if (_userRepository.GetByUserName(request.UserName) is not null)
        {
            return Errors.User.DuplicateUserName;
        }
        if ( _userRepository.GetByEmail(request.Email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }
        
        // Create user
        var user = new User
        {
            Email = request.Email,
            UserName = request.UserName,
            // Todo : Password Hashing
            PasswordHash = request.Password
        };
        _userRepository.Add(user);
        
        // Generate token
        var token = _jwtTokenGenerator.GenerateToken(user.Id, user.UserName);
        return new IdentityResult
        {
            User = user,
            Token = token
        };
    }
}