using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using User.Application.Common.Interfaces.Authentication;
using User.Application.Common.Interfaces.Persistence;
using User.Application.Common.Interfaces.Services;
using User.Infrastructure.Authentication;
using User.Infrastructure.Persistence;
using User.Infrastructure.Services;

namespace User.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
        )
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IUserRepository, UserRepository>();
        
        return services;
    }
}
