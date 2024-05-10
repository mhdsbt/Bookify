namespace Bookify.Domain.Entities.User
{
    public record Email
    {
        public string Address { get; set; }

        public static Email Get(string address)
        {
            return new Email { Address = address };
        }
    }
}