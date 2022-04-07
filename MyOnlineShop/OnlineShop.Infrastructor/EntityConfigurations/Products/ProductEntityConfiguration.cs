using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructor.EntityConfigurations.Products
{
    public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(s => s.Id);

            builder.HasMany(b=>b.product_Categories)
                .WithOne(s=>s.Product)
                .HasForeignKey(b=>b.ProductId);

            builder.HasMany(s => s.Comments)
                .WithOne(s => s.Product)
                .HasForeignKey(s => s.ProductId);

            builder.Property(p=>p.Id).IsRequired();

            builder.Property(p=>p.Price).IsRequired();

            builder.Property(p=>p.IsActive).HasDefaultValue(true);

            builder.Property(p=>p.Inventory).IsRequired();

            builder.Property(p=>p.Picture).IsRequired();
            builder.Property(p => p.Picture).HasMaxLength(500);

            builder.Property(p=>p.Name).HasMaxLength(255);
            builder.Property(p => p.Name).IsRequired();

            builder.Property(f=>f.ShortDescription).IsRequired();
            builder.Property(f=>f.ShortDescription).HasMaxLength(60);

            builder.Property(h=>h.Description).IsRequired();
            builder.Property(h=>h.Description).HasMaxLength(5000);

            builder.Property(l=>l.ShortLink).IsRequired();
            builder.Property(l=>l.ShortLink).HasMaxLength(15);
        }
    }
}
