using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.SeedData
{
    public class AuthorizationRoleClaim
    {
       public const string ClaimTyp = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/authorizationdecision";

        public const string UserClaimValue = "User";

        public const string AdminProductsClaimValue = "Admin.Products";
        public const string AdminUsersClaimValue = "Admin.Users";
        public const string AdminRolesClaimValue = "Admin.Roles";
        public const string AdminRoleClaimsClaimValue = "Admin.RoleClaims";
        public const string AdminCategoryClaimValue = "Admin.Category";
        public const string AdminCommentsClaimValue = "Admin.Comments";
    }
}
