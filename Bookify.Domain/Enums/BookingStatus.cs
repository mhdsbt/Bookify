using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Domain.Enums
{
    public enum BookingStatus
    {
        Reserved = 1,
        Confirmed = 2,
        Rejected = 3,
        Cancelled = 4,
        Completed = 5,
        NotConfirm = 5
    }
}
