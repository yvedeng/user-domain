using MediatR;
using Microsoft.AspNetCore.Mvc;
using User.Application.Authentication.Commands.Register;
using User.Application.Authentication.Common;
using User.Application.Authentication.Queries.Login;
using User.Contracts.Authentication;

namespace User.Api.Controllers;


[Route("auth")]
public class AuthenticationController: ApiController
{
    private readonly ISender _mediator;

    public AuthenticationController(
        ISender mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(RegisterRequest request)
    {
        var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);
        
        var registerResult = await _mediator.Send(command);

        return registerResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors)
        );
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(LoginRequest request)
    {
        var query = new LoginQuery(request.Email, request.Password);
        var loginResult = await _mediator.Send(query);

        return loginResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors));
    }

    private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
    {
        return new AuthenticationResponse(authResult.User.Id, authResult.User.FirstName, authResult.User.LastName,
            authResult.User.Email, authResult.Token);
    }
}