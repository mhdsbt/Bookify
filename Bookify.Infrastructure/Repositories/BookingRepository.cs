using Bookify.Domain.Entities.Apratment;
using Bookify.Domain.Entities.Booking;
using Bookify.Domain.Entities.User;
using Bookify.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Infrastructure.Repositories
{
    internal sealed class BookingRepository : Repository<Booking>, IBookingRepository
    {
        public BookingRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public Task<bool> Add(Booking booking)
        {
            throw new NotImplementedException();
        }

        public Task<Booking> GetByIdAsync(Guid bookingId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsOverlappingAsync(
            Apartment apartment,
            DateRange duration,
            CancellationToken cancellationToken)
        {
            return await Dbcontext
                 .Set<Booking>()
                 .AnyAsync(
                booking =>
                booking.ApratmentId == apartment.Id &&
                 booking.Duration.Start <= duration.End &&
                 booking.Duration.End >= duration.Start, cancellationToken
                 );
        }
    }
}
