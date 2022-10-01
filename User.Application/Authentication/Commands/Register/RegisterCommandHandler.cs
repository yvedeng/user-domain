using ErrorOr;
using MediatR;
using User.Application.Authentication.Common;
using User.Application.Common.Interfaces.Authentication;
using User.Application.Common.Interfaces.Persistence;
using User.Domain.Common.Errors;
using User.Domain.Entities;

namespace User.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    
    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        // check if user already exists
        if (_userRepository.GetUserByEmail(request.Email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }
        // create user
        var user = new UserEntity
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Password = request.Password
        };
        
        _userRepository.Add(user);

        // create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);
        
        return new AuthenticationResult(user, token);
    }
}