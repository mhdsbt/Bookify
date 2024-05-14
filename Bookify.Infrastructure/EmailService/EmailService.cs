using Bookify.Application.Abstraction.Email;
using Bookify.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Infrastructure.EmailService
{
    internal sealed class EmailService : IEmailService
    {
        public Task SendAsync(Email recipient, string subject, string body)
        {
            //do work here
            return Task.CompletedTask;
        }
    }
}
