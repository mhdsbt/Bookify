﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Domain.Entities.User
{
    public interface IUserRepository
    {
        Task<User?> GetbyIdAsync(Guid id, CancellationToken cancellationToken = default);
        void Add(User user);
    }
}
