using Bookify.Application.Abstraction;

namespace Bookify.Application.Bookings.ReserveBooking
{
    public record ReserveBookingCommand(
        Guid ApartmentId,
        Guid UserId,
        DateOnly StartDate,
        DateOnly EndDate
        ) : ICommand<Guid>;
}
