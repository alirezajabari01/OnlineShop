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
    internal class CommentsEtityConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(w => w.Text).IsRequired();
            builder.Property(w => w.Text).HasMaxLength(400);

            builder.Property(w => w.UserId).IsRequired();

            builder.HasMany(s => s.Replies)
                .WithOne(w => w.Reply)
                .HasForeignKey(e => e.ParentId);
        }
    }
}
