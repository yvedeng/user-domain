using ErrorOr;
using MediatR;
using User.Application.Authentication.Common;

namespace User.Application.Authentication.Queries.Login;

public record LoginQuery(
    string Email, 
    string Password): IRequest<ErrorOr<AuthenticationResult>>;