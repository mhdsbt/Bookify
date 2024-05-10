using Bookify.Domain.Abstractions;
using Bookify.Domain.Entities.User.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Domain.Entities.User
{
    public sealed class Users : Entity
    {
        public Users(Guid id, string FirstName, string LastName, string Email) : base(id)
        {
        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public string Email { get; private set; }

        public static Users Create(Guid id, string FirstName, string LastName, string Email)
        {
            var user = new Users(id, FirstName, LastName, Email);

            user.RaiseDomainEvent(new UserCreatedDomainEvent(user.Id));

            return user;
        }
    }
}
