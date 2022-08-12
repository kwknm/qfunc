using ErrorOr;

namespace QFunc.Domain.Common.Errors;

public static partial class Errors
{
    public static class Identity
    {
        public static Error InvalidCredentials => Error.Validation(
            code: "Identity.InvalidCredentials",
            description: "Invalid credentials.");
    }
}