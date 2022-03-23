using OnlineShop.Domain.Entities.BaseEntities;
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
            product_Categories = new HashSet<Product_Category>();
        }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Picture { get; set; }
        public int Inventory { get; set; }
        public ICollection<Product_Category> product_Categories { get; set; }
    }
}
