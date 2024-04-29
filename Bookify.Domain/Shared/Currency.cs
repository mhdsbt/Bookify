using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Domain.Entities.shared
{
    public record Currency //Value object
    {
        public static readonly Currency Usd = new(Usd);
        public static readonly Currency Eur = new(Eur);
        internal static readonly Currency None = new("");

        private Currency(string code) => Code = code;
        public string Code { get; set; }

        public static Currency FromCode(string code)
        {
            return All.FirstOrDefault(c => c.Code == code) ?? throw new ApplicationException("the currency code Is Invalid");
        }

        public static IReadOnlyCollection<Currency> All = new[]
        {
            Usd, Eur
        };
    }
}
