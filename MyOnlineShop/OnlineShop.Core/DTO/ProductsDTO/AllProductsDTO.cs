using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.DTO.ProductsDTO
{
    public class AllProductsDTO
    {
        public string Id { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string ShortLink { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Picture { get; set; }
        public int Inventory { get; set; }
    }
}
