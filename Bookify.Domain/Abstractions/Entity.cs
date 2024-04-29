using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Domain.Abstractions
{
    public abstract class Entity
    {
        private readonly List<IDomainEvent> _doaminEvents = new();
        public Entity(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; init; }

        public IReadOnlyList<IDomainEvent> GetDomainEvents()
        {
            return _doaminEvents.ToList();
        }

        public void ClearDomainEvents()
        {
            _doaminEvents.Clear();
        }

        public void RaiseDomainEvent(IDomainEvent domainEvent)
        {
            _doaminEvents.Add(domainEvent);
        }
    }
}
