using Bookify.Domain.Entities.Apratment;
using Bookify.Domain.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Domain.Entities.Booking
{
    public class PricingService
    {
        public PricingDetails CalculatePrice(Apartment apartment,DateRange perdiod)
        {
            var currency = apartment.Price.Currency;

            var priceForPeriod = new Money(
                apartment.Price.Amount * perdiod.LengthDays, currency
                );
            decimal percentageUpCharge = 0;

            foreach(var welfareAmenity in apartment.WelfareAmenities)
            {
                percentageUpCharge += welfareAmenity switch
                {
                    Enums.WelfareAmenities.GradenView or Enums.WelfareAmenities.MountainView => 0.05m,
                    Enums.WelfareAmenities.AirConditioning => 0.01m,
                    Enums.WelfareAmenities.WiFi => 0.01m
                };
            }

            var welfareAmenityCharge = Money.Zero();

            if(percentageUpCharge > 0 )
            {
                welfareAmenityCharge = new Money(
                    priceForPeriod.Amount * percentageUpCharge, currency);
            }

            var totalPrice = Money.Zero();
            totalPrice += priceForPeriod;

            if(!apartment.CleaningFee.IsZero())
            {
                totalPrice += apartment.CleaningFee;
            }

            totalPrice += welfareAmenityCharge;


            return new PricingDetails(priceForPeriod, apartment.CleaningFee, welfareAmenityCharge, totalPrice);
        }
    }
}
