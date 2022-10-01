using FluentValidation;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using User.Api.Common;
using User.Api.Common.Errors;
using User.Api.Common.Mapping;

namespace User.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddSingleton<ProblemDetailsFactory, UserProblemDetailsFactory>();
        services.AddMappings();
        services.AddControllers();
        
        services.AddValidatorsFromAssemblyContaining<IAssemblyMarker>();
        
        return services;
    }
}