using Microsoft.AspNetCore.Mvc.Infrastructure;
using User.Api.Common.Errors;
using User.Application;
using User.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
    
    builder.Services.AddControllers();
    
    builder.Services.AddSingleton<ProblemDetailsFactory, UserProblemDetailsFactory>();
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}

