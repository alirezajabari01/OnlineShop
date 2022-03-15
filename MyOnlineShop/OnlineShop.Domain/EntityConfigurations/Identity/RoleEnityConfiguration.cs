using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities.Identity;

namespace OnlineShop.Domain.EntityConfigurations.Identity
{
    public class RoleEnityConfiguration : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            builder.ToTable("Roles");

            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.UserRoles)
                .WithOne(w => w.Role)
                .HasForeignKey(w => w.RoleId);

            builder.Property(x => x.Name).HasMaxLength(20);
        }
    }
}
