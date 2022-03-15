using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.EntityConfigurations.Identity
{
    public class UserEnityConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.UserName).IsRequired();
            builder.Property(s => s.UserName).HasMaxLength(50);
            builder.Property(s => s.NormalizedUserName).HasMaxLength(50);

            builder.Property(w => w.PhoneNumber).IsRequired();
            builder.Property(s => s.PhoneNumber).HasMaxLength(11);

            builder.HasMany(x=>x.UserRoles)
                .WithOne(w=>w.User)
                .HasForeignKey(w=>w.UserId);

            builder.HasIndex(w => w.PhoneNumber).IsUnique();
            builder.HasIndex(w => w.UserName).IsUnique();
        }
    }
}
