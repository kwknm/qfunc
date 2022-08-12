using ErrorOr;
using MediatR;
using QFunc.Application.Identity.Common;

namespace QFunc.Application.Identity.Queries.Login;

public record LoginQuery(
    string UserName,
    string Password) : IRequest<ErrorOr<IdentityResult>>;