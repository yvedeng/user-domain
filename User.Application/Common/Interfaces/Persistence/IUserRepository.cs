using User.Domain.Entities;

namespace User.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    
    UserEntity? GetUserByEmail(string email);

    
    void Add(UserEntity userEntity);
}