using Mapster;
using User.Application.Authentication.Commands.Register;
using User.Application.Authentication.Common;
using User.Application.Authentication.Queries.Login;
using User.Contracts.Authentication;

namespace User.Api.Common.Mapping;

public class AuthenticationMappingConfig: IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();
        config.NewConfig<LoginRequest, LoginQuery>();
        
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest, src => src.User);
    }
}