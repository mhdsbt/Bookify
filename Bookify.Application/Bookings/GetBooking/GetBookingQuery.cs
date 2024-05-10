using Bookify.Application.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Application.Bookings.GetBooking
{
public sealed record GetBookingQuery(Guid bookingId):IQuery<BookingResponse>;
}
