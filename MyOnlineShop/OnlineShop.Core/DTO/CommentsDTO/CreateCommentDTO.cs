using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.DTO.CommentsDTO
{
    public class CreateCommentDTO
    {
        [Display(Name = "کامنت")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Text { get; set; }
        public string ParentId { get; set; }
        [Required]
        public string ProductId { get; set; }
    }
}
