namespace Bookify.Application.Abstraction.Email
{
    public interface IEmailService
    {
        Task SendAsync(Bookify.Domain.Entities.User.Email recipient, string subject, string body);
    }
}
