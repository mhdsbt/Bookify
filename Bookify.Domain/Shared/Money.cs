using Bookify.Domain.Entities.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Domain.Entities.Shared
{
    public record Money(decimal Amount, Currency Currency) //ValueObject
    {
        public static Money operator +(Money first, Money second) //  For Sum Two  Same Currency  With Together
        {
            if (first.Currency != second.Currency)
            {
                throw new InvalidOperationException("Cuurrencies have to be equal");
            }

            return new Money(first.Amount + second.Amount, first.Currency);
        }

        public static Money Zero() => new Money(0, Currency.None);
        public static Money Zero(Currency currency) => new Money(0, currency);
        public bool IsZero() => this == Zero(Currency);
    }
}
