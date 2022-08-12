using ErrorOr;
using MediatR;
using QFunc.Application.Identity.Common;

namespace QFunc.Application.Identity.Commands.Register;

public record RegisterCommand(
    string UserName,
    string Email,
    string Password) : IRequest<ErrorOr<IdentityResult>>;