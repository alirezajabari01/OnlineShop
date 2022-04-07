using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities.UserFeedBacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructor.EntityConfigurations.UserFeedBacks
{
    internal class ProductRateEntityConfiguration : IEntityTypeConfiguration<ProductRate>
    {
        public void Configure(EntityTypeBuilder<ProductRate> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(o => o.Rate).IsRequired();
            builder.Property(o => o.Rate).HasMaxLength(1);

            builder.Property(s => s.ProductId).IsRequired();
            builder.Property(s => s.UserId).IsRequired();

            builder.HasOne(r=>r.User)
                .WithMany(r=>r.ProductRates)
                .HasForeignKey(r=>r.UserId);

            builder.HasOne(s=>s.Product)
                .WithMany(t=>t.ProductRates)
                .HasForeignKey(y=>y.ProductId);
        }
    }
}
