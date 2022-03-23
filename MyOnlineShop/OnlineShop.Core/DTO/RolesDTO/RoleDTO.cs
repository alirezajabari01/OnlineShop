using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.DTO.RolesDTO
{
    public class RoleDTO
    {
        public string Id { get; set; }

        [Display(Name = "نقش")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Name { get; set; }

        public bool IsActive { get; set; }
    }
}
