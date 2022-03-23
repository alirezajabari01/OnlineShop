using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities.Identity;

namespace OnlineShop.Infrastructor.EntityConfigurations.Identity
{
    public class UserRolesEnityConfiguration : IEntityTypeConfiguration<ApplicationUserRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserRole> builder)
        {
            builder.ToTable("UserRoles");

            builder.HasOne(x => x.Role);

            builder.HasOne(x => x.User);

        }
    }
}
