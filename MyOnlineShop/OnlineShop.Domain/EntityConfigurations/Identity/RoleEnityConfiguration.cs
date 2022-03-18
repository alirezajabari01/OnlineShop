using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities.Identity;

namespace OnlineShop.Domain.EntityConfigurations.Identity
{
    public class RoleEnityConfiguration : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            //builder.Property(s => s.Id)
            //    .ValueGeneratedNever().Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            builder.ToTable("Roles");

            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.UserRoles)
                .WithOne(w => w.Role)
                .HasForeignKey(w => w.RoleId);

            builder.Property(x => x.Name).HasMaxLength(20);

            builder.HasData
               (
               new ApplicationRole
               {
                   Id = "e7200f30632b4742ad2a0ed4902049f9",
                   Name = "Manager",
                   NormalizedName = "MANAGER",
                   ConcurrencyStamp = "b0ae4265895643878cdf010610719615"
               },
               new ApplicationRole
               {
                   Id = "6da17853bad14f88b29b246e8ad4a085",
                   Name = "User",
                   NormalizedName = "USER",
                   ConcurrencyStamp = "ae83cc896b484d9498cd3bf66ef2fcdc"
               },
               new ApplicationRole
               {
                   Id = "a5dddd3a3e6949289c766384a8df4db3",
                   Name = "Admin",
                   NormalizedName = "ADMIN",
                   ConcurrencyStamp= "b2da4a92633d4bab94f615cf88be86d3"
               }
               );
        }
    }
}
