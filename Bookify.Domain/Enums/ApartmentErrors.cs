using Bookify.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Domain.Enums
{
    public static class ApartmentErrors
    {
        public static Error NotFound = new("Apartment.Found", "The Apatment With the Specefied Identifier was not found!");

    }
}
