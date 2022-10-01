using ErrorOr;

namespace User.Domain.Common.Errors;

public static partial class Errors
{
    public static class User
    {
        public static Error DuplicateEmail => 
            Error.Conflict(
                code: "User.DuplicateEmailError", 
                description: "Email already exists!");
    }
}