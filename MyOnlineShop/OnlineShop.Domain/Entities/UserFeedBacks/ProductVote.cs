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
    public class ProductVote:BaseEntity
    {
        public bool Vote { get; set; }
        public string ProductId { get; set; }
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
        public Product Product { get; set; }
    }
}
