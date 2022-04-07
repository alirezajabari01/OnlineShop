using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.DTO.CategoriesDTO
{
    public class CategoryDTO
    {
        public string Id { get; set; }

        [Display(Name = "نام کتگوری")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Name { get; set; }
        public string ParentId { get; set; }
    }
}
