using ErrorOr;
using MediatR;
using User.Application.Authentication.Common;

namespace User.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;