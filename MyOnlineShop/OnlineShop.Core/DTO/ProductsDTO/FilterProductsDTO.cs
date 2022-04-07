using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.DTO.ProductsDTO
{
    public class FilterProductsDTO
    {
        public string CategoryId { get; set; }
        [DefaultValue(0)]
        public double MinPrice { get; set; }
        [DefaultValue(0)]
        public double MaxPrice { get; set; }
        public string Name { get; set; }
        public string OrderByType { get; set; }
    }
}
