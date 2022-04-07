using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities.Identity;
using OnlineShop.Core.DTO.RolesDTO;
using OnlineShop.Core.SeedData;

namespace OnlineShop.Infrastructor.EntityConfigurations.Identity
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

            builder.HasMany(w=>w.RoleClaims)
                .WithOne(w=>w.Role)
                .HasForeignKey(s=>s.RoleId);

            builder.Property(x => x.Name).HasMaxLength(20);

            builder.HasData
               (
               new ApplicationRole
               {
                   Id = AuthorizationRole.ManagerRoleId,
                   Name = AuthorizationRole.ManagerRole,
               },
               new ApplicationRole
               {
                   Id = AuthorizationRole.UserRoleId,
                   Name = AuthorizationRole.UserRole,
               },
               new ApplicationRole
               {
                   Id = AuthorizationRole.AdminRoleId,
                   Name = AuthorizationRole.AdminRole,
               }
               );
        }
    }
}
