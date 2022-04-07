using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Domain.Entities.Identity;
using OnlineShop.Infrastructor.EntityConfigurations.Identity;
using OnlineShop.Domain.Entities.Products;
using OnlineShop.Infrastructor.EntityConfigurations.Products;
using OnlineShop.Infrastructor.EntityConfigurations.UserFeedBacks;
using OnlineShop.Domain.Entities.UserFeedBacks;

namespace OnlineShop.Infrastructor.DataBase
{
    public class OnlineShopContext : IdentityDbContext<ApplicationUser,ApplicationRole, string
        , IdentityUserClaim<string>, ApplicationUserRole, IdentityUserLogin<string>,
        ApplicationRoleClaim, IdentityUserToken<string>>
    {
        public OnlineShopContext(DbContextOptions<OnlineShopContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories  { get; set; }
        public DbSet<Product_Category> Product_Categories  { get; set; }
        public DbSet<Comment> Comments  { get; set; }
        public DbSet<ProductVote> ProductVotes { get; set; }
        public DbSet<ProductRate> ProductRates { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new UserEnityConfiguration());
            builder.ApplyConfiguration(new RoleEnityConfiguration());
            builder.ApplyConfiguration(new UserRolesEnityConfiguration());
            builder.ApplyConfiguration(new RoleClaimEntityConfigration());
            builder.ApplyConfiguration(new CategoryEntityConfiguration());
            builder.ApplyConfiguration(new ProductEntityConfiguration());
            builder.ApplyConfiguration(new ProductCategoryEntityConfiguration());
            builder.ApplyConfiguration(new CommentsEtityConfiguration());
            builder.ApplyConfiguration(new ProductVoteEntityConfiguration());
            builder.ApplyConfiguration(new ProductRateEntityConfiguration());
        }
    }
}
