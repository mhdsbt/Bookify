using Bookify.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Domain.Enums
{
public static class BookingErrors
    {
        public static Error NotFound = new("Booking.Found", "The Booking With the Specefied Identifier was not found!");
        public static Error NotPending = new("Booking.NotPending", "Not Pending");
        public static Error Confirmed = new("Booking.Confirmed", "The Boooking Already is Confirm");
        public static Error NotConfirm = new("Booking.NotConfirm", "The Booking Already NotConfirm");
        public static Error Alreadystarted = new("Booking.Alreadystarted", "The Booking Already Started");

    }
}
