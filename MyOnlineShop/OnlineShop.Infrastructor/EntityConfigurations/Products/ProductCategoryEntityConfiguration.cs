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
    internal class ProductCategoryEntityConfiguration : IEntityTypeConfiguration<Product_Category>
    {
        public void Configure(EntityTypeBuilder<Product_Category> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.ProductId).IsRequired();
            builder.Property(s => s.CategoryId).IsRequired();

            builder.HasOne(p => p.Category)
                .WithMany(s => s.product_Categories)
                .HasForeignKey(s => s.CategoryId);

            builder.HasOne(p => p.Product)
                .WithMany(s => s.product_Categories)
                .HasForeignKey(s => s.ProductId);
        }

    }
}
