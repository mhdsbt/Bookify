using Bookify.Domain.Entities.Apratment;
using Bookify.Domain.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Domain.Entities.Booking
{
    public record PricingDetails
    (
        Money PriceForPeriod,
        Money CleaningFee,
        Money WelfareAmenities,
        Money TotalPrice
    );
}
