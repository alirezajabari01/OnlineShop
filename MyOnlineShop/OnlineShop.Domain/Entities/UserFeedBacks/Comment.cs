using OnlineShop.Domain.Entities.BaseEntities;
using OnlineShop.Domain.Entities.Identity;
using OnlineShop.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Entities.UserFeedBacks
{
    public class Comment : BaseEntity
    {
        public string Text { get; set; }
        public string UserId { get; set; }
        public string ParentId { get; set; }
        public string ProductId { get; set; }

        public Comment Reply { get; set; }
        public List<Comment> Replies { get; set; }

        public Product Product { get; set; }
        public ApplicationUser User { get; set; }
    }
}
