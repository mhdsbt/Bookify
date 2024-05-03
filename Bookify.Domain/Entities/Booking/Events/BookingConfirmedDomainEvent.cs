using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Entities.Booking.Events
{
    public sealed record BookingConfirmedDomainEvent(Guid BookingId) : IDomainEvent;
}
