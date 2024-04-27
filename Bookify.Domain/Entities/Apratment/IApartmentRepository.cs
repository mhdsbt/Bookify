using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Domain.Entities.Apratment
{
    public interface IApartmentRepository
    {
        Task<Apartment?> GetIdAsync(Guid id, CancellationToken cancellationToken = default);

    }
}
