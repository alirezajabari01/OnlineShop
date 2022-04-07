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
    internal class ProductVoteEntityConfiguration : IEntityTypeConfiguration<ProductVote>
    {
        public void Configure(EntityTypeBuilder<ProductVote> builder)
        {
            builder.Property(r => r.Vote).IsRequired();
            builder.Property(r => r.UserId).IsRequired();
            builder.Property(r => r.ProductId).IsRequired();

            builder.HasKey(i => i.Id);

            builder.HasOne(s => s.Product)
                .WithMany(d => d.ProductVotes)
                .HasForeignKey(o => o.ProductId);
        }
    }
}
