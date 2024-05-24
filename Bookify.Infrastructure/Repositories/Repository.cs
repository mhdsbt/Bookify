using Bookify.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Infrastructure.Repositories
{
    internal abstract class Repository<T>
        where T : Entity
    {
        protected readonly ApplicationDbContext Dbcontext;
        public Repository(ApplicationDbContext applicationDbContext)
        {
            Dbcontext = applicationDbContext;
        }

        public async Task<T?> GetbyIdAsync(
            Guid id,
            CancellationToken cancellationToken = default
            )
        {
            return await Dbcontext
                .Set<T>()
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }


        public void Add(T entity)
        {
            Dbcontext.Add(entity);
        }


    }
}
