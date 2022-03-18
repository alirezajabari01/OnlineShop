using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Entities.Identity
{
    public class ApplicationUser:IdentityUser
    {
        public ApplicationUser()
        {
            UserRoles = new HashSet<ApplicationUserRole>();
        }
        public bool IsActive { get; set; }
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
