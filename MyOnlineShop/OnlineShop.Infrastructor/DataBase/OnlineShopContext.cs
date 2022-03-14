using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructor.DataBase
{
    public class OnlineShopContext : IdentityDbContext
    {
        public OnlineShopContext(DbContextOptions<OnlineShopContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityUser>()
                .ToTable ("Users");

            builder.Entity<IdentityRole>()
                .ToTable("Roles");

            builder.Entity<IdentityUserRole<string>>()
                .ToTable("UserRoles");

            //builder.Entity<IdentityUserClaim<string>>()
            //    .ToTable("UserClaims");


        }
    }
}
