using User.Domain.Entities;

namespace User.Contracts.User;

public record UpdateUserRequest(
    string Username,
    string UserStatus);