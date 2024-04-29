using Bookify.Domain.Abstractions;
using Bookify.Domain.Entities.Booking.Events;
using Bookify.Domain.Entities.Shared;
using Bookify.Domain.Enums;

namespace Bookify.Domain.Entities.Booking.Shared
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
        public PricingDetails PricingDetails { get; private set; }

        public static Booking Reserve(
            Guid apartmentId,
            Guid userId,
            DateRange duration,
            DateTime utcNow,
            PricingDetails pricingDetails
    )
        {
            var booking = new Booking(
                Guid.NewGuid(),
                apartmentId,
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

            return booking;
        }
    }
}
