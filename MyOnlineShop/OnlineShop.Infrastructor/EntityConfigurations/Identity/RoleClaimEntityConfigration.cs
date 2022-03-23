using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructor.EntityConfigurations.Identity
{
    public class RoleClaimEntityConfigration : IEntityTypeConfiguration<ApplicationRoleClaim>
    {
        public void Configure(EntityTypeBuilder<ApplicationRoleClaim> builder)
        {
            builder.ToTable("RoleClaims");

            builder.HasOne(w => w.Role);
        }
    }
}
