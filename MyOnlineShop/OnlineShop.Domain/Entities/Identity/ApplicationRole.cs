using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace OnlineShop.Domain.Entities.Identity
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole()
        {
                
        }
        public ApplicationRole(string roleName):base(roleName)
        {
            UserRoles = new HashSet<ApplicationUserRole>();
        }
        public bool IsActive { get; set; }
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
        public ICollection<ApplicationRoleClaim> RoleClaims { get; set; }
    }
}