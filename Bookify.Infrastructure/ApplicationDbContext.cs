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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);// automatically apply Configuration from an appemply that contain applicationdbcotext
            base.OnModelCreating(modelBuilder);
        }
    }
}
