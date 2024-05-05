using Bookify.Domain.Abstractions;
using Bookify.Domain.Entities.Apratment;
using Bookify.Domain.Entities.Booking.Events;
using Bookify.Domain.Entities.Shared;
using Bookify.Domain.Enums;

namespace Bookify.Domain.Entities.Booking
{
    public class Booking : Entity
    {
        private Booking(
            Guid id,
            Guid apratmentId,
            DateRange duration,
            Money priceForperiod,
            Money cleaningFee,
            Money welfareAmenitiesCharge,
            Money totalPrice,
            BookingStatus status,
            DateTime createdOnUtc,
            Guid userId
            ) : base(id)
        {
            ApratmentId = apratmentId;
            CleaningFee = cleaningFee;
            Duration = duration;
            PriceForperiod = priceForperiod;
            Status = status;
            CreatedOnUtc = createdOnUtc;
            TotalPrice = totalPrice;
            UserId = userId;

        }

        public Guid ApratmentId { get; private set; }
        public Guid UserId { get; private set; }
        public DateRange Duration { get; private set; }
        public Money PriceForperiod { get; private set; }
        public Money CleaningFee { get; private set; }
        public Money WelfareAmenitiesCharge { get; private set; }
        public Money TotalPrice { get; private set; }
        public BookingStatus Status { get; private set; }
        public DateTime CreatedOnUtc { get; private set; }
        public DateTime ConfirmAtUtc { get; private set; }
        public PricingDetails PricingDetails { get; private set; }

        public static Booking Reserve(
            Apartment apartment,
            Guid userId,
            DateRange duration,
            DateTime utcNow,
            PricingService pricingService
    )
        {

            var pricingDetails = pricingService.CalculatePrice(apartment, duration);

            var booking = new Booking(
                Guid.NewGuid(),
                apartment.Id,
                duration,
                pricingDetails.PriceForPeriod,
                pricingDetails.CleaningFee,
                pricingDetails.WelfareAmenities,
                pricingDetails.TotalPrice,
                BookingStatus.Reserved,
                utcNow,
                userId
                );

            booking.RaiseDomainEvent(new BookingReservedDomainEvent(booking.Id));

            booking.CreatedOnUtc = utcNow;
            apartment.LastBookedOnUtc = utcNow;

            return booking;
        }

        public Result Confirm(DateTime utcNow)
        {
            if (Status == BookingStatus.Reserved)
            {
                return Result.Failure(BookingErrors.NotPending);
            }

            Status = BookingStatus.Confirmed;
            ConfirmAtUtc = utcNow;

            RaiseDomainEvent(new BookingConfirmedDomainEvent(Id));

            return Result.Sucess();
        }

        public Result Reject(DateTime utcNow)
        {
            if (Status == BookingStatus.Reserved)
            {
                return Result.Failure(BookingErrors.NotPending);
            }

            Status = BookingStatus.Rejected;
            ConfirmAtUtc = utcNow;

            RaiseDomainEvent(new BookingRejectedDomainEvent(Id));

            return Result.Sucess();
        }

        public Result Complete(DateTime utcNow)
        {
            if (Status == BookingStatus.Confirmed)
            {
                return Result.Failure(BookingErrors.NotConfirm);
            }

            Status = BookingStatus.Completed;
            ConfirmAtUtc = utcNow;

            RaiseDomainEvent(new BookingReservedDomainEvent(Id));

            return Result.Sucess();
        }

        public Result Cancel(DateTime utcNow)
        {
            if (Status == BookingStatus.Confirmed)
            {
                return Result.Failure(BookingErrors.Confirmed);
            }

            var currentDate = DateOnly.FromDateTime(utcNow);

            if (currentDate > Duration.Start)
            {
                return Result.Failure(BookingErrors.Alreadystarted);
            }
            Status = BookingStatus.Completed;
            ConfirmAtUtc = utcNow;

            RaiseDomainEvent(new BookingCancelledDomainEvent(Id));

            return Result.Sucess();
        }
    }
}
