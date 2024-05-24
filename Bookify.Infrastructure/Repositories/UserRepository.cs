using Bookify.Domain.Entities.User;
namespace Bookify.Infrastructure.Repositories
{
    internal sealed class UserRepository : Repository<Users>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public void Add(Users user)
        {
            throw new NotImplementedException();
        }

        public Task<Users?> GetbyIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
