using Bookify.Domain.Abstractions;
using Bookify.Domain.Entities.Shared;
using Bookify.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Domain.Entities.Apratment
{
    public sealed class Apartment : Entity
    {
        public Apartment(
            Guid id,
            string name,
            string description,
            Address address,
            Money price,
            Money cleaningfee,
            List<WelfareAmenities> welfareAmenities
            ) : base(id)
        {
            Name = name;
            Description = description;
            Address = address;
            CleaningFee = cleaningfee;
            Price = price;
        }

        public string Name { get; private set; } // we dont want change Property Out of Domain use private set for this
        public string Description { get; private set; }
        public Address Address { get; private set; }
        public Money Price { get; private set; }
        public Money CleaningFee { get; private set; }
        public DateTime? LastBookedOnUtc { get; private set; }
        public List<WelfareAmenities> WelfareAmenities { get; private set; } = new();
    }
}
