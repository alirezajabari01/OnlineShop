using OnlineShop.Domain.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Entities.Products
{
    public class Category:BaseEntity
    {
        public Category()
        {
            product_Categories = new HashSet<Product_Category>();
        }
        public string Name { get; set; }
        public string ParentId { get; set; }

        public ICollection<Product_Category> product_Categories { get; set; }
        public ICollection<Category> Categories { get; set; }
        public Category SubCategory { get; set; }
    }
}
