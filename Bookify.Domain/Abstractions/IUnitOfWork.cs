using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        Task<int> SavechangeAsync(CancellationToken cancellationToken = default);
    }
}
