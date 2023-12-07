using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Myta.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myta.Infrastructure.Data.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(p => p.FirstName).IsRequired().HasColumnType("nvarchar(25)");
            builder.Property(p => p.LastName).IsRequired().HasColumnType("nvarchar(25)");
            builder.Property(p => p.Avatar);
            builder.Property(p => p.Gender);
            builder.Property(p => p.Dob);
        }
    }
}
