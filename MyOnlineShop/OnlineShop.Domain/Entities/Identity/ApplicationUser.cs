using Microsoft.AspNetCore.Identity;
using OnlineShop.Domain.Entities.UserFeedBacks;
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
        public List<Comment> Comments { get; set; }
        public List<ProductVote> ProductVotes { get; set; }
        public List<ProductRate> ProductRates { get; set; }
    }
}
