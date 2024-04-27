using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Domain.Abstractions
{
    public abstract class Entity
    {
        public Entity(Guid id)
        {
            Id= id;
        }
        public Guid Id { get; init; }
    }
}
