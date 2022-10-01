using ErrorOr;

namespace User.Domain.Common.Errors;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCredentials =>
            Error.Custom(
                type: NumericErrorTypes.Unauthorized,
                code: "Authentication.InvalidCredentials",
                description: "Invalid credentials.");
    }
}