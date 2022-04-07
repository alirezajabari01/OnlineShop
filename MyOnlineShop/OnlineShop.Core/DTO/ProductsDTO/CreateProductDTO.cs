using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.DTO.ProductsDTO
{
    public class CreateProductDTO
    {
        [Display(Name = "معرف کوتاه")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MaxLength(60)]
        public string ShortDescription { get; set; }

        [MaxLength(5000)]
        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Description { get; set; }

        public string ShortLink { get; set; }
        private string Id { get; set; } = Guid.NewGuid().ToString();

        [Display(Name = "نام محصول")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Name { get; set; }

        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public double Price { get; set; }

        [Display(Name = "تصویر")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public IFormFile Picture { get; set; }

        [Display(Name = "موجودی")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public int Inventory { get; set; }
        public List<string> CategoryIds { get; set; }
        public List<ProductCategoryDTO> product_Categories { get; set; }
        public List<ProductCategoryDTO> ProductCategories
        {
            get
            {
                List<ProductCategoryDTO> product_Categories = new List<ProductCategoryDTO>();
                foreach (var item in CategoryIds)
                {
                    var dto = new ProductCategoryDTO()
                    {
                        CategoryId = item
                    };
                    product_Categories.Add(dto);
                }
              return product_Categories;
            }
            set
            {
                product_Categories = value;
            }
        }
        
    }
}
