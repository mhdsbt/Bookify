using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Application.Bookings.ReserveBooking
{
    public class ReserveBookingCommandValidator : AbstractValidator<ReserveBookingCommand>
    {
        public ReserveBookingCommandValidator()
        {
            RuleFor(c=>c.UserId).NotNull().NotEmpty();

            RuleFor(c => c.ApartmentId).NotNull().NotEmpty();

            RuleFor(c=>c.StartDate).LessThan(c=>c.EndDate);


        }
    }
}
