using Bookify.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Infrastructure
{
    public sealed class ApplicationDbContext : DbContext, IUnitOfWork
    {
        public ApplicationDbContext(DbContext options) : base()
        {

        }

        public Task<int> SavechangeAsync(CancellationToken cancellationToken = default)
        {
           
            throw new NotImplementedException();
        }
    }
}
