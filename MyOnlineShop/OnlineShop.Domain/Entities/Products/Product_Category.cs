using OnlineShop.Domain.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Entities.Products
{
    public class Product_Category:BaseEntity
    {
        public Product_Category()
        {
            ProductId = Guid.NewGuid().ToString().Replace("-","");
            CategoryId = Guid.NewGuid().ToString().Replace("-","");
        }
        public string ProductId { get; set; }
        public string CategoryId { get; set; }

        public Product Product { get; set; }
        public Category Category { get; set; }
    }
}
