using Bookify.Domain.Entities.Apratment;
using Bookify.Domain.Entities.User;
namespace Bookify.Infrastructure.Repositories
{
    internal sealed class ApartmentRepository : Repository<Apartment>, IApartmentRepository
    {
        public ApartmentRepository(ApplicationDbContext applicationDb) : base(applicationDb) { }


        public Task<Apartment?> GetIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
