using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QFunc.Application.Identity.Commands.Register;
using QFunc.Application.Identity.Common;
using QFunc.Application.Identity.Queries.Login;
using QFunc.Contracts.Identity;

namespace QFunc.Api.Controllers;

[Route("api/identity")]
public class IdentityController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    
    public IdentityController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);
        var result = await _mediator.Send(command);

        return result.Match(
            res => Ok(_mapper.Map<IdentityResponse>(res)),
            Problem);
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = _mapper.Map<LoginQuery>(request);
        var result = await _mediator.Send(query);
        
        return result.Match(
            res => Ok(_mapper.Map<IdentityResponse>(res)),
            Problem);
    }
}