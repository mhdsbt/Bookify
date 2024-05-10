using Bookify.Application.Abstraction.Email;
using Bookify.Domain.Entities.Booking;
using Bookify.Domain.Entities.Booking.Events;
using Bookify.Domain.Entities.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Application.Bookings.ReserveBooking
{
    internal sealed class BookingReservedDomainEventHandler : INotificationHandler<BookingReservedDomainEvent>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;

        public BookingReservedDomainEventHandler(
            IBookingRepository bookingRepository,
            IUserRepository userRepository,
            IEmailService emailService)
        {
            _bookingRepository = bookingRepository;
            _userRepository = userRepository;
            this._emailService = emailService;
        }

        public async Task Handle(BookingReservedDomainEvent notification, CancellationToken cancellationToken)
        {
            var booking = await _bookingRepository.GetByIdAsync(notification.BookingId, cancellationToken);

            if(booking is null)
            {
                return;
            }

            var user = await _userRepository.GetbyIdAsync(booking.UserId, cancellationToken);

            if(user is null)
            {
                return;
            }

            await _emailService.SendAsync(
                Email.Get(user.Email),
                "Booking Reserved!!",
                "you have 10 minutes tp confirm this booking"
                );

        }
    }
}
