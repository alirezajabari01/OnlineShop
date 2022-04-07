using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.DTO.ProductsDTO
{
    public class UpdateProductDTO
    {
        [Display(Name = "معرف کوتاه")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string ShortDescription { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Description { get; set; }

        public string ShortLink { get; set; }
        public string Id { get; set; }

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

        [DefaultValue("true")]
        public bool IsActive { get; set; }

        public List<string> CategoryIds { get; set; }
    }
}
