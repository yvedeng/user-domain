using User.Application.Common.Interfaces.Persistence;
using User.Domain.Entities;

namespace User.Infrastructure.Persistence;

public class UserRepository: IUserRepository
{
    private readonly List<UserEntity> _users = new();
    public UserEntity? GetUserByEmail(string email)
    {
        return _users.SingleOrDefault(u => u.Email == email);
    }

    public void Add(UserEntity userEntity)
    {
        _users.Add(userEntity);
    }
}