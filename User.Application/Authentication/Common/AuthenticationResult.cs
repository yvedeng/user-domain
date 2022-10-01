using User.Domain.Entities;

namespace User.Application.Authentication.Common;

public record AuthenticationResult(
    UserEntity User,
    string Token);