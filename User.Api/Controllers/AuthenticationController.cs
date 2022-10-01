using FluentValidation;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using User.Application.Authentication.Commands.Register;
using User.Application.Authentication.Queries.Login;
using User.Contracts.Authentication;

namespace User.Api.Controllers;


[Route("auth")]
public class AuthenticationController: ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public AuthenticationController(
        ISender mediator,
        IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(
        RegisterRequest request, 
        [FromServices] IValidator<RegisterRequest> validator)
    {
        var validationResult = await validator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            var modelStateDictionary = new ModelStateDictionary();
            foreach (var failure in validationResult.Errors)
            {
                modelStateDictionary.AddModelError(
                    failure.PropertyName, 
                    failure.ErrorMessage);
            }
            return ValidationProblem(modelStateDictionary);
        }
        var command = _mapper.Map<RegisterCommand>(request);
        var registerResult = await _mediator.Send(command);
        
        return registerResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors)
        );
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(LoginRequest request)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }
        
        var query = _mapper.Map<LoginQuery>(request);
        var loginResult = await _mediator.Send(query);

        return loginResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors));
    }
}