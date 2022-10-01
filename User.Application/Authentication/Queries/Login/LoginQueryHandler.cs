using ErrorOr;
using MediatR;
using User.Application.Authentication.Common;
using User.Application.Common.Interfaces.Authentication;
using User.Application.Common.Interfaces.Persistence;
using User.Domain.Common.Errors;
using User.Domain.Entities;

namespace User.Application.Authentication.Queries.Login;

public class LoginQueryHandler: IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    
    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        if (_userRepository.GetUserByEmail(request.Email) is not UserEntity user)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        if (user.Password != request.Password)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        var token = _jwtTokenGenerator.GenerateToken(user);
        
        return new AuthenticationResult(user, token);
    }
}