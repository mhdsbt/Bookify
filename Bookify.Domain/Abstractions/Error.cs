using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Domain.Abstractions
{
    public record Error(string code, string name)
    {
        public static Error None = new(string.Empty, string.Empty);
        public static Error NullValue = new("Erro.NullVaue", "Null Value Was provided");       
    }
}
