using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities.BaseEntities;
using OnlineShop.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructor.EntityConfigurations.Products
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(p => p.Name).HasMaxLength(20);
            builder.Property(p => p.Name).IsRequired();

            builder.HasMany(s => s.Categories)
                .WithOne(s => s.SubCategory)
                .HasForeignKey(p => p.ParentId);

            builder.HasMany(s=>s.product_Categories)
                .WithOne(s=>s.Category)
                .HasForeignKey(e=>e.CategoryId);
        }
    }
}
