using Bookify.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Infrastructure.Configuration
{
    internal sealed class UserConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.ToTable("users");

            builder.HasKey(u => u.Id);

            builder.Property(user => user.FirstName)
            .HasMaxLength(128);

            builder.Property(user => user.LastName)
            .HasMaxLength(128);

            builder.Property(user => user.Email)
                .HasMaxLength(200);

            
            builder.HasIndex(u=>u.Email).IsUnique();
                
        }
    }
}
