using ErrorOr;

namespace QFunc.Domain.Common.Errors;

public static partial class Errors
{
    public static class User
    {
        public static Error DuplicateEmail =
            Error.Conflict(code: "User.DuplicateEmail", description: "Email is already in use.");
        public static Error DuplicateUserName =
            Error.Conflict(code: "User.DuplicateUserName", description: "User Name is already in use.");
    }
}