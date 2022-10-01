using User.Domain.Entities;

namespace User.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(UserEntity user);
}