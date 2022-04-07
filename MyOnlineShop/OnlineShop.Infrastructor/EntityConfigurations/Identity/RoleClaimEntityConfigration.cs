using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Core.SeedData;
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

            builder.HasData
                (
                new ApplicationRoleClaim()
                {
                    Id = 1,
                    ClaimType = AuthorizationRoleClaim.ClaimTyp,
                    ClaimValue = AuthorizationRoleClaim.UserClaimValue,
                    RoleId = AuthorizationRole.UserRoleId
                },
                 new ApplicationRoleClaim()
                 {
                     Id = 2,
                     ClaimType = AuthorizationRoleClaim.ClaimTyp,
                     ClaimValue = AuthorizationRoleClaim.AdminRoleClaimsClaimValue,
                     RoleId = AuthorizationRole.AdminRoleId

                 },
                  new ApplicationRoleClaim()
                  {
                      Id = 3,
                      ClaimType = AuthorizationRoleClaim.ClaimTyp,
                      ClaimValue = AuthorizationRoleClaim.AdminRolesClaimValue,
                      RoleId = AuthorizationRole.AdminRoleId

                  },
                  new ApplicationRoleClaim()
                  {
                      Id = 4,
                      ClaimType = AuthorizationRoleClaim.ClaimTyp,
                      ClaimValue = AuthorizationRoleClaim.AdminCommentsClaimValue,
                      RoleId = AuthorizationRole.AdminRoleId

                  },
                   new ApplicationRoleClaim()
                   {
                       Id = 5,
                       ClaimType = AuthorizationRoleClaim.ClaimTyp,
                       ClaimValue = AuthorizationRoleClaim.AdminProductsClaimValue,
                       RoleId = AuthorizationRole.AdminRoleId

                   },
                   new ApplicationRoleClaim()
                   {
                       Id = 6,
                       ClaimType = AuthorizationRoleClaim.ClaimTyp,
                       ClaimValue = AuthorizationRoleClaim.AdminUsersClaimValue,
                       RoleId = AuthorizationRole.AdminRoleId
                   },
                   new ApplicationRoleClaim()
                   {
                       Id = 7,
                       ClaimType = AuthorizationRoleClaim.ClaimTyp,
                       ClaimValue = AuthorizationRoleClaim.AdminCategoryClaimValue,
                       RoleId = AuthorizationRole.AdminRoleId
                   }
                );
        }
    }
}
