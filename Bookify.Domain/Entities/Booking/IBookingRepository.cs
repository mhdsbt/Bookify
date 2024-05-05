using Bookify.Domain.Entities.Apratment;

namespace Bookify.Domain.Entities.Booking
{
    public interface IBookingRepository
    {
        Task<bool> IsOverlappingAsync(Apartment apartment,DateRange dateRange,CancellationToken cancellationToken);
        Task<bool> Add(Booking booking);
    }
}
