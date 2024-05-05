using Bookify.Application.Abstraction;
using Bookify.Domain.Abstractions;
using Bookify.Domain.Entities.Apratment;
using Bookify.Domain.Entities.Booking;
using Bookify.Domain.Entities.User;
using Bookify.Domain.Enums;

namespace Bookify.Application.Bookings.ReserveBooking
{
    internal sealed class ReserveBookingCommandHandler : ICommandHandler<ReserveBookingCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly PricingService _pricingService;

        public ReserveBookingCommandHandler(
            IUserRepository userRepository,
            IApartmentRepository partmentRepository,
            IBookingRepository bookingRepository,
            IUnitOfWork unitOfWork,
            PricingService pricingService)
        {
            _userRepository = userRepository;
            _apartmentRepository = partmentRepository;
            _bookingRepository = bookingRepository;
            _unitOfWork = unitOfWork;
            _pricingService = pricingService;
        }

        public async Task<Result<Guid>> Handle(ReserveBookingCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetbyIdAsync(request.UserId, cancellationToken);

            if (user is null)
            {
                return Result.Failure<Guid>(UserErrors.NotFound);
            }

            var apartment = await _apartmentRepository.GetIdAsync(request.ApartmentId, cancellationToken);

            if (apartment is null)
            {
                return Result.Failure<Guid>(ApartmentErrors.NotFound);
            }

            var duration = DateRange.Create(request.StartDate, request.EndDate);

            if (await _bookingRepository.IsOverlappingAsync(apartment, duration, cancellationToken))
            {
                return Result.Failure<Guid>(BookingErrors.OverLap);
            }

            
            var booking = Booking.Reserve( //TODO: I know if two Request Pass OverLaping this can be race condition that  i fix later
                apartment,
                user.Id,
                duration,
                utcNow: DateTime.UtcNow,
                _pricingService
                );

            _bookingRepository.Add(booking);

            await _unitOfWork.SavechangeAsync(cancellationToken);

            return Result.Success(booking.Id);

        }
    }
}
