using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Enums
{
    public static class UserErrors
    {
        public static Error NotFound = new("User.Found", "The User With the Specefied Identifier was not found!");
    }
}
