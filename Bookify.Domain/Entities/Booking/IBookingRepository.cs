using Bookify.Domain.Entities.Apratment;

namespace Bookify.Domain.Entities.Booking
{
    public interface IBookingRepository
    {
        Task<bool> IsOverlappingAsync(Apartment apartment,DateRange duration,CancellationToken cancellationToken);
        Task<bool> Add(Booking booking);
        Task<Booking> GetByIdAsync(Guid bookingId,CancellationToken cancellationToken);
    }
}
