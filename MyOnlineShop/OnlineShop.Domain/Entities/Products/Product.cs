using OnlineShop.Domain.Entities.BaseEntities;
using OnlineShop.Domain.Entities.UserFeedBacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Entities.Products
{
    public class Product : BaseEntity
    {
        public Product()
        {
            product_Categories = new List<Product_Category>();
            Comments = new List<Comment>();
            ProductVotes = new List<ProductVote>();
            ProductRates = new List<ProductRate>();
        }
        public string Name { get; set; }
        public double Price { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string ShortLink { get; set; }
        public string Picture { get; set; }
        public int Inventory { get; set; }
        public List<Product_Category> product_Categories { get; set; }
        public List<Comment> Comments { get; set; }
        public List<ProductVote> ProductVotes { get; set; }
        public List<ProductRate> ProductRates { get; set; }
    }
}
