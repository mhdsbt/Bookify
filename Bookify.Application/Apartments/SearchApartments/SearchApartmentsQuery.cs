﻿using Bookify.Application.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Application.Apartments.SearchApartments
{
    public sealed record SearchApartmentsQuery(
        DateOnly startDate,
        DateOnly endDate
        ):IQuery<IReadOnlyList<ApartmentResponse>>;
}
