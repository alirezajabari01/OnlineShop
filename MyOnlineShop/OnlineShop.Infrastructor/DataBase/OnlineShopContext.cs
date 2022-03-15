using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Domain.EntityConfigurations.Identity;
using OnlineShop.Domain.Entities.Identity;

namespace OnlineShop.Infrastructor.DataBase
{
    public class OnlineShopContext : IdentityDbContext<ApplicationUser,ApplicationRole, string
        , IdentityUserClaim<string>, ApplicationUserRole, IdentityUserLogin<string>,
        ApplicationRoleClaim, IdentityUserToken<string>>
    {
        public OnlineShopContext(DbContextOptions<OnlineShopContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new UserEnityConfiguration());
            builder.ApplyConfiguration(new RoleEnityConfiguration());
            builder.ApplyConfiguration(new UserRolesEnityConfiguration());
         
        }
    }
}
